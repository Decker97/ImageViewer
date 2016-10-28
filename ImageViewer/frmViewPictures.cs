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
    public partial class frmViewPictures : Form
    {
        public frmViewPictures()
        {
            InitializeComponent();
        }

        private decimal interval;
        private string directory;
        System.Timers.Timer timer;
        private string FileName;
        private int CurrentIndex = -1;
        private int MIN_X = -32000;
        private static List<string> SlidesShown = new List<string>();
        private string WindowTitle = "";

        private void frmViewPictures_Load(object sender, EventArgs e)
        {
            interval = frmPreferences.GetInterval();
            directory = frmPreferences.GetDirectory();
            WindowTitle = "Images - " + directory;
            SetWindowTitle();

            //Start the timer:
            timer = new System.Timers.Timer();
            timer.Interval = (int)(interval * 1000);
            timer.Elapsed += ShowNewImage;
            timer.Enabled = true;
            timer.Start();
            ShowNewImage(null, null);
            RestoreWindowState(this, "ImageWindow");
        }

        public void ShowNewImage(object sender, System.Timers.ElapsedEventArgs e)
        {
            interval = frmPreferences.GetInterval();
            directory = frmPreferences.GetDirectory();
            timer.Interval = (int)(interval* 1000);

            var filteredFiles = System.IO.Directory
                .EnumerateFiles(directory) 
                .Where(file => file.ToLower().EndsWith(".jpg")
                    || file.ToLower().EndsWith(".bmp")
                    || file.ToLower().EndsWith(".jpeg")
                    || file.ToLower().EndsWith(".png")
                    )
                .ToList();

            if (filteredFiles.Count == 0)
            {
                this.Text = "No image files found in directory: " + directory;
                return;
            }


            if (frmPreferences.GetIsRandom())
            {
                if (CurrentIndex < SlidesShown.Count && CurrentIndex > 0)
                {
                    ShowImage(SlidesShown[CurrentIndex]);
                    CurrentIndex++;
                    return;
                }
                Random rnd = new Random();
                int r = rnd.Next(filteredFiles.Count);
                string FileSpec = filteredFiles[r];
                if (SlidesShown.Contains(FileSpec))     //Get a new image, already showed this one.
                {
                    if (SlidesShown.Count >= filteredFiles.Count)  //Reached the end of the images, reset the show:
                    {
                        SlidesShown.Clear();
                        CurrentIndex = 0;
                    }
                    else
                    {
                        ShowNewImage(null, null);  //Call this function again to get a new image.
                        return;
                    }
                }
                ShowImage(FileSpec);
                SlidesShown.Add(filteredFiles[r]);
                CurrentIndex++;
            }
            else
            {
                if (CurrentIndex < SlidesShown.Count && CurrentIndex > 0)
                {
                    ShowImage(SlidesShown[CurrentIndex]);
                    CurrentIndex++;
                    return;
                }
                if (CurrentIndex >= filteredFiles.Count || CurrentIndex < 0)
                {
                    SlidesShown.Clear();
                    CurrentIndex = 0;       //Reset to beginning for sequential.
                }
                ShowImage(filteredFiles[CurrentIndex]);
                SlidesShown.Add(filteredFiles[CurrentIndex]);
                CurrentIndex++;
            }

        }

        private void ShowImage(string filename)
        {
            FileName = filename;  //Set for resize;
            this.pb1.Image = FixedSize(new Bitmap(filename), this.Width, this.Height, false);
        }

        public static System.Drawing.Image FixedSize(Image image, int Width, int Height, bool needToFill)
        {
            int sourceWidth = image.Width;
            int sourceHeight = image.Height;
            int sourceX = 0;
            int sourceY = 0;
            double destX = 0;
            double destY = 0;

            double nScale = 0;
            double nScaleW = 0;
            double nScaleH = 0;

            nScaleW = ((double)Width / (double)sourceWidth);
            nScaleH = ((double)Height / (double)sourceHeight);
            if (!needToFill)
            {
                nScale = Math.Min(nScaleH, nScaleW);
            }
            else
            {
                nScale = Math.Max(nScaleH, nScaleW);
                destY = (Height - sourceHeight * nScale) / 2;
                destX = (Width - sourceWidth * nScale) / 2;
            }

            //if (nScale > 1)
            //    nScale = 1;

            int destWidth = (int)Math.Round(sourceWidth * nScale);
            int destHeight = (int)Math.Round(sourceHeight * nScale);

            System.Drawing.Bitmap bmPhoto = null;
            try
            {
                bmPhoto = new System.Drawing.Bitmap(destWidth + (int)Math.Round(2 * destX), destHeight + (int)Math.Round(2 * destY));
            }
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format("destWidth:{0}, destX:{1}, destHeight:{2}, desxtY:{3}, Width:{4}, Height:{5}",
                    destWidth, destX, destHeight, destY, Width, Height), ex);
            }
            using (System.Drawing.Graphics grPhoto = System.Drawing.Graphics.FromImage(bmPhoto))
            {
                grPhoto.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
                grPhoto.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.Default;
                grPhoto.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;

                Rectangle to = new System.Drawing.Rectangle((int)Math.Round(destX), (int)Math.Round(destY), destWidth, destHeight);
                Rectangle from = new System.Drawing.Rectangle(sourceX, sourceY, sourceWidth, sourceHeight);
                //Console.WriteLine("From: " + from.ToString());
                //Console.WriteLine("To: " + to.ToString());
                grPhoto.DrawImage(image, to, from, System.Drawing.GraphicsUnit.Pixel);

                return bmPhoto;
            }
        }

        private void frmViewPictures_Resize(object sender, EventArgs e)
        {
            this.pb1.Image = FixedSize(new Bitmap(FileName), this.Width, this.Height, false);
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPreferences f = new frmPreferences(false);
            f.ShowDialog();
            interval = frmPreferences.GetInterval();
            directory = frmPreferences.GetDirectory();
            timer.Interval = (int)(interval * 1000);
            WindowTitle = "Images - " + directory;
            SetWindowTitle();
        }

        delegate void SetTitleDelegate();

        private void SetWindowTitle()
        {
            if (this.InvokeRequired)
            {
                SetTitleDelegate d = new SetTitleDelegate(SetWindowTitle);
                this.Invoke(d);
            }
            else
            {
                if (Pause)
                    this.Text = WindowTitle + " (Paused) ";
                else
                    this.Text = WindowTitle;
                Application.DoEvents();
            }

        
        }

        private void frmViewPictures_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveWindowState(this, "ImageWindow");
        }


        private void SaveWindowState(System.Windows.Forms.Form f, string Key)
        {
            if (f.WindowState == FormWindowState.Maximized)
                SaveSetting("True", "Maximized");
            else
                SaveSetting("False", "Maximized");

            if (f.WindowState == FormWindowState.Minimized)
                SaveSetting("True", "Minimized");
            else
                SaveSetting("False", "Minimized");

            //Only save it if it is visible:
            if (f.Location.X > MIN_X)
            {
                SaveSetting(f.Location.X.ToString(), Key + "_X");
                SaveSetting(f.Location.Y.ToString(), Key + "_Y");
                SaveSetting(f.Width.ToString(), Key + "_Width");
                SaveSetting(f.Height.ToString(), Key + "_Height");
            }
        }

        private void SaveSetting(string SettingValue, string SettingKey)
        {
            frmPreferences.CreateAppBaseKey();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(frmPreferences.UserRegKey, true);
            regKey.SetValue(SettingKey, SettingValue);
        }

        private void RestoreWindowState(System.Windows.Forms.Form frm, string Key)
        {
            if (GetSetting("Maximized", "False").Tobool())
                frm.WindowState = FormWindowState.Maximized;

            if (GetSetting("Minimized", "False").Tobool())
                frm.WindowState = FormWindowState.Minimized;

            int x = GetSetting(Key + "_X", frm.Location.X.ToString()).ToInt();
            if (x > MIN_X)
            { 
                System.Drawing.Point p = new Point();
                p.X = GetSetting(Key + "_X", frm.Location.X.ToString()).ToInt();
                p.Y = GetSetting(Key + "_Y", frm.Location.Y.ToString()).ToInt();
                frm.Location = p;
                frm.Width = GetSetting(Key + "_Width", frm.Width.ToString()).ToInt();
                frm.Height = GetSetting(Key + "_Height", frm.Height.ToString()).ToInt();
            }
        }

        private string GetSetting(string Key, string Default)
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(frmPreferences.UserRegKey);
            if (regKey != null)
            {
                object val = regKey.GetValue(Key);
                if (val != null)
                    return val.ToString();
                else
                    return Default;
            }
            else
            {
                return Default;
            }
        }

        private bool Pause = false;

        private void TogglePause()
        {
            if (Pause)
            {
                UnpauseSlideshow();
            }
            else
            {
                PauseSlideshow();
            }
            SetWindowTitle();
        }

        private void UnpauseSlideshow()
        {
            //Start the timer:
            timer.Start();
            Pause = false;
            SetWindowTitle();
        }

        private void PauseSlideshow()
        {
            Pause = true;
            timer.Stop();
            SetWindowTitle();
        }

        private void PreviousSlide()
        {
            if (CurrentIndex >= 0)
            {
                CurrentIndex = CurrentIndex - 1;
                if (CurrentIndex >= 0)
                    ShowImage(SlidesShown[CurrentIndex]);
            }
        }

        private void NextSlide()
        {
            CurrentIndex = CurrentIndex + 1;
            if (CurrentIndex >= SlidesShown.Count)
            {
                CurrentIndex = CurrentIndex - 1;
                ShowNewImage(null, null);
            }
            else
            {
                ShowImage(SlidesShown[CurrentIndex]);
            }
        }

        private void frmViewPictures_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                TogglePause();
            }
            else if (e.KeyCode == Keys.Left)
            {
                PauseSlideshow();
                PreviousSlide();
            }
            else if (e.KeyCode == Keys.Right)
            {
                PauseSlideshow();
                NextSlide();
            }
            SetWindowTitle();
        }
    

    }
}
