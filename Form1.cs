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

        void sayTime(byte hour)
        {
            using (MemoryStream fileOut = new MemoryStream((byte[])Properties.Resources.ResourceManager.GetObject("yandex"+Convert.ToString(hour))))
            using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                new SoundPlayer(gz).Play();
            /*
            using (GZipStream gz = new GZipStream(Properties.Resources.ResourceManager.GetStream("yandex"+hour.ToString()), CompressionMode.Decompress))
                new SoundPlayer(gz).Play();
            */
            /*
            switch (hour)
            {
                case 0:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources.yandex00))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 1:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources.yandex01))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 2:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources.yandex02))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 3:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources.yandex03))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 4:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources.yandex04))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 5:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources.yandex05))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 6:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources.yandex06))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 7:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources.yandex07))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 8:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources.yandex08))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 9:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources.yandex09))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 10:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources.yandex10))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 11:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources.yandex11))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 12:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources.yandex12))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 13:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources.yandex13))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 14:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources.yandex14))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 15:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources.yandex15))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 16:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources.yandex16))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 17:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources.yandex17))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 18:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources.yandex18))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 19:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources.yandex19))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 20:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources.yandex20))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 21:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources.yandex21))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 22:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources.yandex22))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                case 23:
                    using (MemoryStream fileOut = new MemoryStream(Properties.Resources.yandex23))
                    using (GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                        new SoundPlayer(gz).Play();
                    break;
                default:
                    break;
            }
            */
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
