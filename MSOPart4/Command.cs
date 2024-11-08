using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
        public bool turnDirectionLeft;
        private string turnDirectionString;

        public TurnCommand(string turnDirection)
        {
            turnDirectionString = turnDirection;

            if (turnDirection == "left")
            turnDirectionLeft = true;
            if (turnDirection == "right")
            turnDirectionLeft = false;
        }

        public override bool isValid()
        {
            if (turnDirectionString == "left" || turnDirectionString == "right")
                return true;
            else return false;
        }

        public bool GetTurnDirection()
        {
            return turnDirectionLeft;
        }

        public override void execute(Character character)
        {
            if (isValid())
                character.turn(turnDirectionLeft);
        }

        public override string toString()
        {
            if (turnDirectionLeft)
                return "Turn left";
            else return "Turn right";
            //return $"Turn {turnDirectionLeft} ";
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

    public class RepeatUntilCommand : Command
    {
        Character character;
        public bool conditionMet;
        public string conditionString;
        
        public List<Command> commandList = new List<Command>();
        public RepeatUntilCommand(string condition, List<Command> commandList)
        {
            conditionString = condition;
            this.commandList = commandList;


        }
           
    
        public override bool isValid()
        {
            if (conditionString == "WallAhead" || conditionString == "GridEdge")
                return true;
            return false;

        }
        public void SetCondition()
        {


            if (conditionString == "WallAhead")
            {
                conditionMet = character.wallAhead;
            }
            else if (conditionString == "GridEdge")
            {
                conditionMet = character.gridEdge;
            }



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

            for (int i = 0; i < count; i++)
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

    public enum ConditionType 
    {
        WallAhead,
        GridEdge
    }


}
