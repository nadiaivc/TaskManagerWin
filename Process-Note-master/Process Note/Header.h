#include <windows.h>
#include <list>
#include <string>
#include <map>
#include <tlhelp32.h> // CreateToolhelp32Snapshot
#include <psapi.h>    // GetModuleFileNameEx
#include <sddl.h>     // ConvertSidToStringSid
#include <iostream>

using namespace std;

namespace Level
{
	extern "C" { __declspec(dllexport) bool SetIntegrityLevel(std::string privilegeLevel, int ID); }
}