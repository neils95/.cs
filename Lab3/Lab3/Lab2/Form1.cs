using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Lab3
{
    public partial class Form1 : Form
    {

        public class coordinate
        {
            public int x;
            public int y;

            //represent the 2 states using int. Black:0, Red:1
            public int color;  
            public coordinate(int x,int y)
            {
                this.x = x;
                this.y = y;
                this.color = 0;
            }

        }
        const int WIDTH = 20;
        const int HEIGHT = 20;
        private List<coordinate> coordinates = new List<coordinate>();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        
            Graphics g = e.Graphics;

            foreach (coordinate p in this.coordinates)
            {
              
                //Paint the correct brush color based on color code
                Brush brushColor;
                if (p.color == 0)
                {
                    brushColor = Brushes.Black;
                }else
                {
                    brushColor = Brushes.Red;
                }
                g.FillEllipse(brushColor,(p.x - WIDTH / 2), (p.y - WIDTH / 2),WIDTH, HEIGHT);
            }

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.coordinates.Add(new coordinate(e.X,e.Y));
                this.Invalidate();
            }

           if (e.Button == MouseButtons.Right) {     
                for (int i = coordinates.Count - 1; i >= 0; i--)
                {
                    //Check if click was within rectangle
                    if ((e.X > (coordinates[i].x - WIDTH / 2)) && (e.X < (coordinates[i].x + WIDTH / 2)) && 
                        (e.Y > (coordinates[i].y - HEIGHT / 2)) &&(e.Y < (coordinates[i].y + HEIGHT / 2)))
                    {
                        //if black, turn red
                        if (coordinates[i].color == 0)
                        {
                            coordinates[i].color = 1;
                            this.Invalidate();
                        }
                        //if red, clear
                        else if (coordinates[i].color == 1)
                        {
                            coordinates.Remove(coordinates[i]);
                            this.Invalidate();
                        }
                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.coordinates.Clear();
            this.Invalidate();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.coordinates.Clear();
            this.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

