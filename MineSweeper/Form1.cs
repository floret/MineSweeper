using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Custom exeptions.
        class exMineFound : System.Exception { }//Stops the buttons from becoming green after a mine is found.        

        /// <summary>
        /// creates a grid of buttons that serves as the game "field".
        /// </summary>
        private Button createButton(int x, int y, int gridX, int gridY)
        {
            Button btn = new Button();
            btn.Text = "";                                                      //makes the button display nothing.
            btn.Name = gridX.ToString() + " " + gridY.ToString();               //names the new button its position within the grid.
            btn.Size = new System.Drawing.Size(30, 30);                         //makes the button 30 x 30 pixels big.
            btn.FlatStyle = FlatStyle.Flat;                                     //makes the buttons look more like a grid by making them look flat.
            btn.Location = new System.Drawing.Point(x, y);                      //uses the x and y values to determine where it will be drawn.
            panel1.Controls.AddRange(new System.Windows.Forms.Control[] { btn, });//adds the buttons to the panel.
            return btn;
        }
        private int[,] grid;
        private Button[,] btn_grid;                                             //array of buttons.
        int startX = 10, startY = 10;
        int mineXOutside = 0;                                                   //mine's x co-ordinate useble by all methods.
        int mineYOutside = 0;                                                   //mine's y co-ordinate useble by all methods.
        int XOutside = 0;                                                       //created so that the x value can be used by all methods
        int YOutside = 0;                                                       //created so that the y value can be used by all methods
        int GOFlag = 0;//Flag to show that the Game Over message has been displayed.

        /// <summary>
        /// This button starts or resets the game, by having a grid of buttons made and then randomly adding less than 70 mines to the grid.
        /// </summary>
        private void btnStart_Click(object sender, EventArgs e)
        {
            mineCountInner = 0;
            GOFlag = 0;//make the buttons able to clicked again.
            panel1.Controls.Clear();                                            //enables the game to restart if the start button is clicked.            
            grid = new int[15, 15];
            btn_grid = new Button[15, 15];
            for (int x = 0; x < 15; x++)                                        //for the horizontal buttons.
            {
                for (int y = 0; y < 15; y++)                                    //for the vertical buttons.
                {//populates the btn_grid array, which is an array of buttons, with buttons made with the createButton method.
                    btn_grid[x, y] = createButton(startX + 24 * (x + 0), startY + 24 * (y + 0), x, y);//creates the button grid by calling the createButton method.
                    grid[x, y] = 0;
                    YOutside = y;
                    XOutside = x;
                }
            }
            //Add mines.
            Random rand = new Random();                                          //creates a random (variable?)
            int mineCount = 0;
            do
            {
                int mineX = rand.Next(15);
                int mineY = rand.Next(15);

                if (grid[mineX, mineY] == 0)
                {//the mines are hidden by making their text properties " "
                    btn_grid[mineX, mineY].Text = " ";                          //used to hide the mines in plain unsight.
                    btn_grid[mineX, mineY].Font = new Font("Microsoft Sans Serif", 10f, btn_grid[mineX, mineY].Font.Style, btn_grid[mineX, mineY].Font.Unit);
                    btn_grid[mineX, mineY].Location = new System.Drawing.Point(btn_grid[mineX, mineY].Location.X, btn_grid[mineX, mineY].Location.Y);//location of new square is next to old square
                    mineCount++;
                    mineXOutside = mineX;
                    mineYOutside = mineY;
                }
            }
            while (mineCount != 40);//70 makes it insanely difficult. //!creates less than the specified amount of mines.

            foreach (Button btn in btn_grid)
            {
                btn.Click += new EventHandler(MineClickedOrNot);                //click event handler for the grid of buttons.
            }
            lblMineCount.Text = "Mines Left: " + mineCount.ToString();//displays the amount of mines that are left.
        }


        /// <summary>
        /// When the user clicks on a button in the button grid, this method checks whether it contains a
        /// mine or not, if it does it changes the colour of the button to red and reveils the location of 
        /// the other mines and if it doesn't, it changes the button's colour to green.
        /// </summary>
        int mineCountInner = 0;
        private void MineClickedOrNot(object sender, EventArgs e)               //click event handler for the grid of buttons.
        {
            var myButton = (Button)sender;                                      //makes the button in the grid that the user clicked myButton.
            //Count Mines:
            //Button[x,y]
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

            //Checks for mines in myButton
            try//mine found in myButton
            {
                if (myButton.Text == " ")                                           //if the button contains a mine.
                {
                    myButton.BackColor = Color.Red;
                    foreach (Button btn in btn_grid)                                //for all the buttons in the grid.
                    {
                        if (btn.Text == " ")                                        //if the button contains a mine
                        {
                            btn.BackColor = Color.Red;                              //make  the button red
                            btn.Text = "*";                                         //and make it contain a "*" which represents a mine.                            
                        }
                    }
                }
                else//mine not found in myButton
                {
                    if (GOFlag == 0)//GOFlag --> Game Over Flag.
                    {
                        if (mineCountInner == 0)//expand and count surrounding squares' mines.
                        {
                            myButton.BackColor = Color.Gray;
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
                                                var p1m15 = btn_grid[x+1, y - 1];
                                                var p1m16 = btn_grid[x , y - 1];

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
                                                    myButtonP1.Text = mineOuterCounterP1.ToString();//!always 0
                                                }
                                            }
                                            var myButtonP14=btn_grid[x-1,y+1];
                                            //p14
                                            if (myButtonP14 == btn_grid[x - 1, y + 1])
                                            {
                                                var p14p1 = btn_grid[x , y+1];
                                                var p14p14 = btn_grid[x-2, y +2];
                                                var p14p15 = btn_grid[x -1, y +2];
                                                var p14p16 = btn_grid[x , y + 2];

                                                var p14m1 = btn_grid[x -2, y+1];
                                                //var p14m14 = btn_grid[x + 2, y - 1];
                                                var p14m15 = btn_grid[x -1, y +1];
                                                var p14m16 = btn_grid[x-2, y];

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
                                                    myButtonP14.Text = mineOuterCounterP14.ToString();//!always 0
                                                }
                                            }
                                            var myButtonP15 = btn_grid[x , y + 1];
                                            //p15
                                            if (myButtonP15 == btn_grid[x , y + 1])
                                            {
                                                var p15p1 = btn_grid[x+1, y + 1];
                                                var p15p14 = btn_grid[x - 1, y + 2];
                                                var p15p15 = btn_grid[x , y + 2];
                                                var p15p16 = btn_grid[x+1, y + 2];

                                                var p15m1 = btn_grid[x - 1, y + 1];
                                                var p15m14 = btn_grid[x + 1, y ];
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
                                                    myButtonP15.Text = mineOuterCounterP15.ToString();//!always 0
                                                }
                                            }
                                            var myButtonP16 = btn_grid[x, y + 1];//start by getting the grid right.
                                            //p16
                                            if (myButtonP16 == btn_grid[x, y + 1])
                                            {
                                                var p15p1 = btn_grid[x + 1, y + 1];
                                                var p15p14 = btn_grid[x - 1, y + 2];
                                                var p15p15 = btn_grid[x, y + 2];
                                                var p15p16 = btn_grid[x + 1, y + 2];

                                                var p15m1 = btn_grid[x - 1, y + 1];
                                                var p15m14 = btn_grid[x + 1, y];
                                                var p15m15 = btn_grid[x - 1, y + 1];
                                                var p15m16 = btn_grid[x - 1, y];

                                                int mineOuterCounterP16 = 0;
                                                if (p15p1.Text == " ") { mineOuterCounterP16++; }
                                                if (p15p14.Text == " ") { mineOuterCounterP16++; }
                                                if (p15p15.Text == " ") { mineOuterCounterP16++; }
                                                if (p15p16.Text == " ") { mineOuterCounterP16++; }

                                                if (p15m1.Text == " ") { mineOuterCounterP16++; }
                                                if (p15m14.Text == " ") { mineOuterCounterP16++; }
                                                if (p15m15.Text == " ") { mineOuterCounterP16++; }
                                                if (p15m16.Text == " ") { mineOuterCounterP16++; }
                                                if (mineOuterCounterP16 != 0)
                                                {
                                                    myButtonP15.Text = mineOuterCounterP16.ToString();//!always 0
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            //TODO: count the mines surrounding the squares that surround myButton.

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
                        else if (mineCountInner == 1)
                        {
                            myButton.Text = "1";
                            myButton.ForeColor = Color.Green;
                            myButton.BackColor = Color.LightGray;
                        }
                        else if (mineCountInner == 2)
                        {
                            myButton.Text = "2";
                            myButton.ForeColor = Color.Blue;
                            myButton.BackColor = Color.LightGray;
                        }
                        else if (mineCountInner == 3)
                        {
                            myButton.Text = "3";
                            myButton.ForeColor = Color.Red;
                            myButton.BackColor = Color.LightGray;
                        }
                        else if (mineCountInner == 4)
                        {
                            myButton.Text = "4";
                            myButton.ForeColor = Color.DarkBlue;
                            myButton.BackColor = Color.LightGray;
                        }
                        else if (mineCountInner == 5)
                        {
                            myButton.Text = "5";
                            myButton.ForeColor = Color.Orange;//find out colors from here on up.
                            myButton.BackColor = Color.LightGray;
                        }
                        else if (mineCountInner == 6)
                        {
                            myButton.Text = "6";
                            myButton.ForeColor = Color.LightBlue;
                            myButton.BackColor = Color.LightGray;
                        }
                        else if (mineCountInner == 7)
                        {
                            myButton.Text = "7";
                            myButton.ForeColor = Color.Cyan;
                            myButton.BackColor = Color.LightGray;
                        }
                        else if (mineCountInner == 8)
                        {
                            myButton.Text = "8";
                            myButton.ForeColor = Color.White;
                            myButton.BackColor = Color.LightGray;
                        }
                        mineCountInner = 0;
                    }
                }
                if ((myButton.Text == "*") && (GOFlag != 1))//the &&(GOFlag!=1) prevents the Game Over message from being displayed more than once a round.
                {
                    throw new exMineFound();
                }
            }
            catch (exMineFound)//happens when a mine is clicked on.
            {
                MessageBox.Show("Game Over");
                GOFlag = 1;//used to determine if the Game Over message has already been displayed or not.
            }
            //
            //TODO: make squares flagable.
            //foreach (Button btn in btn_grid)
            //{
            //    btn.Click += new MouseEventHandler(FlagMine);                //make right click.
            //}

            //private void FlagMine(object sender, EventArgs e)//for when the user flags a mine.
            //{
            //    //if mine is flagged, decrease mine count.
            //}

            //            
        }
        //
        //private void FlagMine(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Right)
        //    {

        //    }
        //}
        //
    }
}
//TODO: if mine count 0 --> detect whether or not the squares surrounding the squares that surround mybutton contain mines, if they do increment their counters.
//TODO: make squares flagable.
//TODO: make a win message.
//TODO: Shorten code by removing redundancy.
//TODO: make different difficulty settings.
