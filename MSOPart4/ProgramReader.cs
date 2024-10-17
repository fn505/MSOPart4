using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MSOPart4
{
    public class ProgramReader
    {
       public string source;
       public  List<string> lines;
        public List<Command> commandList;
        public CommandFactory commandFactory;

       public  ProgramReader()
        {
            this.source = "C:\\Users\\Nadir\\OneDrive\\Code\\MSOPart4\\MSOPart4\\TestProgram.txt";
            lines = new List<string>(); 
            commandList = new List<Command>();
            commandFactory = new CommandFactory();
        }


        public void ReadFile()
        {
            try
            {

                using (StreamReader sr = new StreamReader(source))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line); // Store the line in the list
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected error: {e.Message}");
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

        }

        public void ParseFile(List<string> lines)
        {
            foreach (string line in lines)
            {
                var parts = line.Split(' ');
                var firstWord = parts[0];

                switch (firstWord)
                {
                    case "Move":
                        int steps = Int32.Parse(parts[1]);
                        var newMoveCommand = commandFactory.createMoveCommand(steps);
                        commandList.Add(newMoveCommand);
                        break;
                    case "Turn":
                        string turnDirection = parts[1];
                        var newTurnCommand = commandFactory.createTurnCommand(turnDirection);
                        commandList.Add(newTurnCommand);
                        break;
                    case "Repeat":
                        int count = Int32.Parse(parts[1]);
                        List<Command> subCommands = new List<Command>();
                        var newRepeatCommand = commandFactory.createRepeatCommand(count, subCommands);
                        //next line start with tab -> 




                        break;

                }
            }


        }

        //public void ParseSubCommands(List<>)
        //{
           
        //}
       


        public void DisplayCommand()
        {

            foreach(Command c in commandList)
            {
                Console.WriteLine(c.ToString());
            }
        }
    }
}
