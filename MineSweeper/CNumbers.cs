﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;//needed for color.
using System.Windows.Forms;//needed for button.

namespace MineSweeper
{
    class CNumbers
    {
        public CNumbers()
        {
            //constructor.
        }

        CSurroundCount SurroundCount = new CSurroundCount();

        /// <summary>
        /// Decides which fore- and backcolor to make the selected 
        /// button and what number to display as it's text.
        /// </summary>
        public void DisplayCount(int numOfMines, Button myBtn)
        {
            if (numOfMines == 0)//expand and count surrounding squares' mines.
            {
                myBtn.BackColor = Color.Gray;
                SurroundCount.ButtonSurround(myBtn, btn_grid);
            }
            else if (numOfMines == 1)
            {
                myBtn.Text = "1";
                myBtn.ForeColor = Color.Green;
                myBtn.BackColor = Color.LightGray;
            }
            else if (numOfMines == 2)
            {
                myBtn.Text = "2";
                myBtn.ForeColor = Color.Blue;
                myBtn.BackColor = Color.LightGray;
            }
            else if (numOfMines == 3)
            {
                myBtn.Text = "3";
                myBtn.ForeColor = Color.Red;
                myBtn.BackColor = Color.LightGray;
            }
            else if (numOfMines == 4)
            {
                myBtn.Text = "4";
                myBtn.ForeColor = Color.DarkBlue;
                myBtn.BackColor = Color.LightGray;
            }
            else if (numOfMines == 5)
            {
                myBtn.Text = "5";
                myBtn.ForeColor = Color.Orange;//find out colors from here on up.
                myBtn.BackColor = Color.LightGray;
            }
            else if (numOfMines == 6)
            {
                myBtn.Text = "6";
                myBtn.ForeColor = Color.LightBlue;
                myBtn.BackColor = Color.LightGray;
            }
            else if (numOfMines == 7)
            {
                myBtn.Text = "7";
                myBtn.ForeColor = Color.Cyan;
                myBtn.BackColor = Color.LightGray;
            }
            else if (numOfMines == 8)
            {
                myBtn.Text = "8";
                myBtn.ForeColor = Color.White;
                myBtn.BackColor = Color.LightGray;
            }
        }

        int mineCountInner = 0;
        Button[,] btn_grid;
        Button myButton;

        /// <summary>
        /// Counts the number of mines surrounding a button.
        /// </summary>
        public int MineCount(Button myBtn, Button[,] btnGrd)
        {
            mineCountInner = 0;
            btn_grid = btnGrd;
            myButton = myBtn;
            for (int x = 0; x < 15; x++)                                        //for the horizontal buttons.
            {
                for (int y = 0; y < 15; y++)                                    //for the vertical buttons.
                {
                    if (btn_grid[x, y] == myButton)
                    {
                        if (myButton == btn_grid[0, 0])
                        {//top right corner.
                            var myButtonP1 = btn_grid[x + 1, y];
                            var myButtonP15 = btn_grid[x, y + 1];
                            var myButtonP16 = btn_grid[x + 1, y + 1];

                            if (myButtonP1.Text == " ") { mineCountInner++; }
                            if (myButtonP15.Text == " ") { mineCountInner++; }
                            if (myButtonP16.Text == " ") { mineCountInner++; }
                        }
                        else if (myButton == btn_grid[0, 14])
                        {//bottom left
                            var myButtonP1 = btn_grid[x + 1, y];
                            var myButtonM14 = btn_grid[x + 1, y - 1];
                            var myButtonM15 = btn_grid[x, y - 1];

                            if (myButtonP1.Text == " ") { mineCountInner++; }
                            if (myButtonM14.Text == " ") { mineCountInner++; }
                            if (myButtonM15.Text == " ") { mineCountInner++; }
                        }
                        else if (myButton == btn_grid[14, 0])
                        {//top right                            
                            var myButtonP14 = btn_grid[x - 1, y + 1];
                            var myButtonP15 = btn_grid[x, y + 1];
                            var myButtonM1 = btn_grid[x - 1, y];

                            if (myButtonP14.Text == " ") { mineCountInner++; }
                            if (myButtonP15.Text == " ") { mineCountInner++; }
                            if (myButtonM1.Text == " ") { mineCountInner++; }
                        }
                        else if (myButton == btn_grid[14, 14])
                        {//bottom left                   
                            var myButtonM1 = btn_grid[x - 1, y];
                            var myButtonM15 = btn_grid[x, y - 1];
                            var myButtonM16 = btn_grid[x - 1, y - 1];

                            if (myButtonM1.Text == " ") { mineCountInner++; }
                            if (myButtonM15.Text == " ") { mineCountInner++; }
                            if (myButtonM16.Text == " ") { mineCountInner++; }
                        }
                        else if (myButton == btn_grid[0, y])
                        { //side next to left border.
                            var myButtonP1 = btn_grid[x + 1, y];
                            var myButtonP15 = btn_grid[x, y + 1];
                            var myButtonP16 = btn_grid[x + 1, y + 1];
                            var myButtonM14 = btn_grid[x + 1, y - 1];
                            var myButtonM15 = btn_grid[x, y - 1];
                            //
                            if (myButtonP1.Text == " ") { mineCountInner++; }
                            if (myButtonP15.Text == " ") { mineCountInner++; }
                            if (myButtonP16.Text == " ") { mineCountInner++; }
                            if (myButtonM14.Text == " ") { mineCountInner++; }
                            if (myButtonM15.Text == " ") { mineCountInner++; }
                        }
                        else if (myButton == btn_grid[14, y])
                        {//side next to right border.                           
                            var myButtonP14 = btn_grid[x - 1, y + 1];
                            var myButtonP15 = btn_grid[x, y + 1];
                            var myButtonM1 = btn_grid[x - 1, y];
                            var myButtonM15 = btn_grid[x, y - 1];
                            var myButtonM16 = btn_grid[x - 1, y - 1];

                            if (myButtonP14.Text == " ") { mineCountInner++; }
                            if (myButtonP15.Text == " ") { mineCountInner++; }
                            if (myButtonM1.Text == " ") { mineCountInner++; }
                            if (myButtonM15.Text == " ") { mineCountInner++; }
                            if (myButtonM16.Text == " ") { mineCountInner++; }
                        }
                        else if (myButton == btn_grid[x, 0])
                        {//side next to the top border.
                            var myButtonP1 = btn_grid[x + 1, y];
                            var myButtonP14 = btn_grid[x - 1, y + 1];
                            var myButtonP15 = btn_grid[x, y + 1];
                            var myButtonP16 = btn_grid[x + 1, y + 1];
                            var myButtonM1 = btn_grid[x - 1, y];

                            if (myButtonP1.Text == " ") { mineCountInner++; }
                            if (myButtonP14.Text == " ") { mineCountInner++; }
                            if (myButtonP15.Text == " ") { mineCountInner++; }
                            if (myButtonP16.Text == " ") { mineCountInner++; }
                            if (myButtonM1.Text == " ") { mineCountInner++; }
                        }
                        else if (myButton == btn_grid[x, 14])
                        {//side next to bottom border.
                            var myButtonP1 = btn_grid[x + 1, y];
                            var myButtonM1 = btn_grid[x - 1, y];
                            var myButtonM14 = btn_grid[x + 1, y - 1];
                            var myButtonM15 = btn_grid[x, y - 1];
                            var myButtonM16 = btn_grid[x - 1, y - 1];

                            if (myButtonP1.Text == " ") { mineCountInner++; }
                            if (myButtonM1.Text == " ") { mineCountInner++; }
                            if (myButtonM14.Text == " ") { mineCountInner++; }
                            if (myButtonM15.Text == " ") { mineCountInner++; }
                            if (myButtonM16.Text == " ") { mineCountInner++; }
                        }
                        else
                        {//Squares not next to a border.
                            var myButtonP1 = btn_grid[x + 1, y];
                            var myButtonP14 = btn_grid[x - 1, y + 1];
                            var myButtonP15 = btn_grid[x, y + 1];
                            var myButtonP16 = btn_grid[x + 1, y + 1];

                            var myButtonM1 = btn_grid[x - 1, y];
                            var myButtonM14 = btn_grid[x + 1, y - 1];
                            var myButtonM15 = btn_grid[x, y - 1];
                            var myButtonM16 = btn_grid[x - 1, y - 1];
                            /*
                                +----+----+----+                +----+----+----+ 
                                |x-1 | x  |x+1 | y-1            | M16| M15|M14 |
                                +----+----+----+                +----+----+----+
                                |x-1 |mybn|x+1 | y      -->     | M1 |mybn| P1 |
                                +----+----+----+                +----+----+----+
                                |x-1 | x  |x+1 | y+1            |P14 | P15| P16|
                                +----+----+----+                +----+----+----+ 
                            */
                            if (myButtonP1.Text == " ") { mineCountInner++; }
                            if (myButtonP14.Text == " ") { mineCountInner++; }
                            if (myButtonP15.Text == " ") { mineCountInner++; }
                            if (myButtonP16.Text == " ") { mineCountInner++; }

                            if (myButtonM1.Text == " ") { mineCountInner++; }
                            if (myButtonM14.Text == " ") { mineCountInner++; }
                            if (myButtonM15.Text == " ") { mineCountInner++; }
                            if (myButtonM16.Text == " ") { mineCountInner++; }
                        }
                    }
                }
            }
            return mineCountInner;
        }
    }
}