﻿using System;
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
            {
                int mineX = rand.Next(15);
                int mineY = rand.Next(15);

                if (grid[mineX, mineY] == 0)
                {
                    btn_grid[mineX, mineY].Text = " ";
                    btn_grid[mineX, mineY].Font = new Font("Microsoft Sans Serif", 10f, btn_grid[mineX, mineY].Font.Style, btn_grid[mineX, mineY].Font.Unit);
                    btn_grid[mineX, mineY].Location = new System.Drawing.Point(btn_grid[mineX, mineY].Location.X, btn_grid[mineX, mineY].Location.Y);
                    mineCount++;
                    mineXOutside = mineX;
                    mineYOutside = mineY;
                }
            }
            while (mineCount != 70);

            foreach (Button btn in btn_grid)
            {
                btn.Click += new EventHandler(MineClickedOrNot);                //click event handler for the grid of buttons.
            }
        }

        /// <summary>
        /// When the user clicks on a button in the button grid, this method checks whether it contains a
        /// mine or not, if it does it changes the colour of the button to red and reveils the location of 
        /// the other mines and if it doesn't, it changes the button's colour to green.
        /// </summary>
        private void MineClickedOrNot(object sender, EventArgs e)               //click event handler for the grid of buttons.
        {
            var myButton = (Button)sender;                                      //makes the buttonin the grid that the user clicked myButton.
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
            else
            {
                myButton.BackColor = Color.Green;                                 //if the button doesn't contain a mine it becomes green.
            }
        }
    }
}
//TODO: If a button's color changes to red, display a message that says: Game Over.
//TODO: If the Game Over message has been displayed, make the buttons stop changing color if clicked on.
//TODO: find out the game logic or algorithm for the real minesweeper game.
