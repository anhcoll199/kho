using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace QLKho
{
    public partial class Form2 : Form
    {
        Suplier_BUS bus = new Suplier_BUS();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            BangSup.DataSource = bus.getAll();
        }
    }
}
