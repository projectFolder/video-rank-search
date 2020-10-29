using OpenQA.Selenium.Html5;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApp1.Class;
using WindowsFormsApp1.CustomControl;
using WindowsFormsApp2.Class;
using WindowsFormsApp2.Properties;
using 네이버_플레이스_추출기.Class_Directory;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {

        #region [ Rounded Form Corenr ]

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int left,
            int top,
            int right,
            int bottom,
            int width,
            int height
        );

        #endregion

        #region [ Global Variable ]

        public bool On;
        public Point Pos;
        private Thread mThread;
        private String mThreadState = null;
        private ImageList lstImg;
        #endregion

        #region [ Form Move ]
        public MainForm()
        {
            InitializeComponent();
            this.Font = new Font(FontLibrary.Families[0], 9);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 18, 18));
            MouseDown += (o, e) => { if (e.Button == MouseButtons.Left) { On = true; Pos = e.Location; } };
            MouseMove += (o, e) => { if (On) Location = new Point(Location.X + (e.X - Pos.X), Location.Y + (e.Y - Pos.Y)); };
            MouseUp += (o, e) => { if (e.Button == MouseButtons.Left) { On = false; Pos = e.Location; } };
        }

        #endregion

        #region [ Form Minimize / Exit ] 
        private void button13_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
        private void button14_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region [ listView items Method ]

        #region 리스트뷰 항목삭제

        private void customListView2_KeyDown(object sender, KeyEventArgs e)
        {
            keyDown(sender, e);
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                for (int i = customListView2.Items.Count - 1; i >= 0; i--)
                {
                    if (customListView2.Items[i].Selected) customListView2.Items.RemoveAt(i);
                }
            }
        }
        #endregion

        #region 리스트뷰 항목별 색깔설정

        private void _setListColor(ListView customListView)
        {
            if (customListView.Items.Count % 2 != 0)
            {
                customListView.Items[customListView.Items.Count - 1].BackColor = Color.FromArgb(28, 30, 32);
            }
            else
            {
                customListView.Items[customListView.Items.Count - 1].BackColor = Color.FromArgb(31, 34, 37);
            }
        }

        #endregion

        #endregion

        #region [ imgList ]

        private ImageList setImglist()
        {
            lstImg = new ImageList();

            Image img = WindowsFormsApp2.Properties.Resources.checked_16px;

            lstImg.Images.Add(WindowsFormsApp2.Properties.Resources.checked_16px);
            lstImg.Images.Add(WindowsFormsApp2.Properties.Resources.cancel_16px);
            lstImg.ImageSize = new Size(16, 16);

            return lstImg;
        }

        #endregion

        #region [ Form Load & License ]
        private void Form1_Load(object sender, EventArgs e)
        {
            fileCheck fc = new fileCheck();
            //String pas = fileCheck.AESEncrypt256(Convert.ToString(fc.getHddNum()));
            String pas = "yRi8Uov7UVtXLbT9H9hnijHZbnCmm4fZDEzHcdyzDtI=";
            MessageBox.Show(fileCheck.AESDecrypt256(pas));

            switch (fc.License(this))
            {
                case fileCheck.checkState.Formally:
                    break;
                case fileCheck.checkState.ban:
                    fc.showMsg(pas);
                    Environment.Exit(Environment.ExitCode);
                    break;
                case fileCheck.checkState.Demo:
                    fc.showMsg(pas);
                    break;
            }

            CheckForIllegalCrossThreadCalls = false;
        }

        #endregion

        #region [ Open Forms ] 

        private void button11_Click(object sender, EventArgs e)
        {
            AccountForm Form = new AccountForm(this);
            Form.ShowDialog(this);
        }

        #endregion

        #region [ txt File Load ] 

        private void button8_Click(object sender, EventArgs e)
        {

            txtFile Tf = new txtFile();
            String outputStr = Tf.readFile();
            ListView customListView = customListView2;

            if (outputStr != null && outputStr.Length > 0)
            {
                foreach(String line in outputStr.Split('\n'))
                {
                    if (line.Contains("|"))
                    {
                        line.Replace("\r", String.Empty).Trim();
                        customListView.BeginUpdate();

                        ListViewItem item = new ListViewItem("");
                        item.SubItems.Add(Convert.ToString(customListView.Items.Count + 1));
                        item.SubItems.Add(line.Split('|')[0]);
                        item.SubItems.Add(line.Split('|')[1].Replace("\r", String.Empty).Trim());
                        item.SubItems.Add("대기중..");
                        item.SubItems.Add("대기중..");

                        customListView.Items.Add(item);

                        _setListColor(customListView);

                        customListView.EndUpdate();

                    }
                }
            }

        }

        #endregion

        #region [ Save txt File ] 

        private void button10_Click(object sender, EventArgs e)
        {

            StringBuilder stringBuilder = new StringBuilder();

            txtFile tF = new txtFile();
            foreach(ListViewItem item in customListView2.Items)
            {
                stringBuilder.Append(item.SubItems[2].Text + "|" + item.SubItems[3].Text + "|" + item.SubItems[4].Text + "|" + item.SubItems[5].Text);
            }

            tF.saveFile(stringBuilder.ToString());
        }

        #endregion

        #region [ Check WorkState ]

        private bool checkState()
        {
            if (customListView2.Items.Count < 1)
            {
                MessageBox.Show("검색하실 키워드와 제목을 추가해주세요.", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion

        #region [ Work Start/Stop ]

        private void button2_Click(object sender, EventArgs e)
        {
            // 작업시작
            if (mThreadState == null && checkState() == true)
            {
                button2.Enabled = false;
                button1.Enabled = true;
                mThread = new Thread(Run);
                mThread.Start();
                mThreadState = "Start";
            }
            else if(mThreadState == "Start")
            {
                mThread.Resume();
                mThreadState = "Resume";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 작업중지
            if (mThread != null)
            {
                button1.Enabled = false;
                button2.Enabled = true;
                mThread.Suspend();
                mThreadState = "pause";
            }
        }

        #endregion

        #region [ Run ]

        public void Run()
        {
            for (int i = 0; i < customListView2.Items.Count; i++)
            {

                customListView2.Items[i].Selected = true;

                String searchKeyword = customListView2.Items[i].SubItems[2].Text;
                String searchUrl = customListView2.Items[i].SubItems[3].Text;

                HttpWebRequetClass http = new HttpWebRequetClass(this);

                var rankUrl = http.getRank(searchKeyword, searchUrl);

                customListView2.Items[i].SubItems[4].Text = rankUrl.Item1;
                customListView2.Items[i].SubItems[5].Text = rankUrl.Item1;

                customListView2.Items[i].Selected = false;
            }

            button2.Enabled = true;
            button1.Enabled = false;

            label4.Text = "모든 작업이 완료되었습니다.";

            mThreadState = null;
            mThread.Abort();

            MessageBox.Show("모든 작업이 완료되었습니다.", "작업완료",MessageBoxButtons.OK, MessageBoxIcon.Information);

        }



        #endregion

        private void button4_Click(object sender, EventArgs e)
        {
                saveExcel se = new saveExcel(customListView2);
                se.excelSave();
        }
    }
}

