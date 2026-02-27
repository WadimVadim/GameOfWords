using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ИграСлов
{
    public partial class Form4 : Form
    {
        public Form1 frm1;

        public Form4()
        {
            InitializeComponent();      
            textBox1.Text = "Перед вами игровое поле, на котором расположены буквы.Вам необходимо из букв составлять слова, для этого необходимо соединять их по горизонтали или вертикали, они будут подсвечиваться синим цветом.";
            textBox2.Text = "Если выделенное слово существует, то оно будет\r\nподсвечено зелёным цветом и вам будет \r\nначислен количество баллов равное количеству\r\nбукв в слове.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm1 = new Form1();
            frm1.frm4 = this;
            frm1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = true;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            textBox2.Visible = false;
            button3.Enabled = false;
            button2.Enabled = true;
            textBox1.Text = "Если же выделенного слова не удалось найти\r\nв словаре, то оно будет подсвечено красным\r\nцветом.";
            textBox3.Text = "             В игре есть 3 режима:\r\n\r\n                      - Уровни\r\n                      - На время\r\n                      - Аркада";
            textBox1.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            button4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "Уровни - в этом режиме вам нужно проходить уровни, набирая подходящее количество очков. На каждом уровне требуется всё больше очков. Игроки с самым большим уровнем попадают в рекорды.";
            textBox5.Text = "На время - вам нужно набрать как можно больше очков за 2 минуты. Лучшие результаты попадают во вкладку \"Рекорды\"";
            textBox6.Text = "Аркада - режим, где вы можете бесконечно собирать слова, без времени и уровней.";
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox3.Visible = false;
            textBox2.Visible = false;
            textBox1.Visible = false;
            pictureBox3.Visible = false;
            button4.Enabled = false;
            button3.Enabled = true;
            button2.Enabled = true;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            textBox1.Text = "Перед вами игровое поле, на котором расположены буквы.Вам необходимо из букв составлять слова, для этого необходимо соединять их по горизонтали или вертикали, они будут подсвечиваться синим цветом.";
            textBox2.Text = "Если выделенное слово существует, то оно будет\r\nподсвечено зелёным цветом и вам будет \r\nначислен количество баллов равное количеству\r\nбукв в слове.";
            textBox1.Visible = true;
            textBox2.Visible = true;
            button4.Enabled = true;
            button3.Enabled = true;
            button2.Enabled = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox3.Visible = false;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
