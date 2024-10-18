using System;
using Xunit;
using MSOPart4;


namespace TestProject1
{

    public class UnitTest1
    {
        //tests for grid.outOfBounds
        [Fact]
      public void TestCellWithinBounds()
        {
            Grid grid = new Grid();
            Cell cell = new Cell(4, 4, false);
            bool result = grid.outOfBounds(cell);
            Assert.False(result);
        }

        [Fact]
        public void TestCellOutOfBoundsX()
        {
            Grid grid = new Grid();
            Cell cell = new Cell(10, 5, false);
            bool result = grid.outOfBounds(cell);
            Assert.True(result);
        }
        [Fact]
        public void TestCellOutOfBoundsY()
        {
            Grid grid = new Grid();
            Cell cell = new Cell(5, 10, false);
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

        // tests for grid.occupyCell
        [Fact]
          public void TestOccupyingCellSuccess()
          {
            Grid grid = new Grid();
            grid.occupyCell(grid.cells[2,3]);
            Assert.True(grid.cells[2, 3].isOccupied);
           }

        [Fact]
        public void TestOccupyingOccupiedCell() 
        {
            Grid grid = new Grid();
            Assert.Throws<InvalidOperationException>(() =>
            grid.occupyCell(grid.cells[0,0])
            ) ;
        }

        [Fact]
        public void TestOccupyingOutOfBoundsCell()
        {
            Grid grid = new Grid();
            Assert.Throws<IndexOutOfRangeException>(() =>
            grid.occupyCell(grid.cells[5, 5])
            );
        }
        // test for grid.ClearCell
        [Fact]
        public void TestClearCellSuccess()
        {
            Grid grid = new Grid();
            grid.clearCell(grid.cells[0,0]);
            Assert.False(grid.cells[0,0].isOccupied);
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
            grid.clearCell(grid.cells[5, 5])
            );

        }
        // testing Character class
        //testing character.move

  

        [Fact]
        public void TestMoveNorth()
        {
            Character character = new Character();
            character.currentDirection = Direction.North;
            character.move(2);
            var result = character.position;
            Assert.Equal((0, 2), result); 
            Assert.False(character.grid.cells[0, 0].isOccupied); 
            Assert.True(character.grid.cells[0, 2].isOccupied);
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
            character.position = (2, 2);
            character.grid.occupyCell(character.grid.cells[2, 2]);
            character.move(2);
            var result = character.position;
            Assert.Equal((2,0), result);
            Assert.False(character.grid.cells[2,2].isOccupied);
            Assert.True(character.grid.cells[2,0].isOccupied);

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
            Assert.False(character.grid.cells[2,2].isOccupied);
            Assert.True(character.grid.cells[0, 2].isOccupied);
        }

        [Fact]
        public void TestMoveNorthOutOfBounds()
        {

            Character character = new Character();
            character.currentDirection = Direction.North;
            Assert.Throws<IndexOutOfRangeException>(() =>
            character.move(5)
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
            character.move(5)
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
                character.move(5)
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
            character.move(5)
           );
            var result = character.position;    
            Assert.Equal((0,0), result);
        }

        //testing character.turn

        [Fact]

        public void TestTurnRightNorthtoEast()
        {
            Character character = new Character();
            character.currentDirection = Direction.North;
            character.turn("right");
            var result = character.currentDirection;
            Assert.Equal(Direction.East,result);
        }
        [Fact]
        public void TestTurnRightEastoSouth()
        {
            Character character = new Character();
            character.currentDirection = Direction.East;
            character.turn("right");
            var result = character.currentDirection;
            Assert.Equal(Direction.South, result);
        }
        [Fact]
        public void TestTurnRightSouthtoWest()
        {
            Character character = new Character();
            character.currentDirection = Direction.South;
            character.turn("right");
            var result = character.currentDirection;
            Assert.Equal(Direction.West, result);
        }

        [Fact]
        public void TestTurnRightWesttoNorth()
        {
            Character character = new Character();
            character.currentDirection = Direction.West;
            character.turn("right");
            var result = character.currentDirection;
            Assert.Equal(Direction.North, result);
        }
        [Fact]
        public void TestTurnLeftNorthToWest()
        {
            Character character = new Character();
            character.currentDirection = Direction.North;
            character.turn("left");
            var result = character.currentDirection;
            Assert.Equal(Direction.West, result);
        }

        [Fact]
        public void TestTurnLeftWestToSouth()
        {
            Character character = new Character();
            character.currentDirection = Direction.West;
            character.turn("left");
            var result = character.currentDirection;
            Assert.Equal(Direction.South, result);
        }

        [Fact]
        public void TestTurnLeftSouthToEast()
        {
            Character character = new Character();
            character.currentDirection = Direction.South;
            character.turn("left");
            var result = character.currentDirection;
            Assert.Equal(Direction.East, result);
        }

        [Fact]
        public void TestTurnLeftEastToNorth()
        {
            Character character = new Character();
            character.currentDirection = Direction.East;
            character.turn("left");
            var result = character.currentDirection;
            Assert.Equal(Direction.North, result);
        }

        //multiple turns

        [Fact]
        public void TestTurnMultipleRight()
        {
            Character character = new Character();
            character.currentDirection = Direction.North;
            character.turn("right");
            character.turn("right");
            var result = character.currentDirection;
            Assert.Equal(Direction.South, result);
        }
        [Fact]
        public void TestTurnMultipleLeft()
        {
            Character character = new Character();
            character.currentDirection = Direction.North;
            character.turn("left");
            character.turn("left");
            var result = character.currentDirection;
            Assert.Equal(Direction.South, result);
        }

        [Fact]
        public void TestTurnLeftAndRight()
        {
            Character character = new Character();
            character.currentDirection = Direction.North;
            character.turn("right");
            character.turn("left");
            character.turn("left");
            var result = character.currentDirection;
            Assert.Equal(Direction.West, result);
        }
    }

    public class UnitTestMetrics
    {
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
    }
}