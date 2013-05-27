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
        int mineXOutside = 0;
        int mineYOutside = 0;
        int XOutside = 0;
        int YOutside = 0;

        /// <summary>
        /// This button starts the game, by having a grid of buttons made and then randomly adding less than 70 mines to the grid.
        /// </summary>
        private void btnStart_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();                                            //enables the game to restart if the start button is clicked.            
            grid = new int[/*width, height*/15, 15];
            btn_grid = new Button[/*width, height*/15, 15];                     //lol I have no idea what I'm doing.
            for (int x = 0; x < 15; x++)                                        //for the horizontal buttons.
            {
                for (int y = 0; y < 15; y++)                                    //for the vertical buttons.
                {//populates the btn_grid array, which is an array of buttons, with buttons made with the createButton method.
                    btn_grid[x, y] = createButton(startX + 24 * (x + 0), startY + 24 * (y + 0), x, y);
                    grid[x, y] = 0;
                    YOutside = y;
                    XOutside = x;
                }
            }
            //Add mines.
            Random rand = new Random();                                          //creates a random (variable?)
            int mineCount = 0;
            do
            {//add comments from other copy of minesweeper.
                int mineX = rand.Next(15);
                int mineY = rand.Next(15);

                if (grid[mineX, mineY] == 0)
                {
                    btn_grid[mineX, mineY].Text = "*";
                    btn_grid[mineX, mineY].Font = new Font("Microsoft Sans Serif", 10f, btn_grid[mineX, mineY].Font.Style, btn_grid[mineX, mineY].Font.Unit);
                    btn_grid[mineX, mineY].Location = new System.Drawing.Point(btn_grid[mineX, mineY].Location.X, btn_grid[mineX, mineY].Location.Y);
                    grid[mineX, mineY] = -1; //Add a mine //? not sure why.
                    mineCount++;
                    mineXOutside = mineX;
                    mineYOutside = mineY;
                    //TODO: somehow populate an array with the positions of the mined buttons in the grid.
                    //this array should then be used in place of: btn_grid[XOutside, YOutside].Text
                }
            }
            while (mineCount <= 70);
            //huge success: found out this only refers to the last button created.
            foreach (Button btn in btn_grid)
            {
                btn.Click += new EventHandler(MineClickedOrNot);
            }
        }

        /// <summary>
        /// When the user clicks on a button in the button grid, this method checks whether it contains a
        /// mine or not, if it does it changes the colour of the button to red and if it doesn't, it 
        /// changes its colour to green.
        /// </summary>
        private void MineClickedOrNot(object sender, EventArgs e)//click event handler for the grid of buttons.
        {// !currently only applies to the last button in the grid.
            var myButton = (Button)sender;
            if (myButton.Text == "*")
            {
                myButton.BackColor=Color.Red;
            }
            else
            {
                myButton.BackColor=Color.Green;
            }
            //Still trying to get the buttons to respond.   
            //foreach this.Click try using this.
            //for (int x = 0; x < 15; x++)                                        //for the horizontal buttons.
            //{
            //    for (int y = 0; y < 15; y++)                                    //for the vertical buttons.
            //    {
            //        if (btn_grid[x, y].Text == " ")
            //        {
            //            btn_grid[x, y].BackColor = Color.Red;
            //            //break;//!makes it colour all the top row of buttons.                        
            //            //is clicked on, but it can only change the text of a single mined
            //            //button, the last to be mined.
            //        }
            //        else
            //        {
            //            btn_grid[x, y].BackColor = Color.Green;
            //            //break;//!makes it colour all the top row of buttons.
            //            //?does x,y refer to the entire row?
            //        }
            //    }
            //}
            //////foreach (Button btn in btn_grid)//!same thing either entire grid or single button.
            //////{
            //////    int count1 = 0; int count2 = 0; int turns = 0;
            //////    //
            //////    do
            //////    {
            //////        if (count1 == 16) { count2++; count1 = 0; }
            //////        if (btn.Text == "*")
            //////        {

            //////            //this.BackColor = Color.Red;
            //////            btn.BackColor = Color.Red;
            //////            //break;
            //////        }
            //////        else
            //////        {
            //////            //this.BackColor = Color.Green;
            //////            btn.BackColor = Color.Green;
            //////            //break;
            //////        }
            //////        count1++;
            //////    }
            //////    while (count2 != 16);
                //
                //if (btn.Text != "*")
                //{
                    
                //    this.BackColor = Color.Red;
                //    //btn.BackColor = Color.Red;
                //    //break;//!makes it colour all the top row of buttons.                        
                //    //is clicked on, but it can only change the text of a single mined
                //    //button, the last to be mined.
                //    //break;//!makes only the first button work.
                //}
                //else
                //{
                //    this.BackColor = Color.Green;
                //    //btn.BackColor = Color.Green;
                //    //break;//!makes it colour all the top row of buttons.
                //    //?does x,y refer to the entire row?
                //    //break;//!makes only the first button work.
                //}
            //}
            //!makes the only button that works 14,14
            //foreach (Button btn in btn_grid)
            //{
            //    for (int x = 0; x < 15; x++)                                        //for the horizontal buttons. 
            //    {
            //        for (int y = 0; y < 15; y++)                                    //for the vertical buttons.
            //        {
            //            if (btn_grid[x, y].Text == " ")// change to " "
            //            {//!changes the colour for all the buttons in the first horizontal row.
            //                btn_grid[x, y].BackColor = Color.Red;
            //                break;//!makes it colour all the top row of buttons.
            //                //btn_grid[mineXOutside, mineYOutside].Text = "*";//huge success: It is able to determine whether or not a mine //!adds to squares that dont get coloured.
            //                //is clicked on, but it can only change the text of a single mined
            //                //button, the last to be mined.
            //            }
            //            else /*if (btn_grid[x, y].Text != " ")*/ //makes no difference.
            //            {
            //                btn_grid[x, y].BackColor = Color.Green;
            //                break;//!makes it colour all the top row of buttons.//?does x,y refer to the entire row?
            //            }
            //        }
            //    }
            //}
            //it might be possible to do it using a while or do statement, by using two iteraters, x&y, but only using one for the while/do.***
        }
    }
}
//TODO: make a method that when a button in the grid is clicked on checks whether or not it contains a mine or not.

//TODO: Make the color of a button green if it is clicked on and doesn't contain a mine.
//TODO: Make the color of a button red if it is clicked on and contains a mine.
//TODO: If a button's color changes to red, display a message that says: Game Over.
//TODO: If the Game Over message has been displayed, make the buttons stop changing color if clicked on.
