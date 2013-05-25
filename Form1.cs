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
        /// creates a grid of buttons.
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
        int width = 0, height = 0, startX = 10, startY = 10;
        int mineXOutside = 0;
        int mineYOutside = 0;
        int XOutside = 0;
        int YOutside = 0;
        /// <summary>
        /// This button starts the game, by having a grid of buttons made and then randomly adding 70 mines to the grid.
        /// </summary>
        private void btnStart_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();//enables the game to restart if the start button is clicked.            
            grid = new int[/*width, height*/15, 15];
            btn_grid = new Button[/*width, height*/15, 15];                      //lol I have no idea what I'm doing.
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
            //TODO: Randomly assign mines to the buttons in the grid, there may not be more than 70 mines.
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
                    btn_grid[mineX, mineY].Location = new System.Drawing.Point(btn_grid[mineX, mineY].Location.X /*- 5*/, btn_grid[mineX, mineY].Location.Y);//commenting out the -5 stops the buttons from resizing
                    grid[mineX, mineY] = -1; //Add a mine
                    mineCount++;
                    mineXOutside = mineX;
                    mineYOutside = mineY;
                }
            }
            while (mineCount <= 70);
            btn_grid[XOutside, YOutside].Click += new EventHandler(MineClickedOrNot);//click event handler for the grid of buttons.
        }
        //private void BooTon_Click(object sender, EventArgs e)
        private void MineClickedOrNot(object sender, EventArgs e)//click event handler for the grid of buttons.
        {
            //Still trying to get the buttons to respond, I think the btn_grid[XOutside, YOutside].Click part isn't working.
            //btn_grid[XOutside, YOutside].Click += sender as Button;
            //btn_grid[XOutside, YOutside].Click +=
            //Button btn_grid[XOutside, YOutside] = sender as Button;
            btn_grid[XOutside, YOutside].Text = "O";//Maybe I need to redraw the grid to display changes?
            MessageBox.Show("works...");//not works...
        }
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    Button ClickedButton = (Button)e.OriginalSource;

        //    ClickedButton.Content = "Click";
        //}
        
    }
}
//TODO: make a method that when a button in the grid is clicked on checks whether or not it contains a mine or not.

//TODO: Make the color of a button green if it is clicked on and doesn't contain a mine.
//TODO: Make the color of a button red if it is clicked on and contains a mine.
//TODO: If a button's color changes to red, display a message that says: Game Over.
//TODO: If the Game Over message has been displayed, make the buttons stop changing color if clicked on.
//TODO:  
//Usefull??? b[i].Click += button_Click;.
//Usefull???
//private void ButtonClick(object sender, EventArgs e)
//{
//    //To Do - Click Event
//    Button btn = sender as Button;
//    MessageBox.Show(btn.Text + ", " + "Button Clicked");
//}

//BooTon[i, j].Click += new EventHandler(BooTon_Click);

//private void BooTon_Click(object sender, EventArgs e)
//        {
//            textBox1.Text = sender.ToString().Substring(35,1);
//            //textBox1.Text = sender.ToString();
//            textBox2.Text = sender.ToString().Substring(37,1);
//        }

//btn_grid[XOutside, YOutside].Click +=new EventHandler(MineClickedOrNot);