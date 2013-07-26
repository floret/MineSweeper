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
        class exMineFound : System.Exception { }//Stops the buttons responding after a mine has been clicked.        
        CNumbers Numbers = new CNumbers();
        CSurroundCount SurroundCount = new CSurroundCount();
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
            Random rand = new Random();                                          //creates a random (variable?) for the placement of the mines.
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
            while (mineCount != 15);//70 makes it insanely difficult. //!creates less than the specified amount of mines.

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
            Button myButton = (Button)sender;                                      //makes the button in the grid that the user clicked myButton.

            //Count Mines:
            mineCountInner = Numbers.MineCount(myButton, btn_grid);//counts the number of mines that surround myButton.
            //Numbers.DisplayCount(mineCountInner,myButton);
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
                        Numbers.DisplayCount(mineCountInner, myButton);//calls a class method that counts the number of mines that surround myButton.  
                        if (mineCountInner == 0)
                        {
                            SurroundCount.ButtonSurround(myButton, btn_grid);
                        }
                        mineCountInner = 0;//makes CNumbers reusable.
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
        }
    }
}