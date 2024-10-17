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


    public class moveCommand : Command
    {
        int steps;


        public override bool isValid()
        {
            if (steps < 0)
                return false;
            return true;

        }

        public override void execute(Character character)
        {
            character.move(steps);

        }

        public class turnCommand : Command
        {
            public string turnDirection;
            public override bool isValid()
            {
                if (turnDirection == "left" || turnDirection == "right")
                    return true;
                return false;
            }

            public override void execute(Character character)
            {
                character.turn(turnDirection);

            }

        }

        public class repeatCommand : Command
        {
            int count;
            public List<Command> commandList;
            public override bool isValid()
            {
                if (count < 0)
                    return false;
                return true;
            }

            //waarschijnlijk veranderen
            public override void execute(Character character)
            {
                foreach (Command command in commandList)
                {
                    command.execute(character);
                }


            }

        }

    }

}
