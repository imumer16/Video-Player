using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace video_player
{
    public partial class Form1 : Form
    {
        private bool _dragging = false;
        private Point _offset;
        private Point _start_point = new Point(0, 0);

        string videpath,vTitle;
        public Form1()
        {
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
            InitializeComponent();
        }


    

        private void roundButton1_Click(object sender, EventArgs e)
        {
            if (roundButton1.Text=="|>")
            {
                roundButton1.ForeColor = System.Drawing.Color.Red;
                roundButton1.Text = "||";
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            else if (roundButton1.Text == "||")
            {
                roundButton1.ForeColor = System.Drawing.Color.Green;
                roundButton1.Text = "|>";
                axWindowsMediaPlayer1.Ctlcontrols.pause();
            }
        
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(   p.X-this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = false, Filter = "MP4 File|*.mp4|All File|*.*" };
            if (openFileDialog.ShowDialog()==DialogResult.OK)
            {
                videpath = openFileDialog.FileName;
                vTitle = openFileDialog.SafeFileName;
                axWindowsMediaPlayer1.URL = videpath;
            }
            roundButton1.ForeColor = System.Drawing.Color.Red;
            roundButton1.Text = "||";
        }
    }
}
