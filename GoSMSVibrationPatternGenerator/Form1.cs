using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoSMSVibrationPattern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        StringBuilder pattern = new StringBuilder();
        int milisecondsOn = 0;
        int milisecondsOff = 0;
        bool On = false;
        bool IsKeyDown = false;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R)
                pattern.Remove(0, pattern.Length);
            if (!IsKeyDown && e.KeyCode == Keys.Space)
            {
                IsKeyDown = true;
                timer.Stop();
                if (pattern.Length == 0)
                    pattern.Append("0");
                else
                    pattern.Append("," + milisecondsOff.ToString());
                On = true;
                milisecondsOn = 0;
                timer.Start();
            }
        }



        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                IsKeyDown = false;
                timer.Stop();
                pattern.Append("," + milisecondsOn.ToString());
                On = false;
                milisecondsOff = 0;
                timer.Start();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (On)
            {
                milisecondsOn += 10;
            }
            else
            {
                milisecondsOff += 10;
            }
            textBox1.Text = pattern.ToString();
        }
    }
}
