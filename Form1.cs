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

        private Color[] colors = new Color[]
           { Color.Black, Color.Red, Color.Yellow, Color.Green, Color.Blue, Color.Pink, Color.White };

        public Form1()
        {
            InitializeComponent();
            gR = colors[_currentColor].R;
            gG = colors[_currentColor].G;
            gB = colors[_currentColor].B;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (reached)
            {
                if (++_currentColor == colors.Length - 1) _currentColor = 0;
                gR = colors[_currentColor].R;
                gG = colors[_currentColor].G;
                gB = colors[_currentColor].B;

                reached = false;
            }
            else
            {
                BackColor = Color.FromArgb(255,
                    curR == gR ? curR : curR < gR ? curR++ : curR--,
                    curG == gG ? curG : curG < gG ? curG++ : curG--,
                    curB == gB ? curB : curB < gB ? curB++ : curB--
                    );
                if(curR == gR && curB == gB && curG == gG) reached = true;
            }
        }
    }
}