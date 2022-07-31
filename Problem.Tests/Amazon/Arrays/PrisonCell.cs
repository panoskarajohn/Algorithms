using FluentAssertions;

namespace Problem.Tests.Amazon.Arrays;


public class PrisonCellTests
{
    [Theory, MemberData(nameof(TestDataProperty))]
    public void Prison_cell_tests(int[] day1, int n, int[] dayN)
    {
        var result = new PrisonCells().PrisonAfterNDays(day1, n);
        result.Should().BeEquivalentTo(dayN);
    }
    
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    new int[] { 0,1,0,1,1,0,0,1 }, 
                    7, 
                    new int[] { 0,0,1,1,0,0,0,0 }
                },
            };
        }
    }
}

public class PrisonCells
{
    private int CellsToBitmap(int[] cells)
    {
        int stateBitMap = 0x0;
        for (int i = 0; i < cells.Length; i++)
        {
            stateBitMap <<= 1;
            stateBitMap = (stateBitMap | cells[i]);
        }

        return stateBitMap;
    }

    private bool AreAdjacentEqual(int[] cells, int index) => cells[index - 1] == cells[index + 1];

    private int[] NextDay(int[] cells)
    {
        int[] newCells = new int[cells.Length];
        newCells[0] = 0;

        for (int i = 1; i < cells.Length - 1; i++)
        {
            newCells[i] = (AreAdjacentEqual(cells, i) ? 1 : 0);
        }

        newCells[cells.Length - 1] = 0;
        return newCells;
    }

    public int[] PrisonAfterNDays(int[] cells, int n)
    {
        var seen = new Dictionary<int, int>();
        bool isFastForward = false;

        while (n > 0)
        {
            if (!isFastForward)
            {
                int state = CellsToBitmap(cells);
                if (seen.ContainsKey(state))
                {
                    n %= seen[state] - n;
                    isFastForward = true;
                }
                else
                {
                    seen.Add(state, n);
                }
            }

            if (n > 0)
            {
                n--;
                cells = NextDay(cells);
            }
        }

        return cells;
    }
    
}