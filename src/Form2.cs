using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ИграСлов
{
    public partial class Form2 : Form
    {
        public Form1 frm1;
        public Form3 frm3;
        public Form5 frm5;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm1 = new Form1();
            frm1.frm2 = this;
            frm1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm3 = new Form3();
            frm3.frm2 = this;
            frm3.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm5 = new Form5();
            frm5.frm2 = this;
            frm5.Show();
            this.Hide();
        }
    }
}
