using MSOPart4;
using System.Diagnostics;
using System.Reflection.PortableExecutable;

public class Display 
{
    Program program;
    Metrics metrics;

    public Display(Program program)
    {
        this.program = program;
    
    }

    public string DisplayMetrics()
    {
        program.getMetrics();
        return ("command count: " + program.programMetrics.commandCount + 
                   "\r\nmaximum nesting level: " + program.programMetrics.maxNestingLevel 
                   + "\r\nrepeat commands: " + program.programMetrics.repeats);

    }

 
    public void DisplayOutput(List<string> strings, (int, int) state, Direction direction)
    {
        string commandsString = string.Join(", ", strings);
        string endString = commandsString + $". End State {state} facing {direction} ";
        Debug.WriteLine(endString);
    }

    public string DisplayOutputForm(List<string> strings, (int, int) state, Direction direction)
    {
        string commandsString = string.Join(", ", strings);
        string endString = commandsString + $". End State {state} facing {direction} ";
         return endString;
    }

}


