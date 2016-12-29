using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lab8
{
    public partial class Slide : Form
    {
        List<string> filesToView = new List<string>();
        int time,numberOfSlides,slideIndex = 0;

        public Slide(List<string> files, int interval)
        {
            this.filesToView = files;
            this.time = interval;
            this.numberOfSlides = filesToView.Count;
            InitializeComponent();
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.ShowDialog();
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            if (slideIndex == numberOfSlides)
            {
                Close();
            }
            else
            {
                slideIndex++;
            }

            base.OnPaint(e);
            Graphics g = e.Graphics;

            try
            {
                Image currentImage = Image.FromFile(filesToView[slideIndex-1]);
                SizeF client = ClientSize;
                int imgH = currentImage.Height;
                int imgW = currentImage.Width;

                if(client.Height / imgH < client.Width / imgW)
                {
                    float shift = client.Height / imgH;
                    g.DrawImage(currentImage, (client.Width - imgW * shift) / 2,
                       (client.Height - imgH * shift) / 2,
                       imgW * shift, imgH * shift);
                }
                else
                {
                    float shift = client.Width / imgW;
                    g.DrawImage(currentImage, (client.Width - imgW * shift) / 2,
                      (client.Height - imgH * shift) / 2,
                      imgW * shift, imgH * shift);
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Not a valid file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void Slides_Load(object sender, EventArgs e)
        {
            timer1.Interval = time * 1000;
            timer1.Start();
        }

        private void Slides_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
