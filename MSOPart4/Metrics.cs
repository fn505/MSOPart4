// See https://aka.ms/new-console-template for more information

using MSOPart4;
using System.Reflection.PortableExecutable;

public class Metrics
{
    public int commandCount, maxNestingLevel, repeats;


    // The way we have interpreted commandCount is as follows:
    // Every command that has been written outside of repeat-loops is counted once (including the repeat loops themselves)
    // And every command written inside repeat-loops is counted as many times and the loop is executed
    // These values added together create the commandCount
    private int UpdateCommandCount(List<Command> commandList)
    {
        int nestedCommandCount = commandList.Count;
        foreach (Command command in commandList) 
        {
            if(command.GetType() == typeof(RepeatCommand))
            {
                RepeatCommand repeatCommand = (RepeatCommand)command;
                 nestedCommandCount += UpdateCommandCount(repeatCommand.commandList) * repeatCommand.count;
            }
        
        }
        //foreach (RepeatCommand repeatcommand in commandList)
        //{

        //    nestedCommandCount += UpdateCommandCount(repeatcommand.commandList) * repeatcommand.count;
        //}
        return nestedCommandCount;
    }

    private int UpdateMaxNestingLevel(List<Command> commandList)
    {
        int nestingLevel = 0;
        foreach (Command command in commandList) 
        {
            if (command.GetType() == typeof(RepeatCommand))
            {

                RepeatCommand repeatCommand = (RepeatCommand)command;

                    if (UpdateMaxNestingLevel(repeatCommand.commandList) + 1 > nestingLevel)
                    {
                        nestingLevel = UpdateMaxNestingLevel(repeatCommand.commandList) + 1;
                    }

                    //UpdateMaxNestingLevel(repeatCommand.commandList);
                    //nestingLevel++;
                
                //if (UpdateMaxNestingLevel(repeatCommand.commandList) + 1 > nestingLevel)
                //{
                //    nestingLevel = UpdateMaxNestingLevel(repeatCommand.commandList) + 1;
                //}
            }
            //nestingLevel++;
        }

        //foreach (RepeatCommand repeatcommand in commandList)
        //{
        //    if (UpdateMaxNestingLevel(repeatcommand.commandList) + 1 > nestingLevel)
        //    {
        //        nestingLevel = UpdateMaxNestingLevel(repeatcommand.commandList) + 1;
        //    }
        //}
        return nestingLevel;
    }

    // The way we have interpreted repeats differs from how we've interpreted commandCount and is as follows:
    // Every repeat-command is counted once, including nested repeat-commands
    // The amount of times these commands are executed is not taken into consideration
    private int UpdateRepeats(List<Command> commandList)
    {
        int nestedRepeatsCount = 0;

        foreach(Command command in commandList) 
        {
            if (command.GetType() == typeof(RepeatCommand))
            {
                RepeatCommand repeatCommand = (RepeatCommand)command;
                nestedRepeatsCount += 1 + UpdateRepeats(repeatCommand.commandList);

            }



        }
        return nestedRepeatsCount;

        //foreach (RepeatCommand repeatcommand in commandList)
        //{
        //    nestedRepeatsCount += 1 + UpdateRepeats(repeatcommand.commandList);
        //}
        //return nestedRepeatsCount;
    }

    public void CaluculateMetrics(List<Command> commandList)
    {
        commandCount = UpdateCommandCount(commandList);
        maxNestingLevel = UpdateMaxNestingLevel(commandList);
        repeats = UpdateRepeats(commandList);

    }
}


