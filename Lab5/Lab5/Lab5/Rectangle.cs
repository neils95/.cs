using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Rectangle:Shape
    {
        public Rectangle(int penColor, int fillColor, int penWidth, Point firstClick, Point secondClick, bool fill, bool outline) 
            :base(penColor,fillColor,penWidth,firstClick,secondClick,fill,outline)
        {
            ;
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);

            //Decide top left coordinate, width and height of rectangle
            int x = (firstClick.X <= secondClick.X) ? firstClick.X : secondClick.X;
            int y = (firstClick.Y <= secondClick.Y) ? firstClick.Y : secondClick.Y;
            int width = Math.Abs(firstClick.X - secondClick.X);
            int height = Math.Abs(firstClick.Y - secondClick.Y);

            //First fill and then draw, this preserves Z order
            if (fill) g.FillRectangle(this.brush,x, y, width, height);
            if (outline) g.DrawRectangle(this.pen, x, y, width, height);     
        }
    }
}
