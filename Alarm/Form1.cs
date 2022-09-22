using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alarm
{
    public partial class Form1 : Form
    {
        private DateTime dtstart;
        private SoundPlayer play = null;
        public Form1()
        {
            InitializeComponent();
            play = new SoundPlayer(new FileStream("Alarm09.wav", FileMode.Open));
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Location = new Point();
            TopMost = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtstart = DateTime.Now;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var t =dtstart.TimeOfDay - DateTime.Now.TimeOfDay + new TimeSpan(0, int.Parse(m.Text.Split(':')[0]), int.Parse(m.Text.Split(':')[1]));
            label1.Text = $"{t.Minutes:00}:{t.Seconds:00}";
            if (t.Minutes == 0 && t.Seconds == 0)
            {
                timer1.Enabled = false;
                play.Play();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
