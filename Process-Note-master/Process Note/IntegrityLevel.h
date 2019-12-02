#include <stdexcept>
#include <iostream>
#include <windows.h>
#include <Aclapi.h>
#include <WinError.h>
#include <Sddl.h>
#include <tchar.h>
#include <winnt.h>

using namespace std;

namespace IntegrityLevel
{
    extern "C" { __declspec(dllexport) int GetFileIntegrityLevel(LPCWSTR FileName); }
    extern "C" { __declspec(dllexport) bool SetFileIntegrityLevel(int level, LPCWSTR FileName); }
}