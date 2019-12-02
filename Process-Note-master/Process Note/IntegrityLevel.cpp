#include "IntegrityLevel.h"

namespace IntegrityLevel
{
	
    int GetFileIntegrityLevel(LPCWSTR FileName)
    {
        DWORD integrityLevel = 0x2000;
        PSECURITY_DESCRIPTOR pSD = NULL;
        PACL acl = 0;
        if (ERROR_SUCCESS == ::GetNamedSecurityInfo(FileName, SE_FILE_OBJECT, LABEL_SECURITY_INFORMATION, 0, 0, 0, &acl, &pSD))
        {
            if (0 != acl && 0 < acl->AceCount)
            {
                SYSTEM_MANDATORY_LABEL_ACE* ace = 0;
                if (::GetAce(acl, 0, reinterpret_cast<void**>(&ace)))
                {
                    SID* sid = reinterpret_cast<SID*>(&ace->SidStart);
                    integrityLevel = sid->SubAuthority[0];
                }
            }

            PWSTR stringSD;
            ULONG stringSDLen = 0;

            ConvertSecurityDescriptorToStringSecurityDescriptor(pSD, SDDL_REVISION_1, LABEL_SECURITY_INFORMATION, &stringSD, &stringSDLen); 

            if (pSD)
            {
                LocalFree(pSD);
            }
        }

        if (integrityLevel == 0x0000)
            return 0;
        else if (integrityLevel == 0x1000)
            return 1;
        else if (integrityLevel == 0x2000)
            return 2;
        else if (integrityLevel == 0x3000)
            return 3;
        else if (integrityLevel == 0x4000)
            return 4;
        else
            return -1;
    }

    bool SetFileIntegrityLevel(int level, LPCWSTR FileName)
    {
        LPCWSTR INTEGRITY_SDDL_SACL_W;
		INTEGRITY_SDDL_SACL_W = L"";
        if (level == 0)
            INTEGRITY_SDDL_SACL_W = L"S:(ML;;NR;;;LW)";
        else if (level == 1)
            INTEGRITY_SDDL_SACL_W = L"S:(ML;;NR;;;ME)";
        else if (level == 2)
            INTEGRITY_SDDL_SACL_W = L"S:(ML;;NR;;;HI)";

        DWORD dwErr = ERROR_SUCCESS;
        PSECURITY_DESCRIPTOR pSD = NULL;

        PACL pSacl = NULL;
        BOOL fSaclPresent = FALSE;
        BOOL fSaclDefaulted = FALSE;

        if (ConvertStringSecurityDescriptorToSecurityDescriptorW(
            INTEGRITY_SDDL_SACL_W, SDDL_REVISION_1, &pSD, NULL))
        {
            if (GetSecurityDescriptorSacl(pSD, &fSaclPresent, &pSacl,
                &fSaclDefaulted))
            {
                dwErr = SetNamedSecurityInfoW((LPWSTR)FileName,
                    SE_FILE_OBJECT, LABEL_SECURITY_INFORMATION,
                    NULL, NULL, NULL, pSacl);

                if (dwErr == ERROR_SUCCESS) {
                    return true;
                }
            }
            LocalFree(pSD);
            return false;
        }
        return false;
    }

}