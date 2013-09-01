using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;//needed for button.

namespace MineSweeper
{
    class CSurroundCount
    {
        //public CSurroundCount()
        //{

        //}
        //Form Main;
        //public CSurroundCount(Form frmCalled)
        //{
        //    Main = (frmMain)frmCalled;
        //}
        /*
            +----+----+----+                +----+----+----+ 
            |x-1 | x  |x+1 | y-1            | M16| M15|M14 |
            +----+----+----+                +----+----+----+
            |x-1 |mybn|x+1 | y      -->     | M1 |mybn| P1 |
            +----+----+----+                +----+----+----+
            |x-1 | x  |x+1 | y+1            |P14 | P15| P16|
            +----+----+----+                +----+----+----+ 
        */
        CNumbers Numbers = new CNumbers();
        
        /// <summary>
        /// When myButton has no mines surrounding it.
        /// </summary>
        public int When0(Button mybtn, Button[,] btn_grid)
        {
            //Button[,] Grid;
            int Count = 0;
            for (int x = 0; x < 15; x++)//for the horizontal buttons.
            {
                for (int y = 0; y < 15; y++)//for the vertical buttons.
                {
                    //Grid = new Button[15, 15];//initialises Grid.
                    if (btn_grid[x, y] == mybtn)//gets position of mybtn.
                    {
                        Count = Numbers.MineCount(mybtn, btn_grid);//gets count of mines around mybutton  
                        if (Count == 0)//call expansion from here.
                        {
                            Expansion(mybtn, btn_grid);//hele fokken form is null.
                        }
                    }
                }
            }
            return Count;
        }


        /// <summary>
        /// expands stuff.
        /// </summary>
        public void Expansion(Button myButton, Button[,] btn_grid)//think of better name
        {
            for (int x = 0; x < 15; x++)//for the horizontal buttons.
            {
                for (int y = 0; y < 15; y++)//for the vertical buttons.
                {
                    if (btn_grid[x, y] == myButton)//gets position of mybtn.
                    {
                        /*
                          +----+----+----+
                          |x-1 | x  |x+1 | 
                          +----+----+----+ 
                          |x-1 |mybn|x+1 |
                          +----+----+----+  
                          |x-1 | x  |x+1 | 
                          +----+----+----+ 
                        */
                        try
                        {
                        Button btn_m1_m1 = btn_grid[x - 1, y - 1];
                        int i_m1_m1 = When0(btn_m1_m1, btn_grid);
                        Numbers.DisplayCount(Numbers.MineCount(btn_m1_m1, btn_grid), btn_m1_m1);
                        }
                        catch (Exception) { }
                        try
                        {
                            Button btn_0_m1 = btn_grid[x, y - 1];
                            int i_0_m1 = When0(btn_0_m1, btn_grid);
                            Numbers.DisplayCount(Numbers.MineCount(btn_0_m1, btn_grid), btn_0_m1);
                        }
                        catch (Exception) { }
                        try
                        {
                            Button btn_1_m1 = btn_grid[x + 1, y - 1];
                            int i_1_m1 = When0(btn_1_m1, btn_grid);
                            Numbers.DisplayCount(Numbers.MineCount(btn_1_m1, btn_grid), btn_1_m1);
                        }
                        catch (Exception) { }
                        try
                        {
                            Button btn_m1_0 = btn_grid[x - 1, y];
                            int i_m1_0 = When0(btn_m1_0, btn_grid);
                            Numbers.DisplayCount(Numbers.MineCount(btn_m1_0, btn_grid), btn_m1_0);
                        }
                        catch (Exception) { }
                        try
                        {
                            Button btn_1_0 = btn_grid[x + 1, y];
                            int i_1_0 = When0(btn_1_0, btn_grid);
                            Numbers.DisplayCount(Numbers.MineCount(btn_1_0, btn_grid), btn_1_0);
                        }
                        catch (Exception) { }
                        try
                        {
                            Button btn_m1_1 = btn_grid[x - 1, y + 1];
                            int i_m1_1 = When0(btn_m1_1, btn_grid);
                            Numbers.DisplayCount(Numbers.MineCount(btn_m1_1, btn_grid), btn_m1_1);
                        }
                        catch (Exception) { }
                        try
                        {
                            Button btn_0_1 = btn_grid[x, y + 1];
                            int i_0_1 = When0(btn_0_1, btn_grid);
                            Numbers.DisplayCount(Numbers.MineCount(btn_0_1, btn_grid), btn_0_1);
                        }
                        catch (Exception) { }
                        try
                        {
                            Button btn_1_1 = btn_grid[x + 1, y + 1];
                            int i_1_1 = When0(btn_1_1, btn_grid);
                            Numbers.DisplayCount(Numbers.MineCount(btn_1_1, btn_grid), btn_1_1);
                        }
                        catch (Exception) { }
                    }
                }
            }
        }

    }
}
