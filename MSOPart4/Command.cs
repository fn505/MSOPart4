    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.PortableExecutable;
    using System.Text;
    using System.Threading.Tasks;

    namespace MSOPart4
    {
        public abstract class Command
        {
            public abstract bool isValid();
            public abstract void execute(Character character);



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
                if(isValid())
                character.move(steps);

            }

        public string toString()
        {
            return $"Move {steps}"; 
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
        public string toString()
        {
            return $"Turn {turnDirection}";
        }

            
    }

            public class RepeatCommand : Command
            {
                int count;
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
                    foreach (Command command in commandList)
                    {
                        command.execute(character);
                    }


                }

            }

    

    }
