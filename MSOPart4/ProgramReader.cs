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

       public  ProgramReader(string source)
        {
            this.source = source;
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
                        //next line start with tab -> 


                        int subIndex = lines.IndexOf(line) + 1;
                        while( subIndex < lines.Count && lines[subIndex].StartsWith("\t"))
                        {
                            var subCommandLine = lines[subIndex].Trim();
                            var subParts = subCommandLine.Split(" ");

                            Command subCommand = CreateSubCommand(subParts);

                            subCommands.Add(subCommand);
                            subIndex++;

                        }
                        var newRepeatCommand = commandFactory.createRepeatCommand(count, subCommands);
                        commandList.Add(newRepeatCommand);
                        break;

                }
            }


        }

        public Command CreateSubCommand(string[] parts)
        {
            if (parts[0] == "Move")
            {
                int steps = Int32.Parse(parts[1]);
                var newMoveCommand = commandFactory.createMoveCommand(steps);
                return newMoveCommand;
            }
            else if (parts[0] == "Turn")
            {
                string turnDirection = parts[1];
                var newTurnCommand = commandFactory.createTurnCommand(turnDirection);
                return newTurnCommand;
            }
            else
            {
                throw new Exception("Error : Unknown Command");
            }

        }

        public void Display(List<Command> commands) 
        { 

            foreach (var command in commands) { Console.WriteLine(command.ToString()); }
        
        }

    }
}
