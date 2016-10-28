using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ImageViewer
{
    public partial class frmPreferences : Form
    {
        public static decimal DefalutInterval = 30;
        public static string UserRegKey = "Software\\InsiteInternational\\ImageViewer\\1.0";
        public static RegistryKey BaseKey = Registry.CurrentUser;

        public frmPreferences(bool showStart)
        {
            InitializeComponent();
            if (!showStart)
            {
                this.btnStart.Visible = false;
            }
        }

        private void frmPreferences_Load(object sender, EventArgs e)
        {
            this.lblDirectory.Text = GetDirectory();
            this.nudInterval.Value = GetInterval();
            if (GetIsRandom())
                this.rbRnd.Checked = true;
            else
                this.rbSeq.Checked = true;
        }



        public static string GetDirectory()
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(UserRegKey);
            if (regKey != null)
            {
                object val = regKey.GetValue("Directory");
                if (val == null)
                    return "";
                return val.ToString();
            }
            else
            {
                return "";
            }
        }

        public static bool GetIsRandom()
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(UserRegKey);
            if (regKey != null)
            {
                object val = regKey.GetValue("Random");
                if (val != null)
                    return val.ToString().Tobool();
                else
                    return true;
            }
            else
            {
                return true;
            }
        }


        public static decimal GetInterval()
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(UserRegKey);
            if (regKey != null)
            {
                object val = regKey.GetValue("Interval");
                decimal dRet;
                if (val == null)
                    return DefalutInterval;
                if (decimal.TryParse(val.ToString(), out dRet))
                    return dRet;
                else
                    return DefalutInterval;
            }
            else
            {
                return DefalutInterval;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveValues();
            Close();
        }

        private void SaveValues()
        {
            SetInterval(this.nudInterval.Value);
            SetDirectory(this.lblDirectory.Text);
            SetRandom(this.rbRnd.Checked);
        }

        public static void CreateAppBaseKey()
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(UserRegKey);
            if (regKey == null)
            {
                BaseKey.CreateSubKey(UserRegKey);
            }
        }

        public static void SetInterval(decimal interval)
        {
            CreateAppBaseKey();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(UserRegKey, true);
            regKey.SetValue("Interval", interval);
        }

        public static void SetDirectory(string Directory)
        {
            CreateAppBaseKey();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(UserRegKey, true);
            regKey.SetValue("Directory", Directory);
        }

        public static void SetRandom(bool IsRandom)
        {
            CreateAppBaseKey();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(UserRegKey, true);
            regKey.SetValue("Random", IsRandom);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDirectory_Click(object sender, EventArgs e)
        {
            string folderPath = this.lblDirectory.Text;
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.SelectedPath = folderPath;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog1.SelectedPath;
            }
            this.lblDirectory.Text = folderPath;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            SaveValues();
            frmViewPictures f = new frmViewPictures();
            f.Show();
        }

    }
}
