using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;//needed for button.

namespace MineSweeper
{
    class CSurroundCount:CNumbers
    {
        public CSurroundCount()
        {
            //constructor
        }

        public void ButtonSurround(Button myBtn, Button[,] btnGrd)
        {
            myButton = myBtn;
            btn_grid = btnGrd;
            //myBtn = myButton;
            //write some kind of if statement that checs for m or p buttons that are 0 and call this class with them as myBtn.
            //find and create surrounding buttons based on myButton.
            //call from Cnumbers.mineCount.
            for (int x = 0; x < 15; x++)                                        //for the horizontal buttons.
            {
                for (int y = 0; y < 15; y++)                                    //for the vertical buttons.
                {
                    if (btn_grid[x, y] == myButton)
                    {
                        if (myButton == btn_grid[0, 0])
                        {//top right corner.
                            //var myButtonP1 = btn_grid[x + 1, y];
                            //var myButtonP15 = btn_grid[x, y + 1];
                            //var myButtonP16 = btn_grid[x + 1, y + 1];

                            //if (myButtonP1.Text == " ") { mineCountInner++; }
                            //if (myButtonP15.Text == " ") { mineCountInner++; }
                            //if (myButtonP16.Text == " ") { mineCountInner++; }
                        }
                        else if (myButton == btn_grid[0, 14])
                        {//bottom left
                            //var myButtonP1 = btn_grid[x + 1, y];
                            //var myButtonM14 = btn_grid[x + 1, y - 1];
                            //var myButtonM15 = btn_grid[x, y - 1];

                            //if (myButtonP1.Text == " ") { mineCountInner++; }
                            //if (myButtonM14.Text == " ") { mineCountInner++; }
                            //if (myButtonM15.Text == " ") { mineCountInner++; }
                        }
                        else if (myButton == btn_grid[14, 0])
                        {//top right                            
                            //var myButtonP14 = btn_grid[x - 1, y + 1];
                            //var myButtonP15 = btn_grid[x, y + 1];
                            //var myButtonM1 = btn_grid[x - 1, y];

                            //if (myButtonP14.Text == " ") { mineCountInner++; }
                            //if (myButtonP15.Text == " ") { mineCountInner++; }
                            //if (myButtonM1.Text == " ") { mineCountInner++; }
                        }
                        else if (myButton == btn_grid[14, 14])
                        {//bottom left                   
                            //var myButtonM1 = btn_grid[x - 1, y];
                            //var myButtonM15 = btn_grid[x, y - 1];
                            //var myButtonM16 = btn_grid[x - 1, y - 1];

                            //if (myButtonM1.Text == " ") { mineCountInner++; }
                            //if (myButtonM15.Text == " ") { mineCountInner++; }
                            //if (myButtonM16.Text == " ") { mineCountInner++; }
                        }
                        else if (myButton == btn_grid[0, y])
                        { //side next to left border.
                            //var myButtonP1 = btn_grid[x + 1, y];
                            //var myButtonP15 = btn_grid[x, y + 1];
                            //var myButtonP16 = btn_grid[x + 1, y + 1];
                            //var myButtonM14 = btn_grid[x + 1, y - 1];
                            //var myButtonM15 = btn_grid[x, y - 1];
                            ////
                            //if (myButtonP1.Text == " ") { mineCountInner++; }
                            //if (myButtonP15.Text == " ") { mineCountInner++; }
                            //if (myButtonP16.Text == " ") { mineCountInner++; }
                            //if (myButtonM14.Text == " ") { mineCountInner++; }
                            //if (myButtonM15.Text == " ") { mineCountInner++; }
                        }
                        else if (myButton == btn_grid[14, y])
                        {//side next to right border.                           
                            //var myButtonP14 = btn_grid[x - 1, y + 1];
                            //var myButtonP15 = btn_grid[x, y + 1];
                            //var myButtonM1 = btn_grid[x - 1, y];
                            //var myButtonM15 = btn_grid[x, y - 1];
                            //var myButtonM16 = btn_grid[x - 1, y - 1];

                            //if (myButtonP14.Text == " ") { mineCountInner++; }
                            //if (myButtonP15.Text == " ") { mineCountInner++; }
                            //if (myButtonM1.Text == " ") { mineCountInner++; }
                            //if (myButtonM15.Text == " ") { mineCountInner++; }
                            //if (myButtonM16.Text == " ") { mineCountInner++; }
                        }
                        else if (myButton == btn_grid[x, 0])
                        {//side next to the top border.
                            //var myButtonP1 = btn_grid[x + 1, y];
                            //var myButtonP14 = btn_grid[x - 1, y + 1];
                            //var myButtonP15 = btn_grid[x, y + 1];
                            //var myButtonP16 = btn_grid[x + 1, y + 1];
                            //var myButtonM1 = btn_grid[x - 1, y];

                            //if (myButtonP1.Text == " ") { mineCountInner++; }
                            //if (myButtonP14.Text == " ") { mineCountInner++; }
                            //if (myButtonP15.Text == " ") { mineCountInner++; }
                            //if (myButtonP16.Text == " ") { mineCountInner++; }
                            //if (myButtonM1.Text == " ") { mineCountInner++; }
                        }
                        else if (myButton == btn_grid[x, 14])
                        {//side next to bottom border.
                            //var myButtonP1 = btn_grid[x + 1, y];
                            //var myButtonM1 = btn_grid[x - 1, y];
                            //var myButtonM14 = btn_grid[x + 1, y - 1];
                            //var myButtonM15 = btn_grid[x, y - 1];
                            //var myButtonM16 = btn_grid[x - 1, y - 1];

                            //if (myButtonP1.Text == " ") { mineCountInner++; }
                            //if (myButtonM1.Text == " ") { mineCountInner++; }
                            //if (myButtonM14.Text == " ") { mineCountInner++; }
                            //if (myButtonM15.Text == " ") { mineCountInner++; }
                            //if (myButtonM16.Text == " ") { mineCountInner++; }
                        }
                        else
                        {//Squares not next to a border.
                            var myButtonP1 = btn_grid[x + 1, y];//in relation to myButton
                            //p1
                            if (myButtonP1 == btn_grid[x + 1, y])
                            {
                                var p1p1 = btn_grid[x + 2, y];//x+1
                                var p1p14 = btn_grid[x, y + 1];//x-1
                                var p1p15 = btn_grid[x + 1, y + 1];//x
                                var p1p16 = btn_grid[x + 2, y + 1];//x+1

                                //var p1m1 = btn_grid[x - 1, y];
                                var p1m14 = btn_grid[x + 2, y - 1];
                                var p1m15 = btn_grid[x + 1, y - 1];
                                var p1m16 = btn_grid[x, y - 1];

                                int mineOuterCounterP1 = 0;
                                if (p1p1.Text == " ") { mineOuterCounterP1++; }
                                if (p1p14.Text == " ") { mineOuterCounterP1++; }
                                if (p1p15.Text == " ") { mineOuterCounterP1++; }
                                if (p1p16.Text == " ") { mineOuterCounterP1++; }

                                // if (p1m1.Text == " ") { mineOuterCounterP1++; }
                                if (p1m14.Text == " ") { mineOuterCounterP1++; }
                                if (p1m15.Text == " ") { mineOuterCounterP1++; }
                                if (p1m16.Text == " ") { mineOuterCounterP1++; }
                                if (mineOuterCounterP1 != 0)
                                {
                                    myButtonP1.Text = mineOuterCounterP1.ToString();
                                    DisplayCount(mineOuterCounterP1, myButtonP1);
                                }
                            }
                            var myButtonP14 = btn_grid[x - 1, y + 1];
                            //p14
                            if (myButtonP14 == btn_grid[x - 1, y + 1])
                            {
                                var p14p1 = btn_grid[x, y + 1];
                                var p14p14 = btn_grid[x - 2, y + 2];
                                var p14p15 = btn_grid[x - 1, y + 2];
                                var p14p16 = btn_grid[x, y + 2];

                                var p14m1 = btn_grid[x - 2, y + 1];
                                //var p14m14 = btn_grid[x + 2, y - 1];
                                var p14m15 = btn_grid[x - 1, y + 1];
                                var p14m16 = btn_grid[x - 2, y];

                                int mineOuterCounterP14 = 0;
                                if (p14p1.Text == " ") { mineOuterCounterP14++; }
                                if (p14p14.Text == " ") { mineOuterCounterP14++; }
                                if (p14p15.Text == " ") { mineOuterCounterP14++; }
                                if (p14p16.Text == " ") { mineOuterCounterP14++; }

                                if (p14m1.Text == " ") { mineOuterCounterP14++; }
                                //if (p14m14.Text == " ") { mineOuterCounterP1++; }
                                if (p14m15.Text == " ") { mineOuterCounterP14++; }
                                if (p14m16.Text == " ") { mineOuterCounterP14++; }
                                if (mineOuterCounterP14 != 0)
                                {
                                    myButtonP14.Text = mineOuterCounterP14.ToString();
                                    DisplayCount(mineOuterCounterP14, myButtonP14);
                                }
                            }
                            var myButtonP15 = btn_grid[x, y + 1];
                            //p15
                            if (myButtonP15 == btn_grid[x, y + 1])
                            {
                                var p15p1 = btn_grid[x + 1, y + 1];
                                var p15p14 = btn_grid[x - 1, y + 2];
                                var p15p15 = btn_grid[x, y + 2];
                                var p15p16 = btn_grid[x + 1, y + 2];

                                var p15m1 = btn_grid[x - 1, y + 1];
                                var p15m14 = btn_grid[x + 1, y];
                                //var p15m15 = btn_grid[x - 1, y + 1];
                                var p15m16 = btn_grid[x - 1, y];

                                int mineOuterCounterP15 = 0;
                                if (p15p1.Text == " ") { mineOuterCounterP15++; }
                                if (p15p14.Text == " ") { mineOuterCounterP15++; }
                                if (p15p15.Text == " ") { mineOuterCounterP15++; }
                                if (p15p16.Text == " ") { mineOuterCounterP15++; }

                                if (p15m1.Text == " ") { mineOuterCounterP15++; }
                                if (p15m14.Text == " ") { mineOuterCounterP15++; }
                                //if (p15m15.Text == " ") { mineOuterCounterP15++; }
                                if (p15m16.Text == " ") { mineOuterCounterP15++; }
                                if (mineOuterCounterP15 != 0)
                                {
                                    myButtonP15.Text = mineOuterCounterP15.ToString();
                                    DisplayCount(mineOuterCounterP15, myButtonP15);
                                }
                            }
                            var myButtonP16 = btn_grid[x + 1, y + 1];//start by getting the grid right.
                            //p16
                            if (myButtonP16 == btn_grid[x + 1, y + 1])
                            {
                                var p16p1 = btn_grid[x + 2, y + 1];
                                var p16p14 = btn_grid[x, y + 2];
                                var p16p15 = btn_grid[x + 1, y + 2];
                                var p16p16 = btn_grid[x + 2, y + 2];

                                var p16m1 = btn_grid[x, y + 1];
                                var p16m14 = btn_grid[x + 2, y];
                                var p16m15 = btn_grid[x + 1, y];
                                //var p16m16 = btn_grid[x - 1, y];

                                int mineOuterCounterP16 = 0;
                                if (p16p1.Text == " ") { mineOuterCounterP16++; }
                                if (p16p14.Text == " ") { mineOuterCounterP16++; }
                                if (p16p15.Text == " ") { mineOuterCounterP16++; }
                                if (p16p16.Text == " ") { mineOuterCounterP16++; }

                                if (p16m1.Text == " ") { mineOuterCounterP16++; }
                                if (p16m14.Text == " ") { mineOuterCounterP16++; }
                                if (p16m15.Text == " ") { mineOuterCounterP16++; }
                                //if (p16m16.Text == " ") { mineOuterCounterP16++; }
                                if (mineOuterCounterP16 != 0)
                                {
                                    myButtonP16.Text = mineOuterCounterP16.ToString();
                                    DisplayCount(mineOuterCounterP16, myButtonP16);
                                }
                            }
                            var myButtonM1 = btn_grid[x - 1, y];
                            //m1
                            if (myButtonM1 == btn_grid[x - 1, y])
                            {
                                //var m1p1 = btn_grid[x + 2, y + 1];
                                var m1p14 = btn_grid[x - 2, y + 1];
                                var m1p15 = btn_grid[x - 1, y + 1];
                                var m1p16 = btn_grid[x, y + 1];

                                var m1m1 = btn_grid[x - 2, y];
                                var m1m14 = btn_grid[x, y - 1];
                                var m1m15 = btn_grid[x - 1, y - 1];
                                var m1m16 = btn_grid[x - 2, y - 1];

                                int mineOuterCounterM1 = 0;
                                //if (m1p1.Text == " ") { mineOuterCounterM1++; }
                                if (m1p14.Text == " ") { mineOuterCounterM1++; }
                                if (m1p15.Text == " ") { mineOuterCounterM1++; }
                                if (m1p16.Text == " ") { mineOuterCounterM1++; }

                                if (m1m1.Text == " ") { mineOuterCounterM1++; }
                                if (m1m14.Text == " ") { mineOuterCounterM1++; }
                                if (m1m15.Text == " ") { mineOuterCounterM1++; }
                                if (m1m16.Text == " ") { mineOuterCounterM1++; }
                                if (mineOuterCounterM1 != 0)
                                {
                                    myButtonM1.Text = mineOuterCounterM1.ToString();
                                    DisplayCount(mineOuterCounterM1, myButtonM1);
                                }
                            }
                            var myButtonM14 = btn_grid[x + 1, y - 1];
                            //m14
                            if (myButtonM14 == btn_grid[x + 1, y - 1])
                            {
                                var m14p1 = btn_grid[x + 2, y - 1];
                                //var m14p14 = btn_grid[x - 2, y + 1];
                                var m14p15 = btn_grid[x + 1, y];
                                var m14p16 = btn_grid[x + 2, y];

                                var m14m1 = btn_grid[x, y - 1];
                                var m14m14 = btn_grid[x + 2, y - 2];
                                var m14m15 = btn_grid[x + 1, y - 2];
                                var m14m16 = btn_grid[x, y - 2];

                                int mineOuterCounterM14 = 0;
                                if (m14p1.Text == " ") { mineOuterCounterM14++; }
                                //if (m14p14.Text == " ") { mineOuterCounterM14++; }
                                if (m14p15.Text == " ") { mineOuterCounterM14++; }
                                if (m14p16.Text == " ") { mineOuterCounterM14++; }

                                if (m14m1.Text == " ") { mineOuterCounterM14++; }
                                if (m14m14.Text == " ") { mineOuterCounterM14++; }
                                if (m14m15.Text == " ") { mineOuterCounterM14++; }
                                if (m14m16.Text == " ") { mineOuterCounterM14++; }
                                if (mineOuterCounterM14 != 0)
                                {
                                    myButtonM14.Text = mineOuterCounterM14.ToString();
                                    DisplayCount(mineOuterCounterM14, myButtonM14);
                                }
                            }
                            var myButtonM15 = btn_grid[x, y - 1];
                            //m15
                            if (myButtonM15 == btn_grid[x, y - 1])
                            {
                                var m15p1 = btn_grid[x + 1, y - 1];
                                var m15p14 = btn_grid[x - 1, y];
                                //var m15p15 = btn_grid[x + 1, y];
                                var m15p16 = btn_grid[x + 1, y + 1];

                                var m15m1 = btn_grid[x - 1, y - 1];
                                var m15m14 = btn_grid[x + 1, y - 2];
                                var m15m15 = btn_grid[x, y - 2];
                                var m15m16 = btn_grid[x - 1, y - 2];

                                int mineOuterCounterM15 = 0;
                                if (m15p1.Text == " ") { mineOuterCounterM15++; }
                                if (m15p14.Text == " ") { mineOuterCounterM15++; }
                                //if (m15p15.Text == " ") { mineOuterCounterM15++; }
                                if (m15p16.Text == " ") { mineOuterCounterM15++; }

                                if (m15m1.Text == " ") { mineOuterCounterM15++; }
                                if (m15m14.Text == " ") { mineOuterCounterM15++; }
                                if (m15m15.Text == " ") { mineOuterCounterM15++; }
                                if (m15m16.Text == " ") { mineOuterCounterM15++; }
                                if (mineOuterCounterM15 != 0)
                                {
                                    myButtonM15.Text = mineOuterCounterM15.ToString();
                                    DisplayCount(mineOuterCounterM15, myButtonM15);
                                }
                            }
                            var myButtonM16 = btn_grid[x - 1, y - 1];
                            //m16
                            if (myButtonM16 == btn_grid[x - 1, y - 1])
                            {
                                var m16p1 = btn_grid[x, y - 1];
                                var m16p14 = btn_grid[x - 2, y];//
                                var m16p15 = btn_grid[x - 1, y];
                                //var m16p16 = btn_grid[x + 2, y];

                                var m16m1 = btn_grid[x - 2, y - 1];
                                var m16m14 = btn_grid[x, y - 2];
                                var m16m15 = btn_grid[x - 1, y - 2];
                                var m16m16 = btn_grid[x - 2, y - 2];

                                int mineOuterCounterM16 = 0;
                                if (m16p1.Text == " ") { mineOuterCounterM16++; }
                                if (m16p14.Text == " ") { mineOuterCounterM16++; }
                                if (m16p15.Text == " ") { mineOuterCounterM16++; }
                                //if (m16p16.Text == " ") { mineOuterCounterM16++; }

                                if (m16m1.Text == " ") { mineOuterCounterM16++; }
                                if (m16m14.Text == " ") { mineOuterCounterM16++; }
                                if (m16m15.Text == " ") { mineOuterCounterM16++; }
                                if (m16m16.Text == " ") { mineOuterCounterM16++; }
                                if (mineOuterCounterM16 != 0)
                                {
                                    myButtonM16.Text = mineOuterCounterM16.ToString();
                                    DisplayCount(mineOuterCounterM16, myButtonM16);     //doing it like this works.                               
                                }
                            }
                        }
                    }
                }
            }
            /*
              +----+----+----+                +----+----+----+ 
              |x-1 | x  |x+1 | y-1            | M16| M15|M14 |
              +----+----+----+                +----+----+----+
              |x-1 |mybn|x+1 | y      -->     | M1 |mybn| P1 |
              +----+----+----+                +----+----+----+
              |x-1 | x  |x+1 | y+1            |P14 | P15| P16|
              +----+----+----+                +----+----+----+ 
           */
            
        }

        Button[,] btn_grid;
        Button myButton;

        /// <summary>
        /// counts the amount of mines surrounding a button, 
        /// made to be called when no mines surround myButton and the 
        /// mines surrounding the buttons surrounding myButton need to 
        /// be counted.
        /// </summary>
        public void Count(Button myBtn, Button[,] btnGrd)
        {
            btn_grid = btnGrd;
            myButton = myBtn;
            int mineCountInner = 0;
            for (int x = 0; x < 15; x++)                                        //for the horizontal buttons.
            {
                for (int y = 0; y < 15; y++)                                    //for the vertical buttons.
                {
                    if (btnGrd[x, y] == myBtn)
                    {
                        if (myBtn == btnGrd[0, 0])
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
        }
    }
}
