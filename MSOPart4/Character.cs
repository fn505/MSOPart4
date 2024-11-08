using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSOPart4
{

    public class Character
    {
        public (int, int) position;
        public Direction currentDirection;
        public Grid grid;
        public Image characterImage;
        public bool wallAhead;
        public bool gridEdge;

        public Character()
        {
            grid = new Grid();
            position = (0, 0);
            currentDirection = Direction.East;
            characterImage = getCharacterImage();
            wallAhead = false;  
            gridEdge = false;   
        }
        public bool WallAheadCheck(int stepsSize)
        {
            int x = position.Item1;
            int y = position.Item2;

            int updatedX = x;
            int updatedY = y;


            switch (currentDirection)
            {
                case Direction.North:

                    return wallAhead = grid.cells[updatedX, (updatedY -= stepsSize) - 1].isOccupied;
                case Direction.East:
                    return wallAhead = grid.cells[(updatedX += stepsSize) + 1, updatedY].isOccupied;
                case Direction.South:
                    return wallAhead = grid.cells[updatedX, (updatedY += stepsSize) + 1].isOccupied;
                case Direction.West:
                    return wallAhead = grid.cells[(updatedX -= stepsSize) - 1, updatedY].isOccupied;
            }

            return false;
        }

    
        public bool GridEdgeCheck(int stepsSize)
        {
            int x = position.Item1;
            int y = position.Item2;
     
            int updatedX = x;
            int updatedY = y;
            switch (currentDirection)
            {
                case Direction.North:
                    return gridEdge = (updatedY -= stepsSize) == 0;
                case Direction.East:
                    return gridEdge =(updatedX += stepsSize) == grid.width;
                case Direction.South:
                    return gridEdge = (updatedY += stepsSize) == grid.height;
                case Direction.West:
                    return gridEdge =(updatedX -= stepsSize) == 0;

            }
            return false;
        }
        public Image getCharacterImage()
        {
           
            switch(currentDirection) 
            {
                case Direction.North:
                    return Image.FromFile("Resources/images/characterNorth.png");
                case Direction.East:
                    return Image.FromFile("Resources/images/characterEast.png");
                case Direction.South:
                    return Image.FromFile("Resources/images/characterSouth.png");
                case Direction.West:
                    return Image.FromFile("Resources/images/characterWest.png");
                default:
                    throw new NotImplementedException();

            }
        }


        public void move(int steps)
        {
            int x = position.Item1;
            int y = position.Item2;

            int updatedX = x;
            int updatedY = y;

            switch (currentDirection)
            {
                case Direction.North:
                    WallAheadCheck(steps);
                    GridEdgeCheck(steps);
                    updatedY -= steps;
                    break;
                case Direction.East:
                    WallAheadCheck(steps);
                    GridEdgeCheck(steps);
                    updatedX += steps;
                    break;
                case Direction.South:
                    WallAheadCheck(steps);
                    GridEdgeCheck(steps);
                    updatedY += steps;
                    break;
                case Direction.West:
                    WallAheadCheck(steps);
                    GridEdgeCheck(steps);
                    updatedX -= steps;
                    break;
            }

   
            if (grid.outOfBounds(grid.cells[updatedX, updatedY]))
            {
                throw new Exception("Move out of bounds");
            }

            if (grid.cells[updatedX, updatedY].isOccupied)
            {
                throw new Exception("Cell is blocked");
            }

            if (grid.cells[x, y].isOccupied)
            {
                grid.clearCell(grid.cells[x, y]);
            }

            position = (updatedX, updatedY);
            grid.occupyCell(grid.cells[updatedX, updatedY]);
        }
        public void turn(bool turnDirectionLeft)
        {
            switch (turnDirectionLeft)
            {
                case false:
                    currentDirection = (Direction)(((int)currentDirection + 1) % 4);
                    break;
                case true:
                    currentDirection = (Direction)(((int)currentDirection + 3) % 4);
                    break;
            }

        }
    }


    public enum Direction 
    {
        North,
        East,
        South,
        West,  
    
    }


}
