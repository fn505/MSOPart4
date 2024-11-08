using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.AccessControl;
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
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public void ParseFile(List<string> lines, List<Command> commands)
        {
            for (int lineIndex = 0; lineIndex < lines.Count; lineIndex++)
            {
                var line = lines[lineIndex];
                var parts = line.Split(' ');
                var firstWord = parts[0];

                switch (firstWord)
                {
                    case "Move":
                        int steps = Int32.Parse(parts[1]);
                        var newMoveCommand = commandFactory.createCommand(CommandType.Move,steps);
                        commands.Add(newMoveCommand);
                        break;

                    case "Turn":
                        string turnDirection = parts[1];
                        var newTurnCommand = commandFactory.createCommand(CommandType.Turn,turnDirection);
                        commands.Add(newTurnCommand);
                        break;

                    case "Repeat":
                        int count = Int32.Parse(parts[1]);
                        List<Command> subCommands = new List<Command>();
                        List<string> subLines = CollectSubLines(lines, lineIndex + 1);
                        ParseFile(subLines, subCommands);
                        var repeatCommand = commandFactory.createCommand(CommandType.Repeat,count, subCommands);
                        commands.Add(repeatCommand);
                        lineIndex += subLines.Count;
                        break;
                }
            }
        }

        private List<string> CollectSubLines(List<string> lines, int startLine)
        {
            List<string> subLines = new List<string>();
            int i = startLine;

        
            int initialIndentation = getIndentationLevel(lines[startLine]);

            for(i = startLine; i < lines.Count; i++)
            { 
       
                var currentLine = lines[i];
                int currentIndentation = getIndentationLevel(currentLine);
                if (currentIndentation < initialIndentation)
                {
                    break;
                }

                subLines.Add(currentLine.TrimStart('\t'));
      
            }

            return subLines;
        }

        private int getIndentationLevel (string line) 
        {
            return line.TakeWhile(c => c == '\t').Count();
        
        }
    }
}
