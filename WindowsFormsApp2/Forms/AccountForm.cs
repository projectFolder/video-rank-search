using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WindowsFormsApp1.CustomControl;

namespace WindowsFormsApp1
{
    public partial class AccountForm : Form
    {
        #region Rounded Form Corenr

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

        #region Global Variable

        public bool On;
        public Point Pos;
        MainForm main;

        #endregion

        #region Form Move
        public AccountForm(MainForm frm)
        {
            InitializeComponent();
            main = frm;
            this.FormBorderStyle = FormBorderStyle.None;
            MouseDown += (o, e) => { if (e.Button == MouseButtons.Left) { On = true; Pos = e.Location; } };
            MouseMove += (o, e) => { if (On) Location = new Point(Location.X + (e.X - Pos.X), Location.Y + (e.Y - Pos.Y)); };
            MouseUp += (o, e) => { if (e.Button == MouseButtons.Left) { On = false; Pos = e.Location; } };
        }

        #endregion

        #region [ 프로그램 최소화/종료 ] 
        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        private void button6_Click(object sender, EventArgs e)
        {
             if (customTextbox3.val != "" && customTextbox4.val != "")
             {

                ListView customListView = main.customListView2;

                customListView.Update();

                ListViewItem item = new ListViewItem("");
                item.SubItems.Add(Convert.ToString(customListView.Items.Count + 1));
                item.SubItems.Add(customTextbox3.val);
                item.SubItems.Add(customTextbox4.val);
                item.SubItems.Add("대기중..");
                item.SubItems.Add("대기중..");

                customListView.Items.Add(item);

                if (customListView.Items.Count >= 14) customListView.Columns[4].Width = 67;
                    if ((Convert.ToDouble(customListView.Items.Count) % 2 == 0))
                    {
                        customListView.Items[customListView.Items.Count-1].BackColor = Color.FromArgb(26, 28, 30);
                    }
                    else
                    {
                        customListView.Items[customListView.Items.Count - 1].BackColor = Color.FromArgb(31, 34, 37);
                    }

                customListView.EndUpdate();

                customTextbox3.val = null;
                customTextbox4.val = null;

             }
        }

    }
}

