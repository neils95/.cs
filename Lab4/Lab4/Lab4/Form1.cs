using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        //--------------Fields-------------------------------------------
        const int CHESS_SQUARE_SIZE = 50;
        const int CHESSBOARD_X = 100;
        const int CHESSBOARD_Y = 100;

        //Class to represnt on square on a chessboard
        public class ChessSquare
        {
            public int x, y, redCount;
            public bool isWhite, isQueen;

            public ChessSquare(int x, int y, bool isWhite)
            {
                this.x = x;
                this.y = y;
                this.isWhite = isWhite;
                isQueen = false;
                redCount = 0;
            }
        }

        //2D array to store Chessboard
        public static ChessSquare[,] ChessBoard = new ChessSquare[8, 8];

        public static bool hints;   //hints on or off

        public static int queenCount; //number of queens on board

        //---------------- Methods--------------------------------------------------------

        //Initialize the chessboard
        public static void InitializeChessBoard()
        {
            queenCount = 0;
            bool isWhite;
            for (int y = 0; y < 8; y++)
            {
                isWhite = (y % 2 == 0) ? false : true;
                for (int x = 0; x < 8; x++)
                {
                    ChessBoard[y, x] = new ChessSquare(CHESSBOARD_X + (x * 50), CHESSBOARD_Y + (y * 50), isWhite);
                    isWhite = !isWhite;
                }
            }
        }

        //Paint Chess Board 
        public void DrawChessBoard(Graphics g)
        {
            g.DrawString("You have " + queenCount + " queens",Font,Brushes.Black,200,15);
            Brush brush;
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    //Decide color of chess square
                    brush = (ChessBoard[y, x].isWhite) ? Brushes.White : Brushes.Black;
                   
                    //Check if hints are on
                    if (hints) brush = (ChessBoard[y, x].redCount>0) ? Brushes.Red : brush; //If its red default to red
                    

                    //Draw the chess square
                    g.FillRectangle(
                        brush,
                        ChessBoard[y, x].x,
                        ChessBoard[y, x].y,
                        CHESS_SQUARE_SIZE,
                        CHESS_SQUARE_SIZE
                    );

                    g.DrawRectangle(
                        Pens.Black,
                        ChessBoard[y, x].x,
                        ChessBoard[y, x].y,
                        CHESS_SQUARE_SIZE,
                        CHESS_SQUARE_SIZE
                    );

                    //Draw Queen
                    if (ChessBoard[y, x].isQueen)
                    {
                        //Color of Q must be reverse of the background chess square
                        Brush queenBrush = (ChessBoard[y, x].isWhite) ? Brushes.Black : Brushes.White;

                        //Draw Q if that Square contains a Q
                        g.DrawString("Q",
                            new Font(new FontFamily("Arial"), 30),
                            queenBrush,
                            ChessBoard[y, x].x,
                            ChessBoard[y, x].y
                        );
                    }
                }
            }
        }

        //Function to check if square contains a queen or if its a red square
        public static bool IsSquareValid(int xChessSquare, int yChessSquare)
        {
            if ((ChessBoard[yChessSquare, xChessSquare].redCount>0 )|| (ChessBoard[yChessSquare, xChessSquare].isQueen == true))
            {
                return false;
            }
            return true;
        }

        //Update the 2d array of the chessboard when a new queen is added. Takes coordinates of new queen
        public static void addOrRemoveQueen(int xChessSquare, int yChessSquare,bool addQueen)
        {
            int offset = (addQueen) ? 1 : -1;
            queenCount+=offset;
            ChessBoard[yChessSquare, xChessSquare].isQueen = addQueen;
            for (int y = 0; y < 8; y++)
            {
                ChessBoard[yChessSquare, y].redCount+=offset;
                ChessBoard[y, xChessSquare].redCount+=offset;
                for (int x = 0; x < 8; x++)
                {
                    if ((xChessSquare != x && yChessSquare != y) && //avoid divide by zero condition
                        Math.Abs(((float)(yChessSquare - y) / (float)(xChessSquare - x))) == 1) //check if it lies on diagonal
                    {
                        ChessBoard[y, x].redCount+=offset;
                    }
                }
            }      
        }

      
        //On mouse click
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X; int y = e.Y;
            //Check if clicked within board
            bool clickInChessboard = (x > CHESSBOARD_X
                && x < CHESSBOARD_X + (CHESS_SQUARE_SIZE * 8)
                && y > CHESSBOARD_Y
                && y < CHESSBOARD_Y + (CHESS_SQUARE_SIZE * 8)
            );

            if (e.Button == MouseButtons.Left && clickInChessboard)
            {
                //Location of ChessSquare which is clicked
                int xChessSquare = (x - CHESSBOARD_X) / CHESS_SQUARE_SIZE;
                int yChessSquare = (y - CHESSBOARD_Y) / CHESS_SQUARE_SIZE;

                if (IsSquareValid(xChessSquare, yChessSquare))
                {
                    addOrRemoveQueen(xChessSquare, yChessSquare,true);
                    this.Invalidate();
                    if (queenCount == 8)
                    {
                        MessageBox.Show("You have won!");
                    }

                }else
                {
                    System.Media.SystemSounds.Beep.Play();//Play Sound
                }

            }else if(e.Button == MouseButtons.Right && clickInChessboard)   //If Right click
            {

                //Location of ChessSquare which is clicked
                int xChessSquare = (x - CHESSBOARD_X) / CHESS_SQUARE_SIZE;
                int yChessSquare = (y - CHESSBOARD_Y) / CHESS_SQUARE_SIZE;

                //Check if its a queen, if yes remove queen
                if (ChessBoard[yChessSquare, xChessSquare].isQueen)
                {
                    addOrRemoveQueen(xChessSquare,yChessSquare,false);
                    this.Invalidate();        
                }
            }
        }

        //Clear button 
        private void button1_Click(object sender, EventArgs e)
        {
            InitializeChessBoard();
            this.Invalidate();
        }

        //Event Handler Checkbox for hints
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) hints = true;
            else hints = false;
            this.Invalidate();
        }

        public Form1()
        {
            InitializeComponent();
            this.MinimumSize = new Size(600, 600);  //ensnure minimum size
            InitializeChessBoard();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawChessBoard(e.Graphics); //Paint chessboard
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
