using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Line:Shape
    {
        public Line(int penColor, int penWidth, Point firstClick, Point secondClick) 
            :base(penColor,-1,penWidth,firstClick,secondClick,false,false)
        {
            ;
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);
            //Draw line
            g.DrawLine(this.pen, firstClick, secondClick);
        }
    }
}
