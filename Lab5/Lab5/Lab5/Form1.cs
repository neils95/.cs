using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class form1 : Form
    {
        //Form1 class fields---------------------------------------------------
        public static int clickNumber = 0;  //Number of clicks after last shape 
        public static Point firstClick;     //
        public static ArrayList shapes = new ArrayList();   //Array List to store all the Shape objects

        //Form1 class methods--------------------------------------------------
        public form1()
        {
            InitializeComponent();    
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Initialize all the ListBox to select first item in list by default
            penColorListBox.SelectedIndex = 0;
            fillColorListBox.SelectedIndex = 0;
            penWidthListBox.SelectedIndex = 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        //-----------Settings panel-----------------------------------------
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ;
        }


        //---------------Draw Panel------------------------------------------   
        private void drawPanel_Paint(object sender, PaintEventArgs e)
        {
            //Pant each shape in Array List of shapes
            foreach (Shape shape in shapes){
                shape.Draw(e.Graphics);
            }
        }

        //Draw event andler for draw Panel
        private void drawPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left))
            {
                if (clickNumber == 0)   //First Click
                {
                    clickNumber = 1;
                    //Record X and Y coordinate of first click
                    firstClick = new Point(e.X, e.Y);
                }
                else                   //Second Click
                {
                    clickNumber = 0;
                    //Store current setttings and clicks
                    Point secondClick = new Point(e.X, e.Y);
                    int penColorIndex = penColorListBox.SelectedIndex;
                    int fillColorIndex = fillColorListBox.SelectedIndex;
                    int penWidth = Convert.ToInt32(penWidthListBox.GetItemText(penWidthListBox.SelectedIndex));
                       
                    //Draw Line
                    if (lineRadioButton.Checked)
                    {
                        shapes.Add(new Line(
                            penColorIndex,
                            penWidth,
                            firstClick,
                            secondClick
                        ));
                    }
                    //Draw Rectangle
                    else if (rectangleRadioButton.Checked)
                    {
                        shapes.Add(new Rectangle(
                            penColorIndex,
                            fillColorIndex,
                            penWidth,
                            firstClick,
                            secondClick,
                            fillCheckBox.Checked,
                            outlineCheckBox.Checked
                        ));
                    }
                    //Draw ellipse
                    else if (ellipseRadioButton.Checked)
                    {
                        shapes.Add(new Ellipse(
                            penColorIndex,
                            fillColorIndex,
                            penWidth,
                            firstClick,
                            secondClick,
                            fillCheckBox.Checked,
                            outlineCheckBox.Checked
                        ));
                    }
                    //Draw Text
                    else if (textRadioButton.Checked)
                    {
                        shapes.Add(new Text(
                            penColorIndex,
                            firstClick,
                            secondClick,
                            this.textBox1.Text
                        ));
                    }

                    drawPanel.Invalidate();    //Re Paint the panel
                }
            }
        }

        //--------------Menu Strip controls----------------------------------
        //Clear the Draw Panel
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapes.Clear();
            drawPanel.Invalidate();
        }

        //Close form
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Implement undo
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Remove shape at end of array list, which is also most recently added
            if (shapes.Count > 0)
            {
                shapes.RemoveAt(shapes.Count - 1);
                drawPanel.Invalidate();
            }
        }
    }
}
