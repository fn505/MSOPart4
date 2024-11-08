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

        public Character()
        {
            grid = new Grid();
            position = (0, 0);
            currentDirection = Direction.East;
            characterImage = getCharacterImage();
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
            switch (currentDirection) 
            {
              case Direction.North:
                    if (!grid.outOfBounds(grid.cells[position.Item1, position.Item2 - steps]))
                    {
                        grid.clearCell(grid.cells[position.Item1, position.Item2]);
                        position.Item2 -= steps;
                        grid.occupyCell(grid.cells[position.Item1, position.Item2]);
                    }
                    break;
               case Direction.East:
                    if (!grid.outOfBounds(grid.cells[position.Item1 + steps, position.Item2]))
                    {
                        grid.clearCell(grid.cells[position.Item1, position.Item2]);
                        position.Item1 += steps;
                        grid.occupyCell(grid.cells[position.Item1, position.Item2]);
                    }
                    break;
                case Direction.South:
                    if (!grid.outOfBounds(grid.cells[position.Item1, position.Item2 + steps]))
                    {
                        grid.clearCell(grid.cells[position.Item1, position.Item2]);
                        position.Item2 += steps;
                        grid.occupyCell(grid.cells[position.Item1, position.Item2]);
                    }
                    break;
                case Direction.West:
                    if (!grid.outOfBounds(grid.cells[position.Item1 - steps, position.Item2]))
                    {
                        grid.clearCell(grid.cells[position.Item1, position.Item2]);
                        position.Item1 -= steps;
                        grid.occupyCell(grid.cells[position.Item1, position.Item2]);
                    }
                    break;  
            }
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
