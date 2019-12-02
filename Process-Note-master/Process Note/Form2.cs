using System;
using System.Diagnostics;
using System.Management;
using System.Windows.Forms;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using ProcessPrivileges;

namespace Process_Note
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public Process process;
        public void showAll(string All, string ID)
        {
            process = Process.GetProcessById(Convert.ToInt32(ID));
            if (All.Contains(checkBox1.Text) == true)
            checkBox1.Checked = true;
            if (All.Contains(checkBox2.Text) == true)
                checkBox2.Checked = true;
            if (All.Contains(checkBox3.Text) == true)
                checkBox3.Checked = true;
            if (All.Contains(checkBox4.Text) == true)
                checkBox4.Checked = true;
            if (All.Contains(checkBox5.Text) == true)
                checkBox5.Checked = true;
            if (All.Contains(checkBox6.Text) == true)
                checkBox6.Checked = true;
            if (All.Contains(checkBox7.Text) == true)
                checkBox7.Checked = true;
            if (All.Contains(checkBox8.Text) == true)
                checkBox8.Checked = true;
            if (All.Contains(checkBox9.Text) == true)
                checkBox9.Checked = true;
            if (All.Contains(checkBox10.Text) == true)
                checkBox10.Checked = true;
            if (All.Contains(checkBox11.Text) == true)
                checkBox11.Checked = true;
            if (All.Contains(checkBox12.Text) == true)
                checkBox12.Checked = true;
            if (All.Contains(checkBox13.Text) == true)
                checkBox13.Checked = true;
            if (All.Contains(checkBox14.Text) == true)
                checkBox14.Checked = true;
            if (All.Contains(checkBox15.Text) == true)
                checkBox15.Checked = true;
            if (All.Contains(checkBox16.Text) == true)
                checkBox16.Checked = true;
            if (All.Contains(checkBox17.Text) == true)
                checkBox17.Checked = true;
            if (All.Contains(checkBox18.Text) == true)
                checkBox18.Checked = true;
            if (All.Contains(checkBox19.Text) == true)
                checkBox19.Checked = true;
            if (All.Contains(checkBox20.Text) == true)
                checkBox20.Checked = true;
        }
       
        private void Click1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                try
                {  process.DisablePrivilege(Privilege.ChangeNotify); }
                catch
                {  checkBox1.Checked = true; }
            }
            else
            {
                try
                { process.EnablePrivilege(Privilege.ChangeNotify); }
                catch
                { checkBox1.Checked = false; }
            }

        }

        private void Click2(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                try
                { process.DisablePrivilege(Privilege.Security); }
                catch
                { checkBox2.Checked = true; }
            }
            else
            {
                try
                { process.EnablePrivilege(Privilege.Security); }
                catch
                { checkBox2.Checked = false; }
            }

        }

        private void Click3(object sender, EventArgs e)
        {
            if (checkBox3.Checked == false)
            {
                try
                { process.DisablePrivilege(Privilege.Backup); }
                catch
                { checkBox3.Checked = true; }
            }
            else
            {
                try
                { process.EnablePrivilege(Privilege.Backup); }
                catch
                { checkBox3.Checked = false; }
            }

        }

        private void Click4(object sender, EventArgs e)
        {
            if (checkBox4.Checked == false)
            {
                try
                { process.DisablePrivilege(Privilege.Restore); }
                catch
                { checkBox4.Checked = true; }
            }
            else
            {
                try
                { process.EnablePrivilege(Privilege.Restore); }
                catch
                { checkBox4.Checked = false; }
            }

        }

        private void Click5(object sender, EventArgs e)
        {
            if (checkBox5.Checked == false)
            {
                try
                { process.DisablePrivilege(Privilege.SystemTime); }
                catch
                { checkBox5.Checked = true; }
            }
            else
            {
                try
                { process.EnablePrivilege(Privilege.SystemTime); }
                catch
                { checkBox5.Checked = false; }
            }

        }

        private void Click6(object sender, EventArgs e)
        {
            {
                if (checkBox6.Checked == false)
                {
                    try
                    { process.DisablePrivilege(Privilege.Shutdown); }
                    catch
                    { checkBox6.Checked = true; }
                }
                else
                {
                    try
                    { process.EnablePrivilege(Privilege.Shutdown); }
                    catch
                    { checkBox6.Checked = false; }
                }

            }
        }

        private void Click7(object sender, EventArgs e)
        {
            {
                if (checkBox7.Checked == false)
                {
                    try
                    { process.DisablePrivilege(Privilege.RemoteShutdown); }
                    catch
                    { checkBox7.Checked = true; }
                }
                else
                {
                    try
                    { process.EnablePrivilege(Privilege.RemoteShutdown); }
                    catch
                    { checkBox7.Checked = false; }
                }

            }
        }

        private void Click8(object sender, EventArgs e)
        {
            {
                if (checkBox8.Checked == false)
                {
                    try
                    { process.DisablePrivilege(Privilege.TakeOwnership); }
                    catch
                    { checkBox8.Checked = true; }
                }
                else
                {
                    try
                    { process.EnablePrivilege(Privilege.TakeOwnership); }
                    catch
                    { checkBox8.Checked = false; }
                }

            }
        }

        private void Click9(object sender, EventArgs e)
        {
            {
                if (checkBox9.Checked == false)
                {
                    try
                    { process.DisablePrivilege(Privilege.Debug); }
                    catch
                    { checkBox9.Checked = true; }
                }
                else
                {
                    try
                    { process.EnablePrivilege(Privilege.Debug); }
                    catch
                    { checkBox9.Checked = false; }
                }

            }
        }
        private void Click10(object sender, EventArgs e)
        {
            {
                if (checkBox10.Checked == false)
                {
                    try
                    { process.DisablePrivilege(Privilege.SystemEnvironment); }
                    catch
                    { checkBox10.Checked = true; }
                }
                else
                {
                    try
                    { process.EnablePrivilege(Privilege.SystemEnvironment); }
                    catch
                    { checkBox10.Checked = false; }
                }

            }
        }
        private void Click11(object sender, EventArgs e)
        {
            {
                if (checkBox11.Checked == false)
                {
                    try
                    { process.DisablePrivilege(Privilege.SystemProfile); }
                    catch
                    { checkBox11.Checked = true; }
                }
                else
                {
                    try
                    { process.EnablePrivilege(Privilege.SystemProfile); }
                    catch
                    { checkBox11.Checked = false; }
                }

            }
        }
        private void Click12(object sender, EventArgs e)
        {
            {
                if (checkBox12.Checked == false)
                {
                    try
                    { process.DisablePrivilege(Privilege.ProfileSingleProcess); }
                    catch
                    { checkBox12.Checked = true; }
                }
                else
                {
                    try
                    { process.EnablePrivilege(Privilege.ProfileSingleProcess); }
                    catch
                    { checkBox12.Checked = false; }
                }

            }
        }
        private void Click13(object sender, EventArgs e)
        {
            {
                if (checkBox13.Checked == false)
                {
                    try
                    { process.DisablePrivilege(Privilege.IncreaseBasePriority); }
                    catch
                    { checkBox13.Checked = true; }
                }
                else
                {
                    try
                    { process.EnablePrivilege(Privilege.IncreaseBasePriority); }
                    catch
                    { checkBox13.Checked = false; }
                }

            }
        }

        private void Click14(object sender, EventArgs e)
        {
            {
                if (checkBox14.Checked == false)
                {
                    try
                    { process.DisablePrivilege(Privilege.LoadDriver); }
                    catch
                    { checkBox14.Checked = true; }
                }
                else
                {
                    try
                    { process.EnablePrivilege(Privilege.LoadDriver); }
                    catch
                    { checkBox14.Checked = false; }
                }

            }
        }

        private void Click15(object sender, EventArgs e)
        {
            {
                if (checkBox15.Checked == false)
                {
                    try
                    { process.DisablePrivilege(Privilege.CreatePageFile); }
                    catch
                    { checkBox15.Checked = true; }
                }
                else
                {
                    try
                    { process.EnablePrivilege(Privilege.CreatePageFile); }
                    catch
                    { checkBox15.Checked = false; }
                }

            }
        }

        private void Click16(object sender, EventArgs e)
        {
            {
                if (checkBox16.Checked == false)
                {
                    try
                    { process.DisablePrivilege(Privilege.IncreaseQuota); }
                    catch
                    { checkBox16.Checked = true; }
                }
                else
                {
                    try
                    { process.EnablePrivilege(Privilege.IncreaseQuota); }
                    catch
                    { checkBox16.Checked = false; }
                }

            }
        }

        private void Click17(object sender, EventArgs e)
        {
            {
                if (checkBox17.Checked == false)
                {
                    try
                    { process.DisablePrivilege(Privilege.Undock); }
                    catch
                    { checkBox17.Checked = true; }
                }
                else
                {
                    try
                    { process.EnablePrivilege(Privilege.Undock); }
                    catch
                    { checkBox17.Checked = false; }
                }

            }
        }

        private void Click18(object sender, EventArgs e)
        {
            {
                if (checkBox18.Checked == false)
                {
                    try
                    { process.DisablePrivilege(Privilege.ManageVolume); }
                    catch
                    { checkBox18.Checked = true; }
                }
                else
                {
                    try
                    { process.EnablePrivilege(Privilege.ManageVolume); }
                    catch
                    { checkBox18.Checked = false; }
                }

            }
        }

        private void Click19(object sender, EventArgs e)
        {
            {
                if (checkBox19.Checked == false)
                {
                    try
                    { process.DisablePrivilege(Privilege.Impersonate); }
                    catch
                    { checkBox19.Checked = true; }
                }
                else
                {
                    try
                    { process.EnablePrivilege(Privilege.Impersonate); }
                    catch
                    { checkBox19.Checked = false; }
                }

            }
        }

        private void Click20(object sender, EventArgs e)
        {
            {
                if (checkBox20.Checked == false)
                {
                    try
                    { process.DisablePrivilege(Privilege.CreateGlobal); }
                    catch
                    { checkBox20.Checked = true; }
                }
                else
                {
                    try
                    { process.EnablePrivilege(Privilege.CreateGlobal); }
                    catch
                    { checkBox20.Checked = false; }
                }

            }
        }
    }
}
