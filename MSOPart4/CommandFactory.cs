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

        /// <summary>
        /// Creating the commands based on the parameters that it is given and throws exceptions
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public Command createCommand(CommandType commandType, params object[] parameters)
        {
            switch (commandType)

            {
                case CommandType.Move:
                    if (parameters.Length > 0 && parameters[0] is int steps)
                    {
                        return new MoveCommand(steps); ;
                    }
                    throw new ArgumentException("Invalid parameters for MoveCommand");
                case CommandType.Turn:
                    if(parameters.Length > 0  && parameters[0] is string turnDirection)
                    {
                        return new TurnCommand(turnDirection);

                    }
                    throw new ArgumentException("Invalid parameters for TurnCommand");
                case CommandType.Repeat:
                    if(parameters.Length > 1 && parameters[0] is int count && parameters[1] is List<Command> commandList)
                    {
                        return new RepeatCommand(count, commandList);

                    }
                    throw new ArgumentException("Invalid parameters for RepeatCommand");
                case CommandType.RepeatUntil:
                    if(parameters.Length > 1 && parameters[0] is string conditionString && parameters[1] is List<Command> comList)
                    {
                        return new RepeatUntilCommand(conditionString, comList);
                    }
                    throw new ArgumentException("Invalid parameters for RepeatUntilCommand");

                default : throw new ArgumentException("Unknown Command");

            }
        }
      }

    public enum CommandType
    {
        Move,
        Turn,
        Repeat,
        RepeatUntil
    }
}
