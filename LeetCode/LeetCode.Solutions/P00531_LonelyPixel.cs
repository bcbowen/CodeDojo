namespace LeetCode.Solutions.P00531_LonelyPixel;

public class Solution
{

    public int FindLonelyPixel(char[][] picture)
    {
        int[] rTotals = new int[picture.Length];
        int[] cTotals = new int[picture[0].Length];

        for (int i = 0; i < picture.Length; i++)
        {
            for (int j = 0; j < picture[i].Length; j++)
            {
                if (picture[i][j] == 'B')
                {
                    rTotals[i]++;
                    cTotals[j]++;
                }
            }
        }

        int lonelyPixels = 0;
        for (int i = 0; i < picture.Length; i++)
        {
            for (int j = 0; j < picture[i].Length; j++)
            {
                if (picture[i][j] == 'B')
                {
                    if (rTotals[i] == 1 && cTotals[j] == 1) lonelyPixels++;
                }
            }
        }

        return lonelyPixels;
    }

    public int FindLonelyPixelWrong(char[][] picture)
    {
        Dictionary<int, int> colCounts = new Dictionary<int, int>();
        Dictionary<int, int> rowCounts = new Dictionary<int, int>();

        for (int i = 0; i < picture.Length; i++)
        {
            for (int j = 0; j < picture[i].Length; j++)
            {
                if (picture[i][j] == 'B')
                {
                    if (!colCounts.ContainsKey(i))
                    {
                        colCounts.Add(i, 0);
                    }
                    colCounts[i]++;

                    if (!rowCounts.ContainsKey(j))
                    {
                        rowCounts.Add(j, 0);
                    }
                    rowCounts[j]++;
                }
            }
        }
        return Math.Min(colCounts.Values.Count(v => v == 1), rowCounts.Values.Count(v => v == 1));
    }

}
