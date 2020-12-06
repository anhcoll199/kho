using BUS;
using DTO;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media;
using Color = System.Drawing.Color;

namespace QLKho
{
    public partial class Form3 : Form
    {
        User_BUS Ubus = new User_BUS();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.BackColor = Color.FromArgb(31, 37, 47);
            txtAcc.BackColor = Color.FromArgb(31, 37, 47);
            txtPass.BackColor = Color.FromArgb(31, 37, 47);
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

        private void button1_Click(object sender, EventArgs e)
        {
            string account = txtAcc.Text;
            string password = CreateMD5(txtPass.Text);
            var data = Ubus.Login(account, password);
            if (data.Rows.Count == 1) 
            {
                User user = new User(); 
                foreach (DataRow row in data.Rows)
                {
                    user.ID = row["Id"].ToString();
                    user.Name = row["DisplayName"].ToString();
                    user.Role = row["IdUserRole"].ToString();
                }
                LoginVar.ID = user.ID;
                LoginVar.Name = user.Name;
                LoginVar.Role = user.Role;
                MessageBox.Show("Đăng nhập thành công - Xin chào " + user.Name, "Kho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form5 mainForm = new Form5();
                mainForm.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
                this.Hide();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại - hãy kiểm tra lại thông tin", "Kho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        void otherForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        private static string CreateMD5(string s)
        {
            // Use input string to calculate MD5 hash
            using (var provider = System.Security.Cryptography.MD5.Create())
            {
                StringBuilder builder = new StringBuilder();

                foreach (byte b in provider.ComputeHash(Encoding.UTF8.GetBytes(s)))
                    builder.Append(b.ToString("x2").ToLower());

                return builder.ToString();
            }
        }
    }
}
