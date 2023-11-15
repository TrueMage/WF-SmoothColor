using System.Diagnostics.Metrics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace WF_GradientBG
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        private int _currentColor = 0;

        int curR = 0;
        int curG = 0;
        int curB = 0;

        int gR = 0;
        int gG = 0;
        int gB = 0;
        bool reached = false;

        //private Color[] colors = new Color[]
        //    { Color.Black, Color.Red, Color.Yellow, Color.Green, Color.Blue, Color.Pink, Color.White };

        public Form1()
        {
            InitializeComponent();
            gR = rand.Next(0, 256);
            gG = rand.Next(0, 256);
            gB = rand.Next(0, 256);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (reached)
            {
                if (curR <= 0 && curB <= 0 && curG <= 0)
                {
                    gR = rand.Next(0, 256);
                    gG = rand.Next(0, 256);
                    gB = rand.Next(0, 256);

                    reached = false;
                }
                BackColor = Color.FromArgb(255, curR == 0 ? 0 : curR--, curG == 0 ? 0 : curG--, curB == 0 ? 0 : curB--);
            }
            else
            {
                if (curB != gB) BackColor = Color.FromArgb(255, curR, curG, curB++);
                else if (curR != gR) BackColor = Color.FromArgb(255, curR++, curG, curB);
                else if (curG != gG) BackColor = Color.FromArgb(255, curR, curG++, curB);
                else reached = true;
            }
        }
    }
}