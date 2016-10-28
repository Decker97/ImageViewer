using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageViewer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (string.IsNullOrEmpty(frmPreferences.GetDirectory()))
            {
                Application.Run(new frmPreferences(true));
            }
            else
            {
                Application.Run(new frmViewPictures());
            }
        }
    }
}
