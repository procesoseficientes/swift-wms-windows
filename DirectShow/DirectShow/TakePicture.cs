using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DirectShow
{
    public partial class TakePicture : Form
    {
        [DllImport("DirectShow.dll")]
        public static extern void CreatePreview();
        [DllImport("DirectShow.dll")]
        public static extern void OpenVideo(IntPtr hInstance, int nXpos, int nYpos, int nXwidth, int nYhigh);
        [DllImport("DirectShow.dll")]
        public static extern void StartPreview();
        [DllImport("DirectShow.dll")]
        public static extern void StopPreview();
        [DllImport("DirectShow.dll")]
        public static extern void SetPreviewZoomInOut(int nLevel);
        [DllImport("DirectShow.dll")]
        public static extern void SetColorEnable(bool bEnable);
        [DllImport("DirectShow.dll")]
        public static extern void SetBrightness(int nLevel);
        [DllImport("DirectShow.dll")]
        public static extern int GetBrightnessLevel();
        [DllImport("DirectShow.dll")]
        public static extern void SetWhiteBalance(int nLevel);
        [DllImport("DirectShow.dll")]
        public static extern void SetResolution(string cszResolution);
        [DllImport("DirectShow.dll")]
        public static extern void CaptureView(string cszPath);
        [DllImport("DirectShow.dll")]
        public static extern void FlashFlag(bool bEnable);
        [DllImport("DirectShow.dll")]
        public static extern void CameraLed(bool bOnOff);
        [DllImport("DirectShow.dll")]
        public static extern void CloseVideo();

        [DllImport("DirectShow.dll")]
        public static extern void RecordVideo(IntPtr hInstance);

        [DllImport("coredll.dll", EntryPoint = "FindWindowW", SetLastError = true)]
        private static extern IntPtr FindWindowCE(string lpClassName, string lpWindowName);

        [DllImport("coredll.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd,
         IntPtr hWndInsertAfter,
         int x,
         int y,
         int cx,
         int cy,
         uint uFlags);

        // ReSharper disable once InconsistentNaming
        public const uint SWP_HIDEWINDOW = 0x80;


        bool _bClose = true, _bStart;

        private  const int X = 0;
        private  const int Y = 0;
        private  const int RecWidth = 480;
        private const int RecHeight = 700;
        string _filePath = @"\Flash Storage\unitech.jpg";


        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }

        public TakePicture()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            var hWnd = FindWindowCE("HHTaskBar", "");

            if (hWnd != IntPtr.Zero)
                SetWindowPos(hWnd, IntPtr.Zero, 0, 0, 0, 0, SWP_HIDEWINDOW);
            //return;
            CreatePreview();
            menuItemStop.Enabled = false;
            menuItemCapture.Enabled = false;
            menuItemZoom.Enabled = false;
            menuItemBright.Enabled = false;
            menuItemWBalance.Enabled = false;
            menuItemColor.Enabled = false;

            CameraLed(menuItemToggleLED.Checked);
            menuItemStart_Click(this, null);
        }

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            if (_bClose)
                Close();
            else
            {
                StopPreview();
                Close();
            }
            if (_bStart)
                CloseVideo();
            Application.Exit();
        }




        private void menuItemCapture_Click(object sender, EventArgs e)
        {
            FlashFlag(menuItemFlash.Checked);

            CaptureView(_filePath);
            menuItemExit_Click(this, null);
        }

        private void menuItemStart_Click(object sender, EventArgs e)
        {
            if (_bClose && _bStart)
            {
                StartPreview();
            }
            else
            {
                OpenVideo(Handle, X, Y, RecWidth, RecHeight);
                StartPreview();
            }

            _bClose = false;
            _bStart = true;
            menuItemStart.Enabled = false;
            menuItemStop.Enabled = true;
            menuItemCapture.Enabled = true;
            menuItemZoom.Enabled = true;
            menuItemBright.Enabled = true;
            menuItemWBalance.Enabled = true;
            menuItemColor.Enabled = true;
        }

        private void menuItemStop_Click(object sender, EventArgs e)
        {
            StopPreview();
            _bClose = true;
            menuItemStop.Enabled = false;
            menuItemStart.Enabled = true;
            menuItemCapture.Enabled = false;
            menuItemZoom.Enabled = false;
            menuItemBright.Enabled = false;
            menuItemWBalance.Enabled = false;
            menuItemColor.Enabled = false;
        }

        private void menuItemResolution_Click(object sender, EventArgs e)
        {
            foreach (MenuItem mi in menuItemResolution.MenuItems)
            {
                mi.Checked = false;
            }

            var temp = (MenuItem)sender;

            temp.Checked = true;

            SetResolution(temp.Text);
        }

        private void menuItemFlash_Click(object sender, EventArgs e)
        {
            var temp = (MenuItem)sender;

            temp.Checked = !temp.Checked;
        }

        private void menuItemToggleLED_Click(object sender, EventArgs e)
        {
            menuItemToggleLED.Checked = !menuItemToggleLED.Checked;
            CameraLed(menuItemToggleLED.Checked);
        }

        private void menuItemZoom_Click(object sender, EventArgs e)
        {
            foreach (MenuItem mi in menuItemZoom.MenuItems)
            {
                mi.Checked = false;
            }

            var temp = (MenuItem)sender;

            temp.Checked = true;

            SetPreviewZoomInOut(int.Parse(temp.Text.Substring(temp.Text.Length - 1)));
        }

        private void menuItemBright_Click(object sender, EventArgs e)
        {
            foreach (MenuItem mi in menuItemBright.MenuItems)
            {
                mi.Checked = false;
            }

            var temp = (MenuItem)sender;

            temp.Checked = true;

            SetBrightness(int.Parse(temp.Text));
        }

        private void menuItemWBalance_Click(object sender, EventArgs e)
        {
            foreach (MenuItem mi in menuItemWBalance.MenuItems)
            {
                mi.Checked = false;
            }

            var temp = (MenuItem)sender;

            temp.Checked = true;

            SetWhiteBalance(int.Parse(temp.Text));
        }

        private void menuItemColor_Click(object sender, EventArgs e)
        {
            menuItemColor.Checked = !menuItemColor.Checked;
            SetColorEnable(menuItemColor.Checked);
        }

        private void Form1_Closed(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}