using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSOPart4
{
    public class Character
    {
        public (int, int) position;
        public Direction currentDirection;
        public Character()
        {
            position = (0, 0);
            currentDirection = Direction.East;
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
