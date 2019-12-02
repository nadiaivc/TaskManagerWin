using System;
using System.Diagnostics;
using System.Management;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Principal;
using ProcessPrivileges;


namespace Process_Note
{

    public class MyProcess
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Memory_usage { get; set; }
        public string Running_time { get; set; }
        public string Start_time { get; set; }
        public int ID_Parent { get; set; }
        public string Name_Parent { get; set; } //
        public string Path { get; set; }
        public string Owner { get; set; }
        public string SID { get; set; }
        public string Type { get; set; }
        public string Enviroment { get; set; }//

        public Process_Mitigation_DEP_Policy Dep = new Process_Mitigation_DEP_Policy();
        public Process_Mitigation_Type_Policy ASLR = new Process_Mitigation_Type_Policy();
        public string Library { get; set; }//
        public string Privileges { get; set; }//
        public string IntegrityLevel { get; set; }


        public MyProcess(Process process)
        {
            this.Name = process.ProcessName;
            this.Id = process.Id.ToString();
            this.Memory_usage = (process.PrivateMemorySize64 / 1024.0 / 1024.0).ToString("#,##0") + " MB";

            try
            {
                this.Start_time = process.StartTime.ToString();
            }
            catch 
            {
                this.Start_time = "Not available!";
            }


            //level
            try
            {
                this.IntegrityLevel = GetIntegrityLevel(process);
            }
            catch 
            {
                this.IntegrityLevel = "Not available!";
            }


            //.net
            try
            {
                if (IsDotNetProcess(process) == true)
                    this.Enviroment = ".NET";
                else
                    this.Enviroment = "native";
            }
            catch
            {
                this.Enviroment = "Not available!";
            }

            //id parent
            try
            {
                this.ID_Parent = GetParentProcess(process.Id);//ID родителя
            }
            catch 
            {
                this.Start_time = "Not available!";
            }


            //Parent Name
            try
            {
                Process giveMeYourName = Process.GetProcessById(this.ID_Parent);
                if (giveMeYourName != null)
                    this.Name_Parent = giveMeYourName.ProcessName;//Имя родителя
            }
            catch 
            {
                this.Name_Parent = "Not available!";
            }


            try
            {
                this.Privileges = GetPrivil(process);

            }
            catch 
            {
                this.Privileges = "Not available!";
            }


            //PATH
            try
            {
                this.Path = process.MainModule.FileName;
            }
            catch 
            {
                this.Path = "Not available!";
            }


            //SID and Owner
            try
            {
                ManagementObject oReturn = new ManagementObject("win32_process.handle='" + this.Id.ToString() + "'"); ;
                oReturn.Get();
                string[] OwnerInfo = new string[2];
                oReturn.InvokeMethod("GetOwner", (object[])OwnerInfo);
                this.Owner = OwnerInfo[0];

                string[] sid = new String[1];
                oReturn.InvokeMethod("GetOwnerSid", (object[])sid);
                this.SID = sid[0];
            }
            catch 
            {
                this.Owner = "Not available!";
                this.SID = "Not available!";
            }


            //ASLR DEP
            try
            {
                bool success = GetProcessMitigationPolicy(process.Handle, Process_Mitigation_Policy.ProcessDEPPolicy, ref this.Dep, Marshal.SizeOf(this.Dep));
                // информация по ASLR
                success = GetProcessMitigationPolicy(process.Handle, Process_Mitigation_Policy.ProcessASLRPolicy, ref this.ASLR, Marshal.SizeOf(this.ASLR));
            }
            catch { }


            //64 or 32 bits
            try
            {
                if (Is64Bit(process) == true)
                    this.Type = "64";
                else this.Type = "32";
            }
            catch 
            {
                this.Type = "Not available";
            }



            //.dll library
            try
            {
                string Dlls = "";

                for (int i = 0; i < process.Modules.Count; i++)
                {
                    if (process.Modules[i].ModuleName.EndsWith(".dll"))
                        Dlls += process.Modules[i].ModuleName + "; ";

                }
                if (Dlls.Length > 0)
                {
                    Dlls = Dlls.Substring(0, Dlls.Length - 1);
                }
                this.Library = Dlls;
            }
            catch 
            {

            }
        }

        enum TOKEN_INFORMATION_CLASS
        {
            TokenUser = 1,
            TokenGroups = 2,
            TokenPrivileges = 3,
            TokenOwner = 4,
            TokenPrimaryGroup = 5,
            TokenDefaultDacl = 6,
            TokenSource = 7,
            TokenType = 8,
            TokenImpersonationLevel = 9,
            TokenStatistics = 10,
            TokenRestrictedSids = 11,
            TokenSessionId = 12,
            TokenGroupsAndPrivileges = 13,
            TokenSessionReference = 14,
            TokenSandBoxInert = 15,
            TokenAuditPolicy = 16,
            TokenOrigin = 17,
            TokenElevationType = 18,
            TokenLinkedToken = 19,
            TokenElevation = 20,
            TokenHasRestrictions = 21,
            TokenAccessInformation = 22,
            TokenVirtualizationAllowed = 23,
            TokenVirtualizationEnabled = 24,
            TokenIntegrityLevel = 25,
            TokenUIAccess = 26,
            TokenMandatoryPolicy = 27,
            TokenLogonSid = 28,
            MaxTokenInfoClass = 29
        }

        const uint ERROR_INSUFFICIENT_BUFFER = 122;
        const long SECURITY_MANDATORY_LOW_RID = 0x00001000L;
        const long SECURITY_MANDATORY_MEDIUM_RID = 0x00002000L;
        const long SECURITY_MANDATORY_HIGH_RID = 0x00003000L;
        const long SECURITY_MANDATORY_SYSTEM_RID = 0x00004000L;


        [StructLayout(LayoutKind.Sequential)]
        struct TOKEN_MANDATORY_LABEL
        {
            public SID_AND_ATTRIBUTES Label;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct SID_AND_ATTRIBUTES
        {
            public IntPtr Sid;
            public int Attributes;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);

        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool OpenProcessToken(IntPtr ProcessHandle,
        TokenAccessLevels DesiredAccess,
        out IntPtr TokenHandle);

        [DllImport("advapi32.dll", SetLastError = true)]
        static extern bool GetTokenInformation(IntPtr TokenHandle,
        TOKEN_INFORMATION_CLASS TokenInformationClass,
        IntPtr TokenInformation,
        uint TokenInformationLength,
        out uint ReturnLength);
        [DllImport("kernel32.dll")]
        static extern IntPtr LocalAlloc(uint uFlags, UIntPtr uBytes);

        [DllImport("advapi32.dll", SetLastError = true)]
        static extern IntPtr GetSidSubAuthority(IntPtr pSid, int nSubAuthority);

        [DllImport("advapi32.dll", SetLastError = true)]
        static extern IntPtr GetSidSubAuthorityCount(IntPtr pSid);
        public static string GetIntegrityLevel(Process process)
        {
            try
            {
                IntPtr hProcess = process.Handle;
                IntPtr hToken;
                if (!OpenProcessToken(hProcess, TokenAccessLevels.MaximumAllowed, out hToken))
                    return "error";
                try
                {
                    uint dwLengthNeeded;
                    if (GetTokenInformation(hToken, TOKEN_INFORMATION_CLASS.TokenIntegrityLevel, IntPtr.Zero, 0, out dwLengthNeeded))
                        return "error";
                    uint dwError = (uint)Marshal.GetLastWin32Error();
                    if (dwError == ERROR_INSUFFICIENT_BUFFER)
                    {
                        IntPtr pTIL = Marshal.AllocHGlobal((int)dwLengthNeeded);
                        try
                        {
                            if (!GetTokenInformation(hToken, TOKEN_INFORMATION_CLASS.TokenIntegrityLevel, pTIL, dwLengthNeeded, out dwLengthNeeded))
                                return "error";

                            TOKEN_MANDATORY_LABEL TIL = (TOKEN_MANDATORY_LABEL)Marshal.PtrToStructure(pTIL, typeof(TOKEN_MANDATORY_LABEL));
                            IntPtr SubAuthorityCount = GetSidSubAuthorityCount(TIL.Label.Sid);
                            IntPtr IntegrityLevelPtr = GetSidSubAuthority(TIL.Label.Sid, Marshal.ReadByte(SubAuthorityCount) - 1);
                            int dwIntegrityLevel = Marshal.ReadInt32(IntegrityLevelPtr);
                            if (dwIntegrityLevel == SECURITY_MANDATORY_LOW_RID)
                                return "low";
                            else if (dwIntegrityLevel >= SECURITY_MANDATORY_MEDIUM_RID &&
                            dwIntegrityLevel < SECURITY_MANDATORY_HIGH_RID)
                                return "medium";
                            else if (dwIntegrityLevel >= SECURITY_MANDATORY_HIGH_RID &&
                            dwIntegrityLevel < SECURITY_MANDATORY_SYSTEM_RID)
                                return "high";
                            else if (dwIntegrityLevel >= SECURITY_MANDATORY_SYSTEM_RID)
                                return "system";
                            else
                                return "system";
                        }
                        finally
                        {
                            Marshal.FreeHGlobal(pTIL);
                        }
                    }
                }
                finally
                {
                    CloseHandle(hToken);
                }
                return "";
            }
            catch
            {
                return "system";
            }
        }

        public enum Process_Mitigation_Policy
        {
            ProcessDEPPolicy = 0,
            ProcessASLRPolicy = 1
        }

        public struct Process_Mitigation_DEP_Policy
        {
            public uint Flags;
            public bool Permanent;

            public bool Enable
            {
                get { return (Flags & 1) > 0; }
            }

            public bool DisableAtlThunkEmulation
            {
                get { return (Flags & 2) > 0; }
            }
        }

        public struct Process_Mitigation_Type_Policy
        {
            public uint Flags;

            public bool EnableBottomUpRandomization
            {
                get { return (Flags & 1) > 0; }
            }

            public bool EnableForceRelocateImage
            {
                get { return (Flags & 2) > 0; }
            }

            public bool EnableHighEntropy
            {
                get { return (Flags & 4) > 0; }
            }

            public bool DisallowStrippedImages
            {
                get { return (Flags & 8) > 0; }
            }
        }


        // Для ASLR
        [DllImport("kernel32.dll")]
        public static extern bool GetProcessMitigationPolicy(IntPtr hProcess,
            Process_Mitigation_Policy mitigationPolicy,
            ref Process_Mitigation_DEP_Policy lpBuffer,
            int dwLength);

        // Для DEP
        [DllImport("kernel32.dll")]
        public static extern bool GetProcessMitigationPolicy(
            IntPtr hProcess,
            Process_Mitigation_Policy mitigationPolicy,
            ref Process_Mitigation_Type_Policy lpBuffer,
            int dwLength);


        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]

        public static extern bool IsWow64Process([In] IntPtr hProcess, [Out] out bool lpSystemInfo);
        public static bool Is64Bit(Process process)
        {
            if (!Environment.Is64BitOperatingSystem)
                return false;
            // if this method is not available in your version of .NET, use GetNativeSystemInfo via P/Invoke instead
            bool isWow64;
            if (!IsWow64Process(process.Handle, out isWow64))
                throw new Win32Exception();
            return !isWow64;
        }
        private static int GetParentProcess(int Id)
        {
            int parentPid = 0;
            using (ManagementObject mo = new ManagementObject("win32_process.handle='" + Id.ToString() + "'"))
            {
                mo.Get();
                parentPid = Convert.ToInt32(mo["ParentProcessId"]);
            }
            return parentPid;
        }


        public static bool IsDotNetProcess(Process process)
        {
            /* var modules = process.Modules.Cast<ProcessModule>().Where(
                 m => m.ModuleName.StartsWith("mscor", StringComparison.InvariantCultureIgnoreCase));

             return modules.Any();*/
            return true;
        }


        private static string GetPrivil(Process process)
        {
            string allPriv = "";
            //Process p;
            //p = Process.GetProcessById(Int32.Parse(process.Id));
            PrivilegeAndAttributesCollection privileges = process.GetPrivileges();

            int maxPrivilegeLength = privileges.Max(privilege => privilege.Privilege.ToString().Length);

            foreach (PrivilegeAndAttributes privilegeAndAttributes in privileges)
            {
                Privilege privilege = privilegeAndAttributes.Privilege;
                PrivilegeState privilegeState = privilegeAndAttributes.PrivilegeState;

                if (privilegeState.ToString() == "Enabled")
                    allPriv += privilege+ "; ";
            }
            return allPriv;
        }


        
    }
}
