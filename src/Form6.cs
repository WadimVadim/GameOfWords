using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ИграСлов
{
    public partial class Form6 : Form
    {
        public Form1 frm1;

        bool flag = true;
        int i;
        string input;
        string[] Names = new string[10];
        string[] Score = new string[10];

        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frm1 = new Form1();
            frm1.frm6 = this;
            frm1.Show();
            this.Hide();
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            if (flag)
            {
                StreamReader ReadFile = File.OpenText("Records_Names.txt");
                for (i = 0; (input = ReadFile.ReadLine()) != null; i++)
                {
                    Names[i] = input;
                }

                ReadFile.Close();

                StreamReader ReadFile2 = File.OpenText("Records_Score.txt");
                for (int i = 0; (input = ReadFile2.ReadLine()) != null; i++)
                {
                    Score[i] = input;
                }

                ReadFile2.Close();

                for (i = 0; i < 10; i++)
                {
                    label2.Text += Names[i] + "\n";
                    label3.Text += Score[i] + "\n";
                }

                flag = false;
            }
        }
    }
}
