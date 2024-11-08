// See https://aka.ms/new-console-template for more information

using MSOPart4;
using System.Reflection.PortableExecutable;

public class Program
{
    public ProgramReader programReader;
    public Character character;
    string name;
    public List<Command> commands;
    ProgramDifficulty programLevel;
    public Metrics programMetrics;
    public Display display;
    public string output;
    public Exercise currentExercise;


    public Program(ProgramReader programReader, string name)
    {
        this.programReader = programReader;
        character = new Character();
        currentExercise = null;
        this.name = name;
        programReader.ReadFile();
        programReader.ParseFile(programReader.lines, programReader.commandList);
        commands = programReader.commandList;
        programMetrics = new Metrics();
        display = new Display(this);

    }

    public void Reset()
    {
        character.grid.clearCell(character.grid.cells[character.position.Item1, character.position.Item2]);
        character.position = (0, 0);
        character.currentDirection = Direction.East;
        commands.Clear();
        currentExercise = null;
    }
    public void SetCommands(List<Command> newCommands)
    {
        commands = newCommands;
    }

    public string getExampleProgram(ProgramDifficulty difficulty)
    {
        List<string> basicFiles = new List<string>
        {
            "Resources/ExamplePrograms/Basic1.txt"
            ,"Resources/ExamplePrograms/Basic2.txt"
        };

        List<string> advancedFiles = new List<string>
        {
            "Resources/ExamplePrograms/Advanced1.txt"
            ,"Resources/ExamplePrograms/Advanced2.txt"
        };

        List<string> expertFiles = new List<string>
        {
            "Resources/ExamplePrograms/Expert1.txt"
            ,"Resources/ExamplePrograms/Expert2.txt"
        };
        String selectedFile = string.Empty;
        Random r = new Random();
        switch (difficulty)
        {
            case ProgramDifficulty.basic:
                selectedFile = basicFiles.ElementAt(r.Next(basicFiles.Count));
                break;
            case ProgramDifficulty.advanced:
                selectedFile = advancedFiles.ElementAt(r.Next(advancedFiles.Count));
                break;
            case ProgramDifficulty.expert:
                selectedFile = expertFiles.ElementAt(r.Next(expertFiles.Count));
                break;

        }
        return GetLinesFromTextFile(selectedFile);

    }

    public string GetLinesFromTextFile(string selectedFile)
    {
        var lines = File.ReadAllLines(selectedFile);
        List<String> linesList = lines.ToList();
        ProgramReader reader = new ProgramReader(null);
        commands.Clear();
        reader.ParseFile(linesList, commands);
        return string.Join("\r\n", linesList);

    }
    public void gettExampleProgram(ProgramDifficulty difficulty)
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
        expertList.Add(expert1);
        expertList.Add(expert2);

        #endregion 
        switch (difficulty)
        {
            case ProgramDifficulty.basic:

                Random r = new Random();
                examples = basicList.ElementAt(r.Next(basicList.Count - 1));
                break;
            case ProgramDifficulty.advanced:
                r = new Random();
                examples = advancedList.ElementAt(r.Next(advancedList.Count - 1));
                break;
            case ProgramDifficulty.expert:
                r = new Random();
                examples = expertList.ElementAt(r.Next(expertList.Count - 1));
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

        output = display.DisplayOutput(executedCommands, character.position, character.currentDirection);

    }
  
    public void getMetrics()
    {
        programMetrics.CaluculateMetrics(commands);

    }


    [STAThread]
    public static void Main()
    {
        string name = "Program1";
        ProgramReader pr = new ProgramReader(null);
        Program p = new Program(pr, name);
        Application.Run(new Form1(p));





    }

}
public enum ProgramDifficulty
{
    basic,
    advanced,
    expert,

}


