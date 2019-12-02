#include "Header.h"

using namespace std;
namespace Level
{
	bool SetIntegrityLevel(std::string privilegeLevel, int ID)
	{
		std::string sidLevel;
		if (privilegeLevel == "Untrusted")
			sidLevel = "S-1-16-0";
		else if (privilegeLevel == "Low")
			sidLevel = "S-1-16-4096";
		else if (privilegeLevel == "Medium")
			sidLevel = "S-1-16-8192";
		else if (privilegeLevel == "High")
			sidLevel = "S-1-16-12288";
		else {
			std::wcerr << L"Wrong integrity level. Avaible (Untrusted/Low/Medium/High)" << std::endl;
			return false;
		}

		HANDLE hProcess = OpenProcess(PROCESS_ALL_ACCESS, FALSE, ID);
		if (hProcess != INVALID_HANDLE_VALUE) {
			if (OpenProcessToken(hProcess, TOKEN_QUERY | TOKEN_ADJUST_DEFAULT, &hProcess)) {
				DWORD dwSize = 0;
				if (GetTokenInformation(hProcess, TokenIntegrityLevel, NULL, 0, &dwSize) || GetLastError() == ERROR_INSUFFICIENT_BUFFER) {
					PTOKEN_MANDATORY_LABEL pTokenLevel = (PTOKEN_MANDATORY_LABEL)LocalAlloc(0, dwSize);
					if (pTokenLevel != NULL) {
						if (GetTokenInformation(hProcess, TokenIntegrityLevel, pTokenLevel, dwSize, &dwSize)) {
							PSID pSID = NULL;
							ZeroMemory(pTokenLevel, sizeof(pTokenLevel));
							ConvertStringSidToSidA(sidLevel.c_str(), &pSID);
							pTokenLevel->Label.Attributes = SE_GROUP_INTEGRITY;
							pTokenLevel->Label.Sid = pSID;
							SetTokenInformation(hProcess, TokenIntegrityLevel, pTokenLevel, dwSize);
							CloseHandle(hProcess);
							LocalFree(pTokenLevel);
							return true;
						}
						LocalFree(pTokenLevel);
					}
				}
			}
		}
		CloseHandle(hProcess);
		return false;
	}

}