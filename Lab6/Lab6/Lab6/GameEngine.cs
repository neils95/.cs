using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    static class GameEngine
    {
        public static int GameOverStatus;
        public static bool GameOver = false;
        public static bool PlayerTurn = true;
        public enum CellSelection { N = 0, O = -1, X = 1 };
        public static CellSelection[,] Grid = new CellSelection[3, 3];
       
        public static void InitializeBoard()
        {
            for(int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Grid[i, j] = CellSelection.N;
                }
            }
            GameOver = false;
            PlayerTurn = true;
            GameOverStatus = 2;
        }

        //Play a move on the selected cell
        public static bool PlayUserMove(int i, int j)
        {
            //Only allow setting empty cells            
            if ((PlayerTurn) &&(Grid[i, j] == CellSelection.N))
            {
                Grid[i, j] = CellSelection.X;
                SwitchTurn();
                return true;
            }
            return false;
            
        }

        //Play the computer's move
        public static void PlayComputerMove()
        {
            //Play winning move
            if (WinningMove() == true)
            {
                SwitchTurn();
            }
            else if (BlockingMove() == true)
            {
                SwitchTurn();
            }
            else
            {
                //Play random move
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (Grid[i, j] == CellSelection.N)
                        {
                            Grid[i, j] = CellSelection.O;
                            SwitchTurn();
                            return;
                        }
                    }
                }
            }
        }

        //check if blocking move available
        public static bool BlockingMove()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Grid[i, j] == CellSelection.N)
                    {
                        Grid[i, j] = CellSelection.X;
                        if (IsGameOver() == true)
                        {
                            Grid[i, j] = CellSelection.O;
                            GameOver = false;
                            return true;
                        }
                        else
                        {
                            Grid[i, j] = CellSelection.N;
                            GameOver = false;
                        }
                    }
                }
            }
            return false;
        }

        //Check if winning move available
        public static bool WinningMove()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Grid[i, j] == CellSelection.N)
                    {
                        Grid[i, j] = CellSelection.O;
                        if (IsGameOver() == true) return true;
                        else
                        {
                            Grid[i, j] = CellSelection.N;
                            GameOver = false;
                        }
                    }
                }
            }
            return false;
        }

        //Flip player turn
        public static void SwitchTurn()
        {
            PlayerTurn = !PlayerTurn;
        }

        //Check if game over
        public static bool IsGameOver()
        {
            //Check left diagonal
            if (LeftDiagonalComplete()) GameOver = true;
            else if (RightDiagonalComplete()) GameOver = true;
            else if (RowComplete()) GameOver = true;
            else if (ColumnComplete()) GameOver = true;
            else if (GameTied()) GameOver = true;

            return GameOver;
        }
        //Wininng string
        public static string GameOverString()
        {
            if (GameOverStatus == -1) return "The Computer has won the game";
            else if (GameOverStatus == 1) return "The Player has won the game";
            return "The game is a draw";
        }

        //Functions to test if its over
        public static bool LeftDiagonalComplete()
        {
            int xCount = 0, oCount = 0;
            for (int i = 0; i < 3; i++)
            {
                xCount += (Grid[i, i] == CellSelection.X) ? 1 : 0;
                oCount += (Grid[i, i] == CellSelection.O) ? 1 : 0;
            }
            if (xCount == 3)
            {
                GameOverStatus = 1;
                return true;
            }
            if (oCount == 3)
            {
                GameOverStatus = -1;
                return true;
            }
            return false;
        }
        public static bool RightDiagonalComplete()
        {
            int xCount = 0, oCount = 0;
            for (int i = 0; i < 3; i++)
            {
                xCount += (Grid[i, 2-i] == CellSelection.X) ? 1 : 0;
                oCount += (Grid[i, 2-i] == CellSelection.O) ? 1 : 0;
            }
            if (xCount == 3)
            {
                GameOverStatus = 1;
                return true;
            }
            if (oCount == 3)
            {
                GameOverStatus = -1;
                return true;
            }
            return false;
        }
        public static bool RowComplete()
        {
            for (int j=0;j<3;j++)
            {
                int xCount = 0, oCount = 0;
                for (int i = 0; i < 3; i++)
                {
                    xCount += (Grid[i, j] == CellSelection.X) ? 1 : 0;
                    oCount += (Grid[i, j] == CellSelection.O) ? 1 : 0;
                }

                if (xCount == 3)
                {
                    GameOverStatus = 1;
                    return true;
                }
                if (oCount == 3)
                {
                    GameOverStatus = -1;
                    return true;
                }
            }
            return false;
        }
        public static bool ColumnComplete()
        {
            for (int j = 0; j < 3; j++)
            {
                int xCount = 0, oCount = 0;
                for (int i = 0; i < 3; i++)
                {
                    xCount += (Grid[j, i] == CellSelection.X) ? 1 : 0;
                    oCount += (Grid[j, i] == CellSelection.O) ? 1 : 0;
                }

                if (xCount == 3)
                {
                    GameOverStatus = 1;
                    return true;
                }
                if (oCount == 3)
                {
                    GameOverStatus = -1;
                    return true;
                }
            }
            return false;
        }
        public static bool GameTied()
        {
            int n_Count=0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Grid[i, j] == CellSelection.N) n_Count++;
                }
            }
            if (n_Count == 0)
            {
                GameOverStatus = 0;
                return true;
            }
            return false;
          
        }

    }
}
