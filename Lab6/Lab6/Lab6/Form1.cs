﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form1 : Form
    {
        //dimensions        
        private const float clientSize = 100;
        private const float lineLength = 80;        
        private const float block = lineLength / 3; //size of block
        const float offset = 10;
        private const float delta = 5;

        private float scale;    //current scale factor 

        public Form1()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            ApplyTransform(g);

            //draw board             
            g.DrawLine(Pens.Black, block, 0, block, lineLength);         //block = 26.33
            g.DrawLine(Pens.Black, 2 * block, 0, 2 * block, lineLength);
            g.DrawLine(Pens.Black, 0, block, lineLength, block);
            g.DrawLine(Pens.Black, 0, 2 * block, lineLength, 2 * block);

            for (int i = 0; i < 3; ++i)
                for (int j = 0; j < 3; ++j)
                    if (GameEngine.Grid[i, j] == GameEngine.CellSelection.O) DrawO(i, j, g);
                    else if (GameEngine.Grid[i, j] == GameEngine.CellSelection.X) DrawX(i, j, g);
        }

        private void ApplyTransform(Graphics g)
        {
            scale = Math.Min(ClientRectangle.Width / clientSize, ClientRectangle.Height / clientSize);
            if (scale == 0f) return;
            g.ScaleTransform(scale, scale);
            g.TranslateTransform(offset, offset);
        }

        private void DrawX(int i, int j, Graphics g)
        {
            g.DrawLine(Pens.Black, i * block + delta, j * block + delta, (i * block) + block - delta, (j * block) + block - delta);
            g.DrawLine(Pens.Black, (i * block) + block - delta, j * block + delta, (i * block) + delta, (j * block) + block - delta);
        }
        private void DrawO(int i, int j, Graphics g)
        {
            g.DrawEllipse(Pens.Black, i * block + delta, j * block + delta, block - 2 * delta, block - 2 * delta);
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //If game is already over do nothing
            if (GameEngine.GameOver)
            {
                return;
            }
            Graphics g = CreateGraphics();
            ApplyTransform(g);
            PointF[] p = { new Point(e.X, e.Y) };
            g.TransformPoints(CoordinateSpace.World, CoordinateSpace.Device, p);
            if (p[0].X < 0 || p[0].Y < 0) return;

            int i = (int)(p[0].X / block);
            int j = (int)(p[0].Y / block);

            //if click is outside the tic tac toe board
            if (i > 2 || j > 2) return;

            /*If it is a left click and if it is a valid move, 
              draw it and if it is user turn and game is not over*/
            if ((e.Button == MouseButtons.Left) && (GameEngine.PlayUserMove(i, j)==true))
            {
                Invalidate();
                //Check if game is over
                if (GameEngine.IsGameOver())
                {
                    MessageBox.Show(GameEngine.GameOverString());
                }
                else
                {
                    //play computer's move
                    GameEngine.PlayComputerMove();

                    //Check if game is over
                    if (GameEngine.IsGameOver())
                    {
                        MessageBox.Show(GameEngine.GameOverString());
                    }
                }
            } 
           
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameEngine.InitializeBoard();
            Invalidate();
        }

        private void computerStartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameEngine.PlayerTurn = false;
            GameEngine.PlayComputerMove();
            Invalidate();
        }
    }
}
  
