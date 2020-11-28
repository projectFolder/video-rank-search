using ExtendedControls;
using hanbat_project.Class;
using hanbat_project.CustomClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hanbat_project
{
    public partial class Main : Form
    {

        #region [ Gloval Variable ]

        [DllImport("user32.dll")]

        static public extern bool ShowScrollBar(System.IntPtr hWnd, int wBar, bool bShow);

        private const uint SB_HORZ = 0;

        private const uint SB_VERT = 1;

        private const uint ESB_DISABLE_BOTH = 0x3;

        private const uint ESB_ENABLE_BOTH = 0x0;

        private bool On;
        private Point Pos;

        HttpWebRequestClass http;
        Thread mThread;

        #endregion

        #region [ Form Method ]

        #region [ Form Load ]

        private void Main_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region [ Form Constructor ]

        public Main()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            MouseDown += (o, e) => { if (e.Button == MouseButtons.Left) { On = true; Pos = e.Location; } };
            MouseMove += (o, e) => { if (On) Location = new Point(Location.X + (e.X - Pos.X), Location.Y + (e.Y - Pos.Y)); };
            MouseUp += (o, e) => { if (e.Button == MouseButtons.Left) { On = false; Pos = e.Location; } };
        }

        #endregion

        #region [ Form Minimize / Exit ] 
        private void button13_Click(object sender, EventArgs e)
        {
            exitChrome();
            Environment.Exit(Environment.ExitCode);
        }
        private void button14_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #endregion

        #region [ Kill Chrome Process ] 

        public static void exitChrome()
        {

            Process[] Chrome = Process.GetProcessesByName("chromedriver");

            foreach (var ch in Chrome)
            {
                ch.Kill();
            }

        }

        #endregion

        #region [ methods ]

        #region addItem

        public void addItems(CustomListView customlistview, String[] _vaules)
        {
            customlistview.BeginUpdate();

            ListViewItem _item = new ListViewItem(_vaules);
            customlistview.Items.Add(_item);

            if (customlistview.Items.Count * 35 >= customlistview.Height) customlistview.Columns[customlistview.Columns.Count - 1].Width = 0;

            customlistview.EndUpdate();
        }

        #endregion

        #endregion

        #region [ Run ]

        private void Run()
        {

        }



        #endregion

        private void button9_Click(object sender, EventArgs e)
        {

            addItems(customListView1, new string[] { "", "1", "bana_na21", "tmxosem123!!" ,"" });
            addItems(customListView1, new string[] { "", "1", "bana_na21", "tmxosem123!!" ,"" });
            addItems(customListView1, new string[] { "", "1", "bana_na21", "tmxosem123!!" ,"" });

            ShowScrollBar(this.customListView1.Handle, (int)ESB_DISABLE_BOTH, false);

        }
    }
}

