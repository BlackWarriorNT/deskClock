using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Media;
using System.Windows.Forms;

namespace deskClock
{
    public partial class deskClock : Form
    {
        Timer timer = new Timer();
        public deskClock()
        {
            InitializeComponent();
            byte fontSize = 14;
            this.Opacity = 0.75;
            this.Size = new Size(fontSize * 9, fontSize + 8);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - this.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - this.Height);
            //this.Location = new Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 2, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height / 2);
            label1.Font = new Font("Tahoma", fontSize - 2, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(204, 207, 255);
            label1.Width = this.Width;
            label1.Height = this.Height - 2;
            label1.BackColor = Color.FromArgb(36, 48, 54);
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.AutoSize = false;
            label1.Location = new Point(0, 0);
            progressBar1.Location = new Point(0, label1.Height);
            progressBar1.Height = 2;
            progressBar1.Width = label1.Width;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            curTime();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(updateTime);
            timer.Start();
        }

        private void sayTime(byte hour)
        {
            switch (hour)
            {
                case 0:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources._00))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 1:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources._01))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 2:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources._02))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 3:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources._03))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 4:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources._04))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 5:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources._05))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 6:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources._06))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 7:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources._07))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 8:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources._08))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 9:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources._09))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 10:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources._10))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 11:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources._11))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 12:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources._12))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 13:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources._13))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 14:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources._14))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 15:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources._15))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 16:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources._16))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 17:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources._17))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 18:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources._18))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 19:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources._19))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 20:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources._20))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 21:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources._21))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 22:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources._22))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 23:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources._23))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                default:
                    break;
            }
        }
        private void curTime()
        {
            progressBar1.Value = DateTime.Now.Second;
            label1.Text = DateTime.Now.ToString("HH : mm : ss");
        }

        private void updateTime(object sender, EventArgs e)
        {
            curTime();
            if (DateTime.Now.Minute == 0 && DateTime.Now.Second == 0) sayTime(Convert.ToByte(DateTime.Now.Hour));

        }
        private void label1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Close();
        }
    }
}
