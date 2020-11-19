using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKho
{
    public partial class Form4 : Form
    {
        //var
        private Button currentButton;
        private Random random;
        private int tempindex;

        //contructor
        public Form4()
        {
            InitializeComponent();
        }

        //Methods
        private Color SelectThemeColor (int index)
        {
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActiveButton(object btnSender, int index)
        {
            if (btnSender != null)
            {
                //DisableButton();
                var btn = (Button)btnSender;
                Color color = SelectThemeColor(index);
                btn.BackColor = color;
                panelTittle.BackColor = color;
                panelLogo.BackColor = ControlPaint.Dark(color);
            }
        }
        private void DisableButton()
        {
            foreach(Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(48, 50, 74);
                    previousBtn.ForeColor = Color.White;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, 2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, 3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, 4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, 5);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }
    }
}
