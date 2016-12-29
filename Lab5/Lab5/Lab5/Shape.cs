using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    //This is the base class, all other shapes inherit from this
    public class Shape
    {
        //-----Member fields----------------------
        protected Pen pen;
        protected Brush brush;
        protected Point firstClick, secondClick;
        protected bool fill, outline;

        //----------Member methods----------------
        public Shape(int penColor,int fillColor,int penWidth,Point firstClick, 
            Point secondClick,bool fill,bool outline)
        {
            this.pen = getPen(penColor,penWidth);
            this.pen.Width = penWidth;  //set Pen width
            this.brush = getBrush(fillColor);
            this.firstClick = firstClick;
            this.secondClick = secondClick;
            this.fill = fill;
            this.outline = outline;
        }

        public virtual void Draw(Graphics g)
        {
            ;
        }

        //--------------Static methods------------
        //return Pen based on selection index in listbox
        private static Pen getPen(int penColor,int penWidth)
        {
            if (penColor == 0) return new Pen(Color.Black, penWidth);
            else if (penColor == 1) return new Pen(Color.Red, penWidth);
            else if (penColor == 2) return new Pen(Color.Blue, penWidth);
            else if (penColor == 3) return new Pen(Color.Green, penWidth);
            else return null;
        }

        //Return brush based on selection index in listbox
        private static Brush getBrush(int brushColor)
        {
            if (brushColor == 0) return Brushes.White;
            else if (brushColor == 1) return Brushes.Black;
            else if (brushColor == 2) return Brushes.Red;
            else if (brushColor == 3) return Brushes.Blue;
            else if (brushColor == 4) return Brushes.Green;
            else if (brushColor == -1) return null;
            else return null;
        }

    }
}
