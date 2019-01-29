using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int min, sec, count;
        public Form1()
        {
            InitializeComponent();

            count = 0;
            timer1.Interval = 1000;
            timer2.Interval = 500;
            min = 0;
            sec = 0;
            button1.Enabled = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled )
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                button3.Enabled = false;
                button1.Enabled = true;
                label3.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            min = 0;
            sec = 0;
            label2.Text = "00";
            label3.Visible = true;
            label4.Text = "00";
            button1.Enabled = false;
            button3.Enabled = false;
            timer1.Enabled = false;
            timer2.Enabled = false;
            comboBox1.Text = "0";
            progressBar1.Value = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (count < progressBar1.Maximum)
            {
                count++;
                progressBar1.Value = count;
            }
            else
            {
                if (radioButton1.Checked)
                {
                    MessageBox.Show("Sleep");
                    //timer1.Enabled = false;
                    //timer2.Enabled = false;
                    button1.Enabled = true;
                    button2.Enabled = false;
                    timer1.Stop();
                    timer2.Stop();
                }
                else
                {
                    MessageBox.Show("swich off");
                    timer1.Enabled = false;
                    timer2.Enabled = false;
                    button1.Enabled = true;
                    button2.Enabled = false;
                }
            }        
            
                if(sec > 0)
                {
                    sec--;

                    if(sec < 10)
                    {
                        label4.Text = "0" + sec.ToString();
                    }
                    else
                    {
                        label4.Text = sec.ToString();
                    }
                }
                else
                {
                    if (min > 0)
                    {
                        min--;
                        if (min < 10)
                           label2.Text = "0" + min.ToString();
                        else
                           label2.Text = min.ToString();

                        sec = 59;
                        label4.Text = "59";
                    }
                    else
                    {
                        min = 0;
                        label2.Text = "00";
                    }
                    
                }

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            label2.Text = comboBox1.Text;
            min = Int32.Parse(comboBox1.Text);
            button1.Enabled = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = min * 60;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (label3.Visible)
                label3.Visible = false;
            else
                label3.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                button1.Enabled = true;
                button3.Enabled = false;
            }
            else
            {
                timer1.Enabled = true;
                timer2.Enabled = true;
                button1.Enabled = false;
                button3.Enabled = true;
            }
        }
    }
}
