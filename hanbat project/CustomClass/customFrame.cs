using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

namespace WindowsFormsApp2.CustomControl
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class customFrame : UserControl
    {

        private String Name;
        private Color titleColor;
        private Color subjectColor;


        public Color _titleColor
        {
            get { return titleColor;  }
            set { titleColor = value; panel8.BackColor = titleColor; }
        }
        public Color _subjectColor
        {
            get { return subjectColor;  }
            set { subjectColor = value; this.BackColor = subjectColor; }
        }
    
        public String FrameName
        {
            get { return Name;  }
            set { this.Name = value;  }
        }

        public customFrame()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void customFrame_Load(object sender, EventArgs e)
        {
            panel8.SendToBack();
            panel10.SendToBack();
            panel9.SendToBack();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
