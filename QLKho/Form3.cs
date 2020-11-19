using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media;
using Color = System.Drawing.Color;

namespace QLKho
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.BackColor = Color.FromArgb(31, 37, 47);
            textBox1.BackColor = Color.FromArgb(31, 37, 47);
            textBox2.BackColor = Color.FromArgb(31, 37, 47);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 47, 60);
            button1.FlatAppearance.BorderColor = Color.FromArgb(67, 60, 147);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //if (MessageBox.Show("Are you sure you want to quit?", "My Application", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    this.Close();
            //}
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
         
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(255, 255, 255);
            panel4.BackColor = Color.FromArgb(105, 105, 105);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            panel4.BackColor = Color.FromArgb(255, 255, 255);
            panel5.BackColor = Color.FromArgb(105, 105, 105);
        }
    }
}
