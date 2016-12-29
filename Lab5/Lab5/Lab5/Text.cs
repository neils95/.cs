using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Text : Shape
    {
        private String text;
        public Text(int penColor, Point firstClick, Point secondClick,String text)
            : base(penColor, -1, 1, firstClick, secondClick, false, false)
        {
            this.text=text;
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);

            //Decide top left coordinate, width and height ofenclosing rectangle
            int x = (firstClick.X <= secondClick.X) ? firstClick.X : secondClick.X;
            int y = (firstClick.Y <= secondClick.Y) ? firstClick.Y : secondClick.Y;
            int width = Math.Abs(firstClick.X - secondClick.X);
            int height = Math.Abs(firstClick.Y - secondClick.Y);
            //enclosing Rectanglef for text
            RectangleF textEnclosingRectangle = new RectangleF(x, y, width, height);   
             
            //DrawString using overloaded method for         
            g.DrawString(
                text, 
                new Font("Arial", 8), 
                new SolidBrush(pen.Color),  //Create brush with same color as Pen selection
                textEnclosingRectangle
            );
        }
    }
}
