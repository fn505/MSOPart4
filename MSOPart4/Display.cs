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

    public void DisplayMetrics()
    {
        program.getMetrics();
        Debug.WriteLine("command count: " + program.programMetrics.commandCount);

    }
    public void DisplayOutput(List<string> strings, (int, int) state, Direction direction)
    {
        string commandsString = string.Join(", ", strings);
        string endString = commandsString + $". End State {state} facing {direction} ";
        Debug.WriteLine(endString);
    }

}


