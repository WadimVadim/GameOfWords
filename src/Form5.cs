using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ИграСлов
{
    public partial class Form5 : Form
    {
        public Form2 frm2;
        Graphics g;
        bool flag = true, flag2 = false, flag3 = false, mix = true, clamping = false, flag4 = true, game = true;
        // создаем двумерный массив размером 10x10
        char[,] words = new char[10, 20];
        int[,] words2 = new int[10, 20];
        string word;

        string[] words_dict = new string[500];
        string[] words_blank = new string[100];

        string first_words;
        string input = null;
        string rand_l, rand_w;
        int rand_vc, l1, l2;

        int i, n, n2, place;
        int score = 0;

        int x_save;
        int y_save;

        char[] vowels = { 'А', 'Е', 'Ё', 'И', 'О', 'У', 'Ы', 'Э', 'Ю', 'Я' };
        char[] consonants = { 'Б', 'В', 'Г', 'Д', 'Ж', 'З', 'Й', 'К', 'Л', 'М', 'Н', 'П', 'Р', 'С', 'Т', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ' };
        char[] words_vc = { 'А', 'Б', 'В', 'Г', 'Д', 'Ж', 'З', 'И', 'К', 'М', 'Н', 'О', 'Ы', 'П', 'Р', 'С', 'Т', 'У' };

        string[] Names_r = new string[2000];
        string[] Score_r = new string[10];

        Random rnd_l = new Random();

        // Заполнение готовых
        int location, x, y;
        String s_l;
        int[,] words_p = new int[10, 20];
        Random rnd_blank = new Random();

        public Form5()
        {
            InitializeComponent();
            g = this.CreateGraphics();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Score_r[i] = score.ToString();
            Names_r[i] = textBox1.Text;

            File.WriteAllText("Records_Score.txt", string.Empty);
            File.WriteAllText("Records_Names.txt", string.Empty);

            StreamWriter WriteFile = new StreamWriter("Records_Score.txt", true, Encoding.ASCII);

            for (i = 0; i < 10; i++)
            {
                WriteFile.WriteLine(Score_r[i]);
            }

            StreamWriter WriteFile2 = new StreamWriter("Records_Names.txt", true, Encoding.ASCII);

            for (i = 0; i < 10; i++)
            {
                WriteFile2.WriteLine(Names_r[i]);
            }

            WriteFile.Close();
            WriteFile2.Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            game = false;
            label2.Visible = true;
            label2.Text = "Время окончено!\nОчков: " + score.ToString();


            StreamReader ReadFile = File.OpenText("Records_Names.txt");
            for (i = 0; (input = ReadFile.ReadLine()) != null; i++)
            {
                Names_r[i] = input;
            }

            StreamReader ReadFile2 = File.OpenText("Records_Score.txt");
            for (int i = 0; (input = ReadFile2.ReadLine()) != null; i++)
            {
                Score_r[i] = input;
            }

            for (i = 0; i < 10; i++)
            {
                if ((score > int.Parse(Score_r[i])))
                {
                    textBox1.Visible = true;
                    button3.Visible = true;

                    label2.Text = "Вы поставили рекорд!\nВведите ваше имя: ";
                    place = i;
                    break;
                }
            }

            ReadFile.Close();
            ReadFile2.Close();

        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            // список русских гласных и согласных букв
            char[] vowels = { 'А', 'Е', 'Ё', 'И', 'О', 'У', 'Ы', 'Э', 'Ю', 'Я' };
            char[] consonants = { 'Б', 'В', 'Г', 'Д', 'Ж', 'З', 'Й', 'К', 'Л', 'М', 'Н', 'П', 'Р', 'С', 'Т', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ' };

            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (words[i, j] == ' ')
                    {
                        if (random.NextDouble() < 0.4)
                        {
                            // выбираем случайную гласную букву
                            words[i, j] = vowels[random.Next(vowels.Length)];
                        }
                        else
                        {
                            // выбираем случайную согласную букву
                            words[i, j] = consonants[random.Next(consonants.Length)];
                        }
                        flag3 = true;
                    }
                }
            }

            if (flag3)
            {
                output_words();
                pole();
                flag3 = false;
            }
        }

        private void Form5_MouseDown(object sender, MouseEventArgs e)
        {
            clamping = true;
        }

        private void Form5_MouseUp(object sender, MouseEventArgs e)
        {
            Color col;
            col = Color.FromArgb(127, 127, 127);
            Pen Pole = new Pen(Color.Black, 1);
            Pen Pole2 = new Pen(col, 5);

            if (word != null && word != "")
            {
                try
                {
                    try
                    {
                        first_words = "Словарь/" + word[0] + ".txt";
                        StreamReader ReadFile = File.OpenText(first_words);
                        for (i = 0; (input = ReadFile.ReadLine()) != null; i++)
                        {
                            words_dict[i] = input;
                        }
                    }
                    catch
                    {
                        first_words = "Словарь/" + word[0] + word[1] + ".txt";
                        StreamReader ReadFile = File.OpenText(first_words);
                        for (i = 0; (input = ReadFile.ReadLine()) != null; i++)
                        {
                            words_dict[i] = input;
                        }
                    }
                }
                catch
                {
                    Pen Select_word = new Pen(Color.Red, 5);

                    for (int n = 0; n < word.Length; n++)
                    {
                        for (int i = 1; i < 11; i++)
                        {
                            for (int j = 1; j < 21; j++)
                            {
                                if ((x_save >= j * 50 && x_save <= j * 50 + 50) && (y_save >= i * 50 && y_save <= i * 50 + 50))
                                {
                                    if (words2[i - 1, j - 1] == 0) word += words[i - 1, j - 1].ToString();
                                    words2[i - 1, j - 1] = 1;
                                    g.DrawRectangle(Select_word, 50 + ((j - 1) * 50), 50 + ((i - 1) * 50), 50, 50);
                                }
                                else
                                {
                                    g.DrawRectangle(Pole, 50 + ((j - 1) * 50), 50 + ((i - 1) * 50), 50, 50);
                                }
                            }
                        }
                    }
                }
                DateTime t = DateTime.Now;

                if (words_dict != null)
                {
                    if (words_dict.Contains(word))
                    {
                        score += word.Length;
                        textBox2.Text = score.ToString();

                        for (int i = 0; i < 10; i++)
                        {
                            for (int j = 0; j < 20; j++)
                            {
                                if (words2[i, j] == 1)
                                {
                                    n2 = 0;
                                    Thread.Sleep(2);
                                    for (n = 1; n < 11; n++)
                                    {
                                        try
                                        {
                                            words[i - n2, j] = words[i - n, j];
                                        }
                                        catch
                                        {
                                            words[i - n2, j] = ' ';
                                            break;
                                        }
                                        n2++;
                                    }
                                }
                            }
                        }
                        n2 = 0;

                        output_words();
                    }
                    else
                    {

                        Pen Select_word = new Pen(Color.Red, 5);

                        for (int n = 0; n < word.Length; n++)
                        {
                            for (int i = 1; i < 11; i++)
                            {
                                for (int j = 1; j < 21; j++)
                                {
                                    if ((x_save >= j * 50 && x_save <= j * 50 + 50) && (y_save >= i * 50 && y_save <= i * 50 + 50))
                                    {
                                        if (words2[i - 1, j - 1] == 0) word += words[i - 1, j - 1].ToString();
                                        words2[i - 1, j - 1] = 1;
                                        g.DrawRectangle(Select_word, 50 + ((j - 1) * 50), 50 + ((i - 1) * 50), 50, 50);
                                    }
                                    else
                                    {
                                        g.DrawRectangle(Pole, 50 + ((j - 1) * 50), 50 + ((i - 1) * 50), 50, 50);
                                    }
                                }
                            }
                        }
                    }
                }

                word = "";
                first_words = "";
                input = null;
                flag2 = true;

                for (int i = 0; i < words_dict.Length; i++)
                {
                    words_dict[i] = "";
                }

                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        words2[i, j] = 0;
                        g.DrawRectangle(Pole2, 50 + (j * 50), 50 + (i * 50), 50, 50);
                    }
                }
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        g.DrawRectangle(Pole, 50 + (j * 50), 50 + (i * 50), 50, 50);
                    }
                }
            }

            clamping = false;
        }

        private void Form5_MouseMove(object sender, MouseEventArgs e)
        {
            if (clamping)
            {
                int x = e.X;
                int y = e.Y;

                if (flag2)
                {
                    x_save = x;
                    y_save = y;
                    flag2 = false;
                }

                Pen Select_word = new Pen(Color.Blue, 5);
                Pen Pole = new Pen(Color.Black, 1);

                //textBox1.Text = x.ToString() + ' ' + y.ToString();

                for (int i = 1; i < 11; i++)
                {
                    for (int j = 1; j < 21; j++)
                    {
                        if ((x >= j * 50 && x <= j * 50 + 50) && (y >= i * 50 && y <= i * 50 + 50))
                        {
                            if (words2[i - 1, j - 1] == 0) word += words[i - 1, j - 1].ToString();
                            words2[i - 1, j - 1] = 1;
                            g.DrawRectangle(Select_word, 50 + ((j - 1) * 50), 50 + ((i - 1) * 50), 50, 50);
                        }
                        else
                        {
                            g.DrawRectangle(Pole, 50 + ((j - 1) * 50), 50 + ((i - 1) * 50), 50, 50);
                        }
                    }
                }
            }
        }

        private void Form5_Paint(object sender, PaintEventArgs e)
        {
            pole();
 
            if (this.flag4)
            {
                zapoln_blank();
            }

            if (this.flag)
            {
                zapoln();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm2 = new Form2();
            frm2.frm5 = this;
            frm2.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            zapoln();
        }

        public void pole()
        {
            if (game)
            {
                Pen Pole = new Pen(Color.Black, 1);

                for (int j = 0; j < 10; j++)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        g.DrawRectangle(Pole, 50 + (i * 50), 50 + (j * 50), 50, 50);
                    }

                }
            }
        }
        public void zapoln_blank()
        {
            for (int j = 0; j < 10;)
            {
                try
                {
                    l1 = rnd_l.Next(0, words_vc.Length);
                    l2 = rnd_l.Next(0, words_vc.Length);

                    rand_l = words_vc[l1].ToString() + words_vc[l2].ToString();

                    rand_w = "Словарь/" + rand_l + ".txt";
                    StreamReader ReadFile = File.OpenText(rand_w);
                    for (i = 0; (input = ReadFile.ReadLine()) != null; i++)
                    {
                        words_blank[i] = input;
                    }

                    j++;
                }
                catch
                {
                    rand_l = "";
                    input = "";
                    rand_w = "";

                    continue;
                }
            }
            this.flag4 = false;
        }

        public void zapoln()
        {
            if (game)
            {
                Color col;
                col = Color.FromArgb(127, 127, 127);
                SolidBrush myBrush1 = new SolidBrush(col);
                g.FillRectangle(myBrush1, 47, 47, 1006, 506);

                // заполняем массив случайными буквами
                Random random = new Random();
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        words2[i, j] = 0;
                        if (random.NextDouble() < 0.4)
                        {
                            // выбираем случайную гласную букву
                            words[i, j] = vowels[random.Next(vowels.Length)];
                        }
                        else
                        {
                            // выбираем случайную согласную букву
                            words[i, j] = consonants[random.Next(consonants.Length)];
                        }
                    }
                }

                for (int l = 0; l < 2; l++)
                {
                    x = rnd_blank.Next(0, 2);
                    y = rnd_blank.Next(0, 2);
                    s_l = words_blank[l];

                    for (int b = 0; b < s_l.Length;)
                    {
                        location = rnd_blank.Next(0, 2);
                        try
                        {
                            if (location == 0 && words_p[y, x + b] == 0)
                            {
                                x += 1;
                            }
                            else if (location == 1 && words_p[y + b, x] == 0)
                            {
                                y += 1;
                            }
                            words[y, x] = s_l[b];
                            words_p[y, x] = 1;
                            b++;
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }

                // выводим буквы на экран
                int xn, yn;
                System.Drawing.Font drawFont = new System.Drawing.Font("Courier New", 32);
                System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
                for (int i = 0; i < 10; i++)
                {
                    yn = 50 + (i * 50);
                    for (int j = 0; j < 20; j++)
                    {
                        xn = 30 + (j * 50);
                        string drawString = " " + Convert.ToString(words[i, j]);

                        System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                        g.DrawString(drawString, drawFont, drawBrush, xn, yn, drawFormat);
                    }
                }

                this.flag = false;
            }

        }

        public void output_words()
        {
            int xn, yn;
            Color col;
            col = Color.FromArgb(127, 127, 127);
            SolidBrush myBrush1 = new SolidBrush(col);
            g.FillRectangle(myBrush1, 47, 47, 1006, 506);
            System.Drawing.Font drawFont = new System.Drawing.Font("Courier New", 32);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            for (int i = 0; i < 10; i++)
            {
                yn = 50 + (i * 50);
                for (int j = 0; j < 20; j++)
                {
                    xn = 30 + (j * 50);
                    string drawString = " " + Convert.ToString(words[i, j]);

                    System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                    g.DrawString(drawString, drawFont, drawBrush, xn, yn, drawFormat);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
