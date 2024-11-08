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

       public int width;
        public int height;
        public Cell[,] cells;



        public Grid()
        {
            width = 4;
            height = 4;
            cells = new Cell[width, height];
            Initializegrid();
            occupyCell(cells[0, 0]);

      

        }

        public void Initializegrid()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    cells[i, j] = new Cell(i, j, false);
                }
            }

        }

        //test
        //public void LoadGrid(string filePath)
        //{
        //    string[] lines = File.ReadAllLines(filePath);

        //    if (lines.Length != height || lines.Length != width)
        //    {
        //        throw new Exception("The grid file does not match the grid dimensions ");
        //    }

        //    for (int x = 0; x < width; x++)
        //    {
        //        for (int y = 0; y < height; y++)
        //        {
        //            cells[x, y].isOccupied = (lines[y][x] == '+');
        //        }
        //    }

        //}


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
        public bool isGoal;
        public Cell(int x, int y,  bool isOccupied) 
        {
            this.x = x;
            this.y = y;
            this.isOccupied = isOccupied;
        }
    }

}
