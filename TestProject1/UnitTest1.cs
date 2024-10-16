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

    }




}