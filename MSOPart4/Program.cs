// See https://aka.ms/new-console-template for more information

using MSOPart4;
using System.Reflection.PortableExecutable;

public class Program 
{
    ProgramReader programReader;
    Character character;
    string name;
    List<Command> commands;
    public Program(ProgramReader programReader, string name)
    {
        this.programReader = programReader;
        character = new Character();
        this.name = name;

        programReader.ReadFile();
        programReader.ParseFile(programReader.lines);
        commands = programReader.commandList;


    }

    public void execute()
    {
        Console.WriteLine("start : " + character.position);
        Console.WriteLine("start: " + character.currentDirection);
        foreach (Command c in commands)
        {
            c.execute(character);
            Console.WriteLine(character.position);
            Console.WriteLine(character.currentDirection);
        }
        Console.WriteLine("end:" + character.position);
        Console.WriteLine("end:" + character.currentDirection);

    }
    public static void Main()
    {
        string name = "Program1";
        ProgramReader pr = new ProgramReader("Resources/TestProgram.txt");
        Program p = new Program(pr, name);
        p.execute();

    }

}


