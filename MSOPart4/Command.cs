using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace MSOPart4
{
    public abstract class Command
    {
        public abstract bool isValid();
        public abstract void execute(Character character);
        public abstract string toString();


    }




    public class MoveCommand : Command
    {
        int steps;
        public MoveCommand(int steps)
        {
            this.steps = steps;
        }
        public int Getsteps()
        {
            return steps;
        }

        public override bool isValid()
        {
            if (steps < 0)
                return false;
            return true;

        }

        public override void execute(Character character)
        {
            if (isValid())
                character.move(steps);

        }

        public override string toString()
        {
            return $"Move {steps} ";
        }
    }

    public class TurnCommand : Command
    {
        public string turnDirection;

        public TurnCommand(string turnDirection)
        {
            this.turnDirection = turnDirection;
        }

        public override bool isValid()
        {
            if (turnDirection == "left" || turnDirection == "right")
                return true;
            return false;
        }

        public string GetTurnDirection()
        {
            return turnDirection;
        }

        public override void execute(Character character)
        {
            if (isValid())
                character.turn(turnDirection);
        }

        public override string toString()
        {
            return $"Turn {turnDirection} ";
        }
    }


    public class RepeatCommand : Command
    {
        public int count;
        public List<Command> commandList = new List<Command>();
        public RepeatCommand(int count, List<Command> commandList)
        {
            this.count = count;
            this.commandList = commandList;
        }


        public override bool isValid()
        {
            if (count < 0)
                return false;
            return true;
        }


        public override void execute(Character character)
        {
            for (int i = 0; i < count; i++) 
            {
                foreach (Command command in commandList)
                {
                    command.execute(character); 
                }
            }
        }

        public override string toString()
        {
            
           
            List<string> list = new List<string>();
  
            for(int i = 0; i<count; i++)
            {
                List<string> tempList = new List<string>();
                
                foreach (Command command in commandList)
                {
                    string temp = command.toString().Trim();
                    tempList.Add(temp);


                }
                list.Add(string.Join(", ", tempList));
            }


            return string.Join(", ", list);
        }
       
    }





}
