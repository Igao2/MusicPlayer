using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace musica_player
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        string[] paths;
        string[] music;


        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog opn = new OpenFileDialog();
            opn.Multiselect = true;
            if (opn.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                paths = opn.FileNames;
                music = opn.FileNames;
                for (int x = 0; x < music.Length; x++)
                {
                    listBox1.Items.Add(music[x]);
                    music = opn.FileNames;
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {

            player.Ctlcontrols.play();
            button1.Enabled = false;
            button1.Visible = false;
            button2.Enabled = true;
            button2.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button2.Visible = false;
            trackBar1.Value = 50;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player.Ctlcontrols.pause();
            button1.Enabled = true;
            button1.Visible = true;
            button2.Enabled = false;
            button2.Visible = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < listBox1.Items.Count - 1)
            {
                listBox1.SelectedIndex = listBox1.SelectedIndex + 1;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > 0)
            {
                listBox1.SelectedIndex = listBox1.SelectedIndex - 1;

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (player.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                progressBar1.Maximum = (int)player.Ctlcontrols.currentItem.duration;

                progressBar1.Value = (int)player.Ctlcontrols.currentPosition;
                

                label2.Text = player.Ctlcontrols.currentPositionString;
                label3.Text = player.Ctlcontrols.currentItem.durationString.ToString();

            }
            try
            {

            }
            catch {

            }

        }

        private void progressBar1_MouseDown(object sender, MouseEventArgs e)
        {

            player.Ctlcontrols.currentPosition = player.currentMedia.duration * e.X / progressBar1.Width;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            player.URL = paths[listBox1.SelectedIndex];
            player.Ctlcontrols.play();
            button1.Enabled = false;
            button1.Visible = false;
            button2.Enabled = true;
            button2.Visible = true;

        }


       

    private void trackBar1_Scroll(object sender, EventArgs e)
    {
        label1.Text = trackBar1.Value.ToString();
        player.settings.volume = trackBar1.Value;
    }

        
    }

}