using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DeskClock
{
    public partial class DeskClock : Form
    {
        [DllImport("user32.dll")] private static extern int SetWindowLong(IntPtr window, int index, int value);
        [DllImport("user32.dll")] private static extern int GetWindowLong(IntPtr window, int index);
        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_TOOLWINDOW = 0x00000080;

        byte fontSize = 10;
        bool modeHide = false;
        bool modeSilence = false;
        bool modeCalendar = false;
        string position = "br";
        readonly string voice = "yandex";
        readonly Timer timer = new();
        public DeskClock()
        {
            InitializeComponent();
            this.Opacity = 0.75;
            Label1.BackColor = Color.FromArgb(36, 48, 54);
            Label1.ForeColor = Color.FromArgb(204, 207, 255);
            CheckArgs();
            CurTime();
            this.Size = new Size(Convert.ToInt16(Label1.Text.Length * fontSize) + (2 * fontSize), fontSize * 2);
            SetClockPosition();
            Label1.Font = new Font("Tahoma", fontSize, FontStyle.Bold);
            Label1.Width = this.Width;
            Label1.Height = this.Height - 2;
            Label1.TextAlign = ContentAlignment.TopCenter;
            Label1.AutoSize = false;
            Label1.Location = new Point(0, 0);
            ProgressBar1.Location = new Point(0, Label1.Height);
            ProgressBar1.Height = 2;
            ProgressBar1.Width = Label1.Width;
        }

        void Form1_Load(object sender, EventArgs e)
        {
            timer.Interval = 1000;
            timer.Tick += new EventHandler(UpdateTime);
            timer.Start();
            if (modeHide)
            {
                this.ShowInTaskbar = false;
                this.ShowIcon = false;
                HideFromAltTab(this.Handle);
            }
        }

        public void SetClockPosition()
        {
            this.StartPosition = FormStartPosition.Manual;
            switch (position)
            {
                case "tm": //top-middle
                    this.Top = 0;
                    this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
                    break;
                case "bm": //bottom-middle
                    this.Top = Screen.PrimaryScreen.Bounds.Height - (fontSize * 2);
                    this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
                    break;
                case "tr": //top-right
                    this.Top = 0;
                    this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width;
                    break;
                case "tl": //top-left
                    this.Top = 0;
                    this.Left = 0;
                    break;
                case "br": //bottom-right
                    this.Top = Screen.PrimaryScreen.Bounds.Height - (fontSize * 2);
                    this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width;
                    break;
                case "bl": //bottom-left
                    this.Top = Screen.PrimaryScreen.Bounds.Height - (fontSize * 2);
                    this.Left = 0;
                    break;
                case "center": //center
                    this.Top = (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - (fontSize * 2)) / 2;
                    this.Left = (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
                    break;
                default:
                    MessageBox.Show("Неверно указано положение часов. Будет использована позиция по умолчанию (правый нижний угол).");
                    this.Top = Screen.PrimaryScreen.Bounds.Height - (fontSize * 2);
                    this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width;
                    break;
            }
        }

        public void SayTime(byte hour)
        {
            using MemoryStream fileHour = new((byte[])Properties.Resources.ResourceManager.GetObject(voice + Convert.ToString(hour)));
            using GZipStream gzHour = new(fileHour, CompressionMode.Decompress);
            new SoundPlayer(gzHour).Play();
        }
        public void CurTime()
        {
            ProgressBar1.Value = DateTime.Now.Second;
            if (modeCalendar) { Label1.Text = DateTime.Now.ToString("dd MMM, HH : mm : ss"); }
            else { Label1.Text = DateTime.Now.ToString("HH : mm : ss"); }
        }
        public void UpdateTime(object sender, EventArgs e)
        {
            CurTime();
            if (modeSilence == false && DateTime.Now.Second == 0 && DateTime.Now.Minute == 0) SayTime(Convert.ToByte(DateTime.Now.Hour));
        }
        public void Label1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Close();
        }
        public static void HideFromAltTab(IntPtr Handle)
        {
            SetWindowLong(Handle, GWL_EXSTYLE, GetWindowLong(Handle, GWL_EXSTYLE) | WS_EX_TOOLWINDOW);
        }
        public void Help()
        {
            MessageBox.Show(@"/hide - не отображать часы по ALT+TAB
/silence - не издавать звуков
/calendar - выводить число и месяц
/size={размер} - задать размер шрифта (не более 255!)
/colorf={цвет} - цвет текста в HEX-формате без символа #
/colorb={цвет} - цвет фона в HEX-формате без символа #
/position={положение} - положение часов на экране. {Положение} может принимать одно из следующих значений:
    tr - верхний-правый угол экрана
    tm - верхняя середина экрана
    tl - верхний-левый угол экрана
    center - центр экрана
    br - нижний-правый угол экрана
    bm - нижняя середина экрана
    bl - нижний-левый угол экрана", "Дополнительные параметры запуска", MessageBoxButtons.OK, MessageBoxIcon.Question);
            Close();
        }
        public void CheckArgs()
        {
            var cmdArgs = Environment.GetCommandLineArgs();
            foreach (var arg in cmdArgs)
            {
                if (arg.Equals("/help") || arg.Equals("/h") || arg.Equals("-help") || arg.Equals("-h") || arg.Equals("/?") || arg.Equals("-?")) { Help(); }
                if (arg.Equals("/hide")) { modeHide = true; }
                if (arg.Equals("/silence")) { modeSilence = true; }
                if (arg.Equals("/calendar")) { modeCalendar = true; }
                if (arg.StartsWith("/position")) { position = Convert.ToString(arg.Split("=")[1]); }
                if (arg.StartsWith("/size")) { fontSize = Convert.ToByte(arg.Split("=")[1]); }
                if (arg.StartsWith("/colorf")) { Label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#" + Convert.ToString(arg.Split("=")[1])); }
                if (arg.StartsWith("/colorb")) { Label1.BackColor = System.Drawing.ColorTranslator.FromHtml("#" + Convert.ToString(arg.Split("=")[1])); }
            }
        }
    }
}
