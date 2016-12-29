using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Ellipse : Shape
    {
        public Ellipse(int penColor, int fillColor, int penWidth, Point firstClick, Point secondClick, bool fill, bool outline)
            : base(penColor, fillColor, penWidth, firstClick, secondClick, fill, outline)
        {
            ;
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);

            //Decide top left coordinate, height and width of enclosing rectangle
            int x = (firstClick.X <= secondClick.X) ? firstClick.X : secondClick.X;
            int y = (firstClick.Y <= secondClick.Y) ? firstClick.Y : secondClick.Y;
            int width = Math.Abs(firstClick.X - secondClick.X);
            int height = Math.Abs(firstClick.Y - secondClick.Y);

            //First fill and then draw, this preserves Z order
            if (fill) g.FillEllipse(this.brush, x, y, width, height);
            if (outline) g.DrawEllipse(this.pen, x, y, width, height);
            
        }
    }
}
