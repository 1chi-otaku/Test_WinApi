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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinForms
{
    public partial class Form1 : Form
    {
        static int seconds = 59;
        public Form1()
        {
            InitializeComponent();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 10;
            progressBar1.Value = 0;
            progressBar1.Step = 1;
            timer1.Start();
            label1.Text = "0:" + seconds;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int points = 0;
            if(radioButton1.Checked) { points++; }
            if(radioButton6.Checked) { points++; }
            if(radioButton9.Checked) { points++;}
            if(radioButton12.Checked) { points++; }
            if (radioButton14.Checked) { points++; }
            if (radioButton16.Checked) { points++; }
            if (radioButton19.Checked) { points++; }
            if(checkBox6.Checked && checkBox5.Checked && !checkBox4.Checked) { points++; }
            if (checkBox1.Checked && checkBox3.Checked && !checkBox2.Checked) { points++; }
            if (checkBox7.Checked && checkBox9.Checked && !checkBox8.Checked) { points++; }
            progressBar1.Value = points;
            label2.Text = points.ToString() + "/10";
            button1.Enabled= false;
            timer1.Stop();

            string toFile = points.ToString() + "/10 - " + DateTime.Now.ToString();
            StreamWriter sw = new StreamWriter("testresult.txt", true);
            sw.WriteLine(toFile);
            sw.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "0:" + seconds;
            seconds--;
            if(seconds == 0)
            {
                MessageBox.Show("Время вышло. Программа экстренно закрывается!","Время вышло",MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
