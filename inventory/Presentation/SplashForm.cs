using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace inventory.Presentation
{
    public partial class SplashForm : Form
    {
        private Timer fadeTimer;
        private Timer progressTimer;
        private int progressValue = 0;

        public SplashForm()
        {
            InitializeComponent();
            this.Opacity = 0;
            SetupTimers();
        }

        private void SetupTimers()
        {
            fadeTimer = new Timer();
            fadeTimer.Interval = 30;
            fadeTimer.Tick += (s, e) =>
            {
                if (this.Opacity < 1)
                    this.Opacity += 0.05;
                else
                    fadeTimer.Stop();
            };
            fadeTimer.Start();

            progressTimer = new Timer();
            progressTimer.Interval = 50;
            progressTimer.Tick += ProgressTimer_Tick;
            progressTimer.Start();
        }

        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            progressValue += 2;
            pbLoading.Value = progressValue;

            if (progressValue >= 100)
            {
                progressTimer.Stop();
                FadeOutAndClose();
            }
        }

        private void FadeOutAndClose()
        {
            Timer fadeOut = new Timer();
            fadeOut.Interval = 30;
            fadeOut.Tick += (s, e) =>
            {
                if (this.Opacity > 0)
                    this.Opacity -= 0.05;
                else
                {
                    fadeOut.Stop();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            };
            fadeOut.Start();
        }
    }
}
