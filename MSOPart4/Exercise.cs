using MSOPart4;
using System.Reflection.PortableExecutable;

public abstract class Exercise
{
    public Grid grid;
    public abstract void LoadGrid(string filePath);
  //  public bool
}

public class PathfindingExercise : Exercise
{
    public (int x, int y) goalPosition;
    public PathfindingExercise(Grid grid)
    {
        this.grid = grid;
    }
    public override void LoadGrid(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);

        if (lines.Length != grid.height || lines.Length != grid.width)
        {
            throw new Exception("The grid file does not match the grid dimensions ");
        }

        for (int x = 0; x < grid.width; x++)
        {
            for (int y = 0; y < grid.height; y++)
            {
                if (lines[y][x] == 'x')
                {
                    goalPosition = (x, y);
                }
                grid.cells[x, y].isOccupied = (lines[y][x] == '+');
            }
        }
    }

   

}




