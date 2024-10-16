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


        }

        public class turnCommand : Command
        {
            string turnDirection;
            public override bool isValid()
            {
                if (turnDirection == "left" ||  turnDirection ==  "right")
                    return true;
                return false;
            }

            public override void execute(Character character)
            {


            }

        }

        public class repeatCommand : Command
        {
            int count;
            public override bool isValid()
            {
                if (count <0)
                    return false;
                return true;
            }

            public override void execute(Character character)
            {


            }

        }

    }

}
