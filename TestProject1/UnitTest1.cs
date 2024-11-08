using System;
using Xunit;
using MSOPart4;
using System.ComponentModel.DataAnnotations;

namespace TestProject1
{

    public class UnitTest1
    {
        #region Grid tests
        [Fact]
        public void TestCellWithinBounds()
        {
            Grid grid = new Grid();
            Cell cell = new Cell(1, 1, false);
            bool result = grid.outOfBounds(cell);
            Assert.False(result);
        }

        [Fact]
        public void TestCellOutOfBoundsX()
        {
            Grid grid = new Grid();
            Cell cell = new Cell(15, 5, false);
            bool result = grid.outOfBounds(cell);
            Assert.True(result);
        }
        [Fact]
        public void TestCellOutOfBoundsY()
        {
            Grid grid = new Grid();
            Cell cell = new Cell(5, 15, false);
            bool result = grid.outOfBounds(cell);
            Assert.True(result);
        }

        [Fact]
        public void TestCellOutOfBoundsNegative()
        {
            Grid grid = new Grid();
            Cell cell = new Cell(-1, -2, false);
            bool result = grid.outOfBounds(cell);
            Assert.True(result);
        }

        [Fact]
        public void TestOccupyingCellSuccess()
        {
            Grid grid = new Grid();
            grid.occupyCell(grid.cells[2, 3]);
            Assert.True(grid.cells[2, 3].isOccupied);
        }

        [Fact]
        public void TestOccupyingOccupiedCell()
        {
            Grid grid = new Grid();
            Assert.Throws<InvalidOperationException>(() =>
            grid.occupyCell(grid.cells[0, 0])
            );
        }

        [Fact]
        public void TestOccupyingOutOfBoundsCell()
        {
            Grid grid = new Grid();
            Assert.Throws<IndexOutOfRangeException>(() =>
            grid.occupyCell(grid.cells[15, 5])
            );
        }

        [Fact]
        public void TestClearCellSuccess()
        {
            Grid grid = new Grid();
            grid.clearCell(grid.cells[0, 0]);
            Assert.False(grid.cells[0, 0].isOccupied);
        }

        [Fact]
        public void TestClearEmptyCell()
        {
            Grid grid = new Grid();
            Assert.Throws<InvalidOperationException>(() =>
            grid.clearCell(grid.cells[0, 1])
            );

        }

        [Fact]
        public void TestClearOutOfBoundsCell()
        {
            Grid grid = new Grid();
            Assert.Throws<IndexOutOfRangeException>(() =>
            grid.clearCell(grid.cells[-5, 5])
            );
        }
        #endregion
        #region Character tests
        [Fact]
        public void TestMoveNorth()
        {
            Character character = new Character();
            character.currentDirection = Direction.North;
            character.position = (2, 2);
            character.grid.occupyCell(character.grid.cells[2, 2]);
            character.move(2);
            var result = character.position;
            Assert.Equal((2, 0), result);
            Assert.False(character.grid.cells[2, 2].isOccupied);
            Assert.True(character.grid.cells[2, 0].isOccupied);

        }

        [Fact]
        public void TestMoveEast()
        {
            Character character = new Character();
            character.move(2);
            var result = character.position;
            Assert.Equal((2, 0), result);
            Assert.False(character.grid.cells[0, 0].isOccupied);

        }


        [Fact]
        public void TestMoveSouth()
        {
            Character character = new Character();
            character.currentDirection = Direction.South;
            character.move(2);
            var result = character.position;
            Assert.Equal((0, 2), result);
            Assert.False(character.grid.cells[0, 0].isOccupied);
            Assert.True(character.grid.cells[0, 2].isOccupied);
        }
        [Fact]
        public void TestMoveWest()
        {
            Character character = new Character();
            character.currentDirection = Direction.West;
            character.position = (2, 2);
            character.grid.occupyCell(character.grid.cells[2, 2]);
            character.move(2);
            var result = character.position;
            Assert.Equal((0, 2), result);
            Assert.False(character.grid.cells[2, 2].isOccupied);
            Assert.True(character.grid.cells[0, 2].isOccupied);
        }

        [Fact]
        public void TestMoveNorthOutOfBounds()
        {

            Character character = new Character();
            character.currentDirection = Direction.North;
            Assert.Throws<IndexOutOfRangeException>(() =>
            character.move(2)
           );
            var result = character.position;
            Assert.Equal((0, 0), result);

        }

        [Fact]
        public void TestMoveEastOutOfBounds()
        {

            Character character = new Character();
            character.currentDirection = Direction.East;
            Assert.Throws<IndexOutOfRangeException>(() =>
            character.move(15)
           );
            var result = character.position;
            Assert.Equal((0, 0), result);
        }
        [Fact]
        public void TestMoveSouthOutOfBounds()
        {

            Character character = new Character();
            character.currentDirection = Direction.South;
            Assert.Throws<IndexOutOfRangeException>(() =>
            character.move(15)
           );
            var result = character.position;
            Assert.Equal((0, 0), result);
        }

        [Fact]
        public void TestMoveWestOutOfBounds()
        {

            Character character = new Character();
            character.currentDirection = Direction.West;
            Assert.Throws<IndexOutOfRangeException>(() =>
            character.move(2)
           );
            var result = character.position;
            Assert.Equal((0, 0), result);
        }

        [Fact]

        public void TestTurnRightNorthtoEast()
        {
            Character character = new Character();
            character.currentDirection = Direction.North;
            character.turn(false);
            var result = character.currentDirection;
            Assert.Equal(Direction.East, result);
        }
        [Fact]
        public void TestTurnRightEastoSouth()
        {
            Character character = new Character();
            character.currentDirection = Direction.East;
            character.turn(false);
            var result = character.currentDirection;
            Assert.Equal(Direction.South, result);
        }
        [Fact]
        public void TestTurnRightSouthtoWest()
        {
            Character character = new Character();
            character.currentDirection = Direction.South;
            character.turn(false);
            var result = character.currentDirection;
            Assert.Equal(Direction.West, result);
        }

        [Fact]
        public void TestTurnRightWesttoNorth()
        {
            Character character = new Character();
            character.currentDirection = Direction.West;
            character.turn(false);
            var result = character.currentDirection;
            Assert.Equal(Direction.North, result);
        }
        [Fact]
        public void TestTurnLeftNorthToWest()
        {
            Character character = new Character();
            character.currentDirection = Direction.North;
            character.turn(true);
            var result = character.currentDirection;
            Assert.Equal(Direction.West, result);
        }

        [Fact]
        public void TestTurnLeftWestToSouth()
        {
            Character character = new Character();
            character.currentDirection = Direction.West;
            character.turn(true);
            var result = character.currentDirection;
            Assert.Equal(Direction.South, result);
        }

        [Fact]
        public void TestTurnLeftSouthToEast()
        {
            Character character = new Character();
            character.currentDirection = Direction.South;
            character.turn(true);
            var result = character.currentDirection;
            Assert.Equal(Direction.East, result);
        }

        [Fact]
        public void TestTurnLeftEastToNorth()
        {
            Character character = new Character();
            character.currentDirection = Direction.East;
            character.turn(true);
            var result = character.currentDirection;
            Assert.Equal(Direction.North, result);
        }

        [Fact]
        public void TestTurnMultipleRight()
        {
            Character character = new Character();
            character.currentDirection = Direction.North;
            character.turn(false);
            character.turn(false);
            var result = character.currentDirection;
            Assert.Equal(Direction.South, result);
        }
        [Fact]
        public void TestTurnMultipleLeft()
        {
            Character character = new Character();
            character.currentDirection = Direction.North;
            character.turn(true);
            character.turn(true);
            var result = character.currentDirection;
            Assert.Equal(Direction.South, result);
        }

        [Fact]
        public void TestTurnLeftAndRight()
        {
            Character character = new Character();
            character.currentDirection = Direction.North;
            character.turn(false);
            character.turn(true);
            character.turn(true);
            var result = character.currentDirection;
            Assert.Equal(Direction.West, result);
        }

        #endregion
        #region ProgramReader tests
        [Fact]
        public void TestReadFile()
        {
            ProgramReader programReader = new ProgramReader("Resources/TestProgram.txt");
            programReader.lines = new List<string>
            {
                "Move 3",
                "Turn right",
                "Move 2"
            };

            var result = programReader.lines;
            Assert.Equal("Move 3", result[0]);
            Assert.Throws<ArgumentOutOfRangeException>(() => { var accessTry = result[4]; });
        }

        [Fact]
        public void TestParseFile()
        {
            ProgramReader programReader = new ProgramReader("Resources/TestProgram.txt");
            programReader.lines = new List<string>
            {
                "Move 3",
                "Turn right",
                "Move 2"
            };

            programReader.ParseFile(programReader.lines, programReader.commandList);
            var result = programReader.commandList;

            var moveCommand1 = (MoveCommand)result[0];
            var turnCommand = (TurnCommand)result[1];
            var moveCommand2 = (MoveCommand)result[2];

            Assert.Equal(3, result.Count);

            Assert.IsType<MoveCommand>(result[0]);
            Assert.Equal(3, moveCommand1.Getsteps());
            Assert.IsType<TurnCommand>(result[1]);
            Assert.Equal(false, turnCommand.GetTurnDirection());
            Assert.IsType<MoveCommand>(result[2]);
            Assert.Equal(2, moveCommand2.Getsteps());


        }

        [Fact]
        public void TestExecuteCommandMoveCommand()
        {
            ProgramReader programReader = new ProgramReader("Resources/TestProgram.txt");
            programReader.lines = new List<string>
            {
                "Move 2",
                "Turn right",
                "Move 2"
            };
            Character character = new Character();
            programReader.ParseFile(programReader.lines, programReader.commandList);
            var exeCommand = programReader.commandList[0];
            exeCommand.execute(character);
            var result = character.position;
            Assert.Equal((2, 0), result);

        }

        [Fact]
        public void TestExecuteCommandTurnCommand()
        {
            ProgramReader programReader = new ProgramReader("Resources/TestProgram.txt");
            Character character = new Character();
            programReader.lines = new List<string>
            {
                "Move 3",
                "Turn right",
                "Move 2"
            };
            programReader.ParseFile(programReader.lines, programReader.commandList);
            var exeCommand = programReader.commandList[1];
            exeCommand.execute(character);
            var result = character.currentDirection;
            Assert.Equal(Direction.South, result);
        }

        [Fact]
        public void TestExecuteCommandList()
        {
            ProgramReader programReader = new ProgramReader("Resources/TestProgram.txt");
            Character character = new Character();
            programReader.lines = new List<string>
            {
                "Move 3",
                "Turn right",
                "Move 2"
            };
            programReader.ParseFile(programReader.lines, programReader.commandList);

            foreach (Command c in programReader.commandList) { c.execute(character); }
            var result1 = character.position;
            Assert.Equal((3, 2), result1);
            var result2 = character.currentDirection;
            Assert.Equal(Direction.South, result2);
        }

        [Fact]

        public void TestExecuteCommandListRepeatUntil()
        {
            ProgramReader programReader = new ProgramReader("Resources/TestProgram.txt");
            Character character = new Character();
            programReader.lines = new List<string>
            {
                "RepeatUntil GridEdge",
                "\tMove 1"
            };
            programReader.ParseFile(programReader.lines, programReader.commandList);

            foreach (Command c in programReader.commandList) { c.execute(character); }
            var result = character.position;
            Assert.Equal((3,0), result);
        }
        #endregion
        #region Metric tests
        [Fact]
        public void TestCommandCount()
        {
            Metrics testMetrics = new Metrics();
            List<Command> testList = new List<Command>
            {
                new MoveCommand(4),
                new MoveCommand(5),
                new RepeatCommand(2, new List<Command> { new RepeatCommand(2, new List<Command> { new TurnCommand("right"), new MoveCommand(8) }), new MoveCommand(8) }),
                new MoveCommand(4),
                new TurnCommand("left"),
                new RepeatCommand(5, new List<Command> { new MoveCommand(4), new MoveCommand(8) })
            };
            testMetrics.CaluculateMetrics(testList);
            var result = testMetrics.commandCount;
            Assert.Equal(28, result);
        }

        [Fact]
        public void TestMaxNestingLevel()
        {
            Metrics testMetrics = new Metrics();
            ProgramReader programReader = new ProgramReader("Resources/TestProgram.txt");
            List<Command> testList = new List<Command>
            {
                new MoveCommand(4),
                new MoveCommand(5),
                new RepeatCommand(2, new List<Command> { new RepeatCommand(2, new List<Command> { new TurnCommand("right"), new MoveCommand(8) }), new MoveCommand(8) }),
                new MoveCommand(4),
                new TurnCommand("left"),
                new RepeatCommand(5, new List<Command> { new MoveCommand(4), new MoveCommand(8) })
            };
            testMetrics.CaluculateMetrics(testList);
            var result = testMetrics.maxNestingLevel;
            Assert.Equal(2, result);
        }

        [Fact]
        public void TestRepeats()
        {
            Metrics testMetrics = new Metrics();
            List<Command> testList = new List<Command>
            {
                new MoveCommand(4),
                new MoveCommand(5),
                new RepeatCommand(2, new List<Command> { new RepeatCommand(2, new List<Command> { new TurnCommand("right"), new MoveCommand(8) }), new MoveCommand(8) }),
                new MoveCommand(4),
                new TurnCommand("left"),
                new RepeatCommand(5, new List<Command> { new MoveCommand(4), new MoveCommand(8) })
            };
            testMetrics.CaluculateMetrics(testList);
            var result = testMetrics.repeats;
            Assert.Equal(3, result);
        }
        #endregion

    }
}