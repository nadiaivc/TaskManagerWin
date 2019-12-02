using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Security.AccessControl;
using System.Security.Principal;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Process_Note
{
        public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public MyProcess selectedProcess;
        List<MyProcess> myProcesses;
        public void Form1_Load(object sender, EventArgs e)
        {
            List<MyProcess> Processes = new List<MyProcess>();//список процессов
            Process[] processlist = Process.GetProcesses();//получаем процессы, узнаем кол-во
            foreach (Process theprocess in processlist)
            {
                Processes.Add(new MyProcess(theprocess));//все кидаем в свой список
            }
            var sorted = Processes.OrderBy(process => process.Name);//порядок по имени
            myProcesses = sorted.ToList();
            CreateListView1(myProcesses);
            CreateListView2();
            CreateListView3();
        }

        public void CreateListView1(List<MyProcess> sorted)
        {
            listView1.View = View.Details;
            listView1.Columns.Add("ID");
            listView1.Columns.Add("Name");
            listView1.Columns.Add("Path");
            listView1.Columns.Add("Type");
            listView1.Columns.Add("Owner name");
            listView1.Columns.Add("SID");
            listView1.Columns.Add("Library");
            listView1.Columns.Add("Memory Usage");
            listView1.Columns.Add("Start Time");
            listView1.Columns.Add("Name Parent");
            listView1.Columns.Add("ID Parent");
            listView1.Columns.Add("clr");
            listView1.Columns.Add("DEP/ASLR");

            foreach (MyProcess theprocess in sorted)
            {
                listView1.Items.Add(new ListViewItem(new string[] { theprocess.Id.ToString(), theprocess.Name, theprocess.Path, theprocess.Type, theprocess.Owner, theprocess.SID, theprocess.Library, theprocess.Memory_usage, theprocess.Start_time, theprocess.Name_Parent, theprocess.ID_Parent.ToString(), "", theprocess.Dep.Enable.ToString() + theprocess.ASLR.EnableBottomUpRandomization }));

            }
            for (int i = 0; i < 12; i++)
            {
                listView1.Columns[i].Width = 70;
            }

        }

        public void ListView1_Click(object sender, EventArgs e)
        {
            try
            {
                var firstSelectedItem = listView1.SelectedItems[0];//куда тыкнули
                selectedProcess = GetProcessFromId(firstSelectedItem.Text);

                AddNewItemListView2();
            }
            catch
            {

            }
        }


        public void CreateListView2()
        {
            listView2.View = View.Details;
            listView2.Columns.Add("Name");
            listView2.Columns.Add("Privileges");
            listView2.Columns.Add("Integrity level"); 

            listView2.GridLines = true;
            
            listView2.Columns[0].Width = 100;
            listView2.Columns[1].Width = 100;
            listView2.Columns[2].Width = 100;
        }


        public void AddNewItemListView2()
        {
            if (listView2.Items.Count >= 1)
            {
                listView2.Items.Remove(listView2.Items[0]);
            }
            if (selectedProcess != null)
            {
                listView2.Items.Add(new ListViewItem(new string[] { selectedProcess.Name, selectedProcess.Privileges, selectedProcess.IntegrityLevel }));


            }
            //textBox1.Text = "";
        }


        public MyProcess GetProcessFromId(string id)
        {
            foreach (MyProcess theprocess in myProcesses)
            {
                if(theprocess.Id.Equals(id))
                {
                    return theprocess;
                }
            }
            return null;
        }

        string Path_file= "";
        public void Button1_Click(object sender, EventArgs e)
        {
            Path_file = textBox1.Text;
            try
            {
            FileInfo fileInfo = new FileInfo(Path_file);
            FileSecurity fileSecurity = fileInfo.GetAccessControl();
            IdentityReference identityReference = fileSecurity.GetOwner(typeof(NTAccount));
            string acl ="";
            int IntegrityLevel_File =  GetFileIntegrityLevel(Path_file);
            string IntegrityLevel_File_str = "";
            if (IntegrityLevel_File == 0)
                IntegrityLevel_File_str = "Untrusted";
            else if (IntegrityLevel_File == 1)
                IntegrityLevel_File_str = "Low";
            else if (IntegrityLevel_File == 2)
                IntegrityLevel_File_str = "Medium";
            else if (IntegrityLevel_File == 3)
                IntegrityLevel_File_str = "High";
            else
                IntegrityLevel_File_str = "System";
            acl = GetDirectorySecurity(Path_file);
            ListView3(identityReference.Value, acl, IntegrityLevel_File_str);
            }
            catch
            {
                MessageBox.Show("Bad String");
            }

        }

        public void CreateListView3()
        {
            FileInfo.View = View.Details;
            FileInfo.Columns.Add("Owner");
            FileInfo.Columns.Add("ACL (Account, Type, Rights, Inherited)");
            FileInfo.Columns.Add("IntegrityLevel_File");

            FileInfo.GridLines = true;
            FileInfo.Columns[0].Width = 160;
            FileInfo.Columns[1].Width = 160;
            FileInfo.Columns[0].Width = 160;

        }


        public void ListView3(string owner, string acl, string IntegrityLevel_File_str)
        {
            if (FileInfo.Items.Count >= 1)
            {
                FileInfo.Items.Remove(FileInfo.Items[0]);
            }
            FileInfo.Items.Add(new ListViewItem(new string[] { owner, acl, IntegrityLevel_File_str }));
        }
        [DllImport("D:\\Загрузки\\Process-Note-master\\Process-Note-master\\Process Note\\Level.dll")]
        public static extern bool SetIntegrityLevel(int privilegeLevel, int ID);

        public void Low(object sender, EventArgs e)
        {
            SetIntegrityLevel(1, (Int32.Parse(selectedProcess.Id)));
        }

       
        private void Medium_Click(object sender, EventArgs e)
        {
            SetIntegrityLevel(2, (Int32.Parse(selectedProcess.Id)));

        }


        private void High_Click(object sender, EventArgs e)
        {
            SetIntegrityLevel(3, (Int32.Parse(selectedProcess.Id)));

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


        [DllImport("D:\\Загрузки\\Process-Note-master\\Process-Note-master\\Process Note\\IntegrityLevel.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetFileIntegrityLevel(string FileName);

        [DllImport("D:\\Загрузки\\Process-Note-master\\Process-Note-master\\Process Note\\IntegrityLevel.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetFileIntegrityLevel(int level, string FileName);

        

        static string GetDirectorySecurity(string Path_file)
        {
            string ACL = "";
                try
                {
                    FileInfo dInfo = new FileInfo(Path_file);
                    FileSecurity dSecurity = dInfo.GetAccessControl();
                    AuthorizationRuleCollection acl = dSecurity.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
                    foreach (FileSystemAccessRule ace in acl)
                    {
                        ACL +=  " // " + ace.IdentityReference.Value;//Account
                        ACL += ", " + ace.AccessControlType;//Type
                        ACL += ", "+ ace.FileSystemRights;//Rights
                        ACL += ", "+ ace.IsInherited;//Inherited
                   }
                }
                catch
                {
                return "";
            }
            return ACL;
        }
    

        private void Low_b_Click(object sender, EventArgs e)
        {
            SetFileIntegrityLevel(0, Path_file);
        }

        private void Medium_b_Click(object sender, EventArgs e)
        {
            SetFileIntegrityLevel(1, Path_file);
        }

        private void HIgh_b_Click(object sender, EventArgs e)
        {
            SetFileIntegrityLevel(2, Path_file);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form2 a = new Form2();
            a.Show();
            a.showAll(selectedProcess.Privileges, selectedProcess.Id);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            Form1_Load(null, null);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var fs = File.GetAccessControl(Path_file);
            var ntAccount = new NTAccount("DESKTOP-5OJNTK5", "Win10");
            fs.SetOwner(ntAccount);
            try
            {
                
                File.SetAccessControl(Path_file, fs);
            }
            catch 
            {
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Form3 Form33 = new Form3();
            Form33.Tag = Path_file;
            Form33.Show();

        }
    }




}



