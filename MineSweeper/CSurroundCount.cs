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
        frmMain Main;
        public CSurroundCount(Form frmCalled)
        {
            Main = (frmMain)frmCalled;           
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
        CNumbers Numbers = new CNumbers();
        //Form1 FORM = new Form1();
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
                            
                            //MessageBox.Show("1");                            
                            //frmMain.Expansion(mybtn);//calls the method in Form1
                           //Expansion(mybtn);
                        }
                    }
                }
            }
            return Count;
        }

    }
}
