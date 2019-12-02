using System;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Management;

namespace Process_Note
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        //при запуске формы аккаунт владельца файла запишем в текстбокс аккаунта
        private void set_account(object sender, EventArgs e)
        {
            //получим текущий аккаунт
            var File_Security = File.GetAccessControl(this.Tag.ToString());//аргумент - путь к файлу
            var SID = File_Security.GetOwner(typeof(SecurityIdentifier));
            var Owner = SID.Translate(typeof(NTAccount));
            account.Text = Owner.ToString();
            var fileInfo = new FileInfo(this.Tag.ToString());
            // get the ACL of the directory
            var fileSec = fileInfo.GetAccessControl();
            // remove inheritance, copying all entries so that they are direct ACEs
            fileSec.SetAccessRuleProtection(true, true);
            // do the operation on the directory
            fileInfo.SetAccessControl(fileSec);
        }

        //ADD ACL (аккаунт из текстбокса аккаунта)
        private void Button1_Click(object sender, EventArgs e)
        {
            //добавляем запись
            if (acl.Text == "AppendData")
                AddFileSecurity(this.Tag.ToString(), account.Text/*@"BUILTIN\Пользователи"*/, FileSystemRights.AppendData, AccessControlType.Allow);
            else if (acl.Text == "ChangePermissions")
                AddFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.ChangePermissions, AccessControlType.Allow);
            else if (acl.Text == "CreateDirectories")
                AddFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.CreateDirectories, AccessControlType.Allow);
            else if (acl.Text == "CreateFiles")
                AddFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.CreateFiles, AccessControlType.Allow);
            else if (acl.Text == "Delete")
                AddFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.Delete, AccessControlType.Allow);
            else if (acl.Text == "DeleteSubdirectoriesAndFiles")
                AddFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.DeleteSubdirectoriesAndFiles, AccessControlType.Allow);
            else if (acl.Text == "ExecuteFile")
                AddFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.ExecuteFile, AccessControlType.Allow);
            else if (acl.Text == "FullControl")
                AddFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.FullControl, AccessControlType.Allow);
            else if (acl.Text == "ListDirectory")
                AddFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.ListDirectory, AccessControlType.Allow);
            else if (acl.Text == "Modify")
                AddFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.Modify, AccessControlType.Allow);
            else if (acl.Text == "Read")
                AddFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.Read, AccessControlType.Allow);
            else if (acl.Text == "ReadAndExecute")
                AddFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.ReadAndExecute, AccessControlType.Allow);
            else if (acl.Text == "ReadAttributes")
                AddFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.ReadAttributes, AccessControlType.Allow);
            else if (acl.Text == "ReadData")
                AddFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.ReadData, AccessControlType.Allow);
            else if (acl.Text == "ReadExtendedAttributes")
                AddFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.ReadExtendedAttributes, AccessControlType.Allow);
            else if (acl.Text == "ReadPermissions")
                AddFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.ReadPermissions, AccessControlType.Allow);
            else if (acl.Text == "Synchronize")
                AddFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.Synchronize, AccessControlType.Allow);
            else if (acl.Text == "TakeOwnership")
                AddFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.TakeOwnership, AccessControlType.Allow);
            else if (acl.Text == "Traverse")
                AddFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.Traverse, AccessControlType.Allow);
            else if (acl.Text == "Write")
                AddFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.Write, AccessControlType.Allow);
            else if (acl.Text == "WriteAttributes")
                AddFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.WriteAttributes, AccessControlType.Allow);
            else if (acl.Text == "WriteData")
                AddFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.WriteData, AccessControlType.Allow);
            else if (acl.Text == "WriteExtendedAttributes")
                AddFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.WriteExtendedAttributes, AccessControlType.Allow);
            else
                MessageBox.Show("incorrect input (Right)!");
            return;
        }

        //DELETE ACL (аккаунт из текстбокса аккаунта)
        private void Button2_Click(object sender, EventArgs e)
        {
            //получим текущий аккаунт
            var File_Security = File.GetAccessControl(this.Tag.ToString());//аргумент - путь к файлу
            var SID = File_Security.GetOwner(typeof(SecurityIdentifier));
            var Owner = SID.Translate(typeof(NTAccount));
            //удаляем запись
            if (acl.Text == "AppendData")
                RemoveFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.AppendData, AccessControlType.Allow);
            else if (acl.Text == "ChangePermissions")
                RemoveFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.ChangePermissions, AccessControlType.Allow);
            else if (acl.Text == "CreateDirectories")
                RemoveFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.CreateDirectories, AccessControlType.Allow);
            else if (acl.Text == "CreateFiles")
                RemoveFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.CreateFiles, AccessControlType.Allow);
            else if (acl.Text == "Delete")
                RemoveFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.Delete, AccessControlType.Allow);
            else if (acl.Text == "DeleteSubdirectoriesAndFiles")
                RemoveFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.DeleteSubdirectoriesAndFiles, AccessControlType.Allow);
            else if (acl.Text == "ExecuteFile")
                RemoveFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.ExecuteFile, AccessControlType.Allow);
            else if (acl.Text == "FullControl")
                RemoveFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.FullControl, AccessControlType.Allow);
            else if (acl.Text == "ListDirectory")
                RemoveFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.ListDirectory, AccessControlType.Allow);
            else if (acl.Text == "Modify")
                RemoveFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.Modify, AccessControlType.Allow);
            else if (acl.Text == "Read")
                RemoveFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.Read, AccessControlType.Allow);
            else if (acl.Text == "ReadAndExecute")
                RemoveFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.ReadAndExecute, AccessControlType.Allow);
            else if (acl.Text == "ReadAttributes")
                RemoveFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.ReadAttributes, AccessControlType.Allow);
            else if (acl.Text == "ReadData")
                RemoveFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.ReadData, AccessControlType.Allow);
            else if (acl.Text == "ReadExtendedAttributes")
                RemoveFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.ReadExtendedAttributes, AccessControlType.Allow);
            else if (acl.Text == "ReadPermissions")
                RemoveFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.ReadPermissions, AccessControlType.Allow);
            else if (acl.Text == "Synchronize")
                RemoveFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.Synchronize, AccessControlType.Allow);
            else if (acl.Text == "TakeOwnership")
                RemoveFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.TakeOwnership, AccessControlType.Allow);
            else if (acl.Text == "Traverse")
                RemoveFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.Traverse, AccessControlType.Allow);
            else if (acl.Text == "Write")
                RemoveFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.Write, AccessControlType.Allow);
            else if (acl.Text == "WriteAttributes")
                RemoveFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.WriteAttributes, AccessControlType.Allow);
            else if (acl.Text == "WriteData")
                RemoveFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.WriteData, AccessControlType.Allow);
            else if (acl.Text == "WriteExtendedAttributes")
                RemoveFileSecurity(this.Tag.ToString(), account.Text, FileSystemRights.WriteExtendedAttributes, AccessControlType.Allow);
            else
                MessageBox.Show("incorrect input (Right)!");
            return;
        }

        // Adds an ACL entry on the specified file for the specified account.
        public static void AddFileSecurity(string FileName, string Account, FileSystemRights Rights, AccessControlType ControlType)
        {
            try
            {
                // Create a new FileInfo object.
                FileInfo fInfo = new FileInfo(FileName);
                // Get a FileSecurity object that represents the 
                // current security settings.
                FileSecurity fSecurity = fInfo.GetAccessControl();
                // Add the FileSystemAccessRule to the security settings. 
                fSecurity.AddAccessRule(new FileSystemAccessRule(Account, Rights, ControlType));
                // Set the new access settings.
                fInfo.SetAccessControl(fSecurity);
            }
            catch { MessageBox.Show("incorrect input (Account)!"); }
        }

        // Removes an ACL entry on the specified file for the specified account.
        public static void RemoveFileSecurity(string fileName, string account, FileSystemRights rights, AccessControlType controlType)
        {
            try
            {
                // Get a FileSecurity object that represents the
                // current security settings.
                FileSecurity fSecurity = File.GetAccessControl(fileName);
                // Remove the FileSystemAccessRule from the security settings.
                fSecurity.RemoveAccessRule(new FileSystemAccessRule(account, rights, controlType));
                // Set the new access settings.
                File.SetAccessControl(fileName, fSecurity);
            }
            catch { MessageBox.Show("incorrect input (Account)!"); }
        }
    }
}
