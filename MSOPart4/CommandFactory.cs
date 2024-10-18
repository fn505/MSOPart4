using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSOPart4
{
    public class CommandFactory 
    {
        
        public CommandFactory() 
        { 

        }

        public Command createMoveCommand(int steps)
        {
            Command command = new MoveCommand( steps);
            
            return command;
        }

        public Command createTurnCommand(string turnDirection)
        {
            Command command = new TurnCommand(turnDirection);

            return command;
        }

        public Command createRepeatCommand(int count, List<Command> commandList)
        {
            Command command = new RepeatCommand(count, commandList);

            return command;
        }

    }
}
