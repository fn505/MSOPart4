using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MSOPart4
{
    public class Grid
    {

        int width;
        int height;
        public Cell[,] cells;



        public Grid()
        {
            width = 15;
            height = 15;
            cells = new Cell[width, height];
            Initializegrid();
            occupyCell(cells[0, 0]);

      

        }

        public void Initializegrid()
        {
                for ( int i  = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    cells[i, j] = new Cell(i, j, false);
                }
            }

        }

  
        public bool outOfBounds(Cell c)
        {
            if (c.x < 0 || c.x >= width || c.y < 0|| c.y >= height)
                return true;
            return false;
        }

        public void occupyCell(Cell c)
        {
            if (outOfBounds(c))
            {
                throw new Exception();
            }
           else if (!c.isOccupied) 
            { 
             c.isOccupied = true;
            }
           else
            {
                throw new InvalidOperationException("Error : Cell is already occupied");
            }
        }

        public void clearCell(Cell c)
        {
            if (outOfBounds(c))
            {
                throw new Exception();
            }
            else if (c.isOccupied)
            {
              c.isOccupied = false;
            }
            else
            {
                throw new InvalidOperationException("Error : Cell is already empty");
            }
        }
    }

    public class Cell
    {
      public int x;
       public int y;
       public  bool isOccupied;
        public Cell(int x, int y,  bool isOccupied) 
        {
          this.x = x;
          this.y = y;
          this.isOccupied = isOccupied;
        }
    }

}
