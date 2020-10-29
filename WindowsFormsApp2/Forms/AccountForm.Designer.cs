namespace WindowsFormsApp1
{
    partial class AccountForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountForm));
            this.Button9 = new System.Windows.Forms.Button();
            this.Button12 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button13 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.customTextbox4 = new WindowsFormsApp1.CustomControl.CustomTextbox();
            this.customTextbox3 = new WindowsFormsApp1.CustomControl.CustomTextbox();
            this.SuspendLayout();
            // 
            // Button9
            // 
            this.Button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.Button9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button9.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Button9.ForeColor = System.Drawing.Color.LightGray;
            this.Button9.Location = new System.Drawing.Point(1071, 4);
            this.Button9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Button9.Name = "Button9";
            this.Button9.Size = new System.Drawing.Size(27, 28);
            this.Button9.TabIndex = 10060;
            this.Button9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button9.UseVisualStyleBackColor = false;
            // 
            // Button12
            // 
            this.Button12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.Button12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button12.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.Button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Button12.ForeColor = System.Drawing.Color.LightGray;
            this.Button12.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Button12.Location = new System.Drawing.Point(1049, 4);
            this.Button12.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Button12.Name = "Button12";
            this.Button12.Size = new System.Drawing.Size(18, 26);
            this.Button12.TabIndex = 10061;
            this.Button12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.Button12.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            this.label8.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(20, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 14);
            this.label8.TabIndex = 10073;
            this.label8.Text = "번호    ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            this.label9.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(310, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 14);
            this.label9.TabIndex = 10072;
            this.label9.Text = "결과";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            this.label10.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(196, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 14);
            this.label10.TabIndex = 10071;
            this.label10.Text = "비밀번호        ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            this.label12.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.ForeColor = System.Drawing.Color.Gray;
            this.label12.Location = new System.Drawing.Point(102, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 14);
            this.label12.TabIndex = 10070;
            this.label12.Text = "아이디   ";
            // 
            // button13
            // 
            this.button13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(38)))));
            this.button13.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(38)))));
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button13.ForeColor = System.Drawing.Color.DarkGray;
            this.button13.Image = ((System.Drawing.Image)(resources.GetObject("button13.Image")));
            this.button13.Location = new System.Drawing.Point(395, 7);
            this.button13.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(34, 27);
            this.button13.TabIndex = 10277;
            this.button13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(38)))));
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button6.ForeColor = System.Drawing.Color.DarkGray;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(321, 159);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(101, 28);
            this.button6.TabIndex = 10274;
            this.button6.Text = "추가";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(11, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 14);
            this.label7.TabIndex = 10278;
            this.label7.Text = "검색 키워드";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(11, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 14);
            this.label1.TabIndex = 10279;
            this.label1.Text = "검색 제목";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(8, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 10280;
            this.label2.Text = "추가설정";
            // 
            // customTextbox4
            // 
            this.customTextbox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customTextbox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(33)))));
            this.customTextbox4.hint = "";
            this.customTextbox4.Location = new System.Drawing.Point(18, 124);
            this.customTextbox4.Margin = new System.Windows.Forms.Padding(0);
            this.customTextbox4.MultiLine = false;
            this.customTextbox4.Name = "customTextbox4";
            this.customTextbox4.Size = new System.Drawing.Size(404, 26);
            this.customTextbox4.TabIndex = 10286;
            this.customTextbox4.usePWchar = false;
            this.customTextbox4.val = "";
            // 
            // customTextbox3
            // 
            this.customTextbox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customTextbox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(33)))));
            this.customTextbox3.hint = "";
            this.customTextbox3.Location = new System.Drawing.Point(18, 64);
            this.customTextbox3.Margin = new System.Windows.Forms.Padding(0);
            this.customTextbox3.MultiLine = false;
            this.customTextbox3.Name = "customTextbox3";
            this.customTextbox3.Size = new System.Drawing.Size(209, 25);
            this.customTextbox3.TabIndex = 10283;
            this.customTextbox3.usePWchar = false;
            this.customTextbox3.val = "";
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(436, 198);
            this.Controls.Add(this.customTextbox4);
            this.Controls.Add(this.customTextbox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.Button9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AccountForm";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Button Button9;
        internal System.Windows.Forms.Button Button12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private CustomControl.CustomTextbox customTextbox2;
        private CustomControl.CustomTextbox customTextbox1;
        internal System.Windows.Forms.Button button13;
        internal System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CustomControl.CustomTextbox customTextbox3;
        private CustomControl.CustomTextbox customTextbox4;
    }
}

