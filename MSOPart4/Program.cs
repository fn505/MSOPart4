// See https://aka.ms/new-console-template for more information

using MSOPart4;
using System.Reflection.PortableExecutable;

public class Program 
{
    ProgramReader programReader;
    Character character;
    string name;
    List<Command> commands;
    ProgramDifficulty programLevel;
    public Program(ProgramReader programReader, string name)
    {
        this.programReader = programReader;
        character = new Character();
        this.name = name;

        programReader.ReadFile();
        programReader.ParseFile(programReader.lines, programReader.commandList);
        commands = programReader.commandList;


    }

    public enum ProgramDifficulty
    {
        basic,
        advanced,
        expert,

    }

    public void getExampleProgram(ProgramDifficulty difficulty)
    {
        List<Command> examples = new List<Command>();
        #region basic example programs
        List<Command> basic1 = new List<Command>
        {
                new MoveCommand(4),
                new TurnCommand("right"),
                new MoveCommand(5),
                new MoveCommand(1),
        };
        List<Command> basic2 = new List<Command>
        {
                new MoveCommand(2),
                new TurnCommand("right"),
                new TurnCommand("right"),
                new MoveCommand(1),
        };
        List<List<Command>> basicList = new List<List<Command>>();
        basicList.Add(basic1);
        basicList.Add(basic2);
        #endregion
        #region advanced example programs
        List<Command> advanced1 = new List<Command>
        {
              new RepeatCommand(2, new List<Command>{ new MoveCommand(4),  new TurnCommand("right") } ),
              new TurnCommand("left"),

        };
        List<Command> advanced2 = new List<Command>
        {
              new RepeatCommand(3, new List<Command>{ new MoveCommand(2),  new TurnCommand("right") } ),
              new TurnCommand("right"),
        };
        List<List<Command>> advancedList = new List<List<Command>>();
        advancedList.Add(advanced1);
        advancedList.Add(advanced2);
        #endregion
        #region expert example programs

        List<Command> expert1 = new List<Command>
        {
                new MoveCommand(5),
                new RepeatCommand(2, new List<Command> {
                        new RepeatCommand(2, new List<Command> { 
                            new TurnCommand("right"),
                            new MoveCommand(1) }), 
                            new MoveCommand(1) }),
                new TurnCommand("left"),

        };
        List<Command> expert2 = new List<Command>
        {
          new MoveCommand(7),
                new RepeatCommand(2, new List<Command> {
                        new RepeatCommand(3, new List<Command> {
                            new TurnCommand("right"),
                            new MoveCommand(1) }),
                new TurnCommand("right"),

        })};

        List<List<Command>> expertList = new List<List<Command>>();
        expertList .Add(expert1);
        expertList.Add(expert2);

        #endregion 
        switch (difficulty) 
        {
            case ProgramDifficulty.basic:
               
                Random r = new Random();
                examples = basicList.ElementAt(r.Next(basicList.Count-1));
                break;
            case ProgramDifficulty.advanced:
                r = new Random();   
                examples = advancedList.ElementAt(r.Next(advancedList.Count-1));
                break;
            case ProgramDifficulty.expert: 
                r = new Random();
                examples = expertList.ElementAt(r.Next(expertList.Count-1));
                break;
        }
        commands = examples;
        
    }

    public void Execute()
    {

        List<string> executedCommands = new List<string>();
        foreach (Command c in commands)
        {
            executedCommands.Add(c.toString().Trim());
            c.execute(character);
        }

        Display(executedCommands, character.position, character.currentDirection);
  
    }

    public void Display(List<string> strings, (int,int) state, Direction direction)
    {
        string commandsString = string.Join(", ", strings);
        string endString = commandsString + $". End State {state} facing {direction} ";
        Console.WriteLine(endString);
    }
    public static void Main()
    {
        string name = "Program1";
        ProgramReader pr = new ProgramReader("Resources/TestProgram.txt");
        Program p = new Program(pr, name);
        p.Execute();

    }

}


