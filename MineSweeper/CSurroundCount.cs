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
        /*
            +----+----+----+                +----+----+----+ 
            |x-1 | x  |x+1 | y-1            | M16| M15|M14 |
            +----+----+----+                +----+----+----+
            |x-1 |mybn|x+1 | y      -->     | M1 |mybn| P1 |
            +----+----+----+                +----+----+----+
            |x-1 | x  |x+1 | y+1            |P14 | P15| P16|
            +----+----+----+                +----+----+----+ 
        */

        /// <summary>
        /// When myButton has no mines surrounding it.
        /// </summary>
        public void When0(Button mybtn, Button[,] btn_grid)
        {
            for (int x = 0; x < 15; x++)                                        //for the horizontal buttons.
            {
                for (int y = 0; y < 15; y++)                                    //for the vertical buttons.
                {
                    if (btn_grid[x, y] == mybtn)//gets position of mybtn.
                    {
 
                    }
                }
            }
        }

    }
}
