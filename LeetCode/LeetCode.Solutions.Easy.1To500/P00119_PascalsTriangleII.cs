namespace LeetCode.Solutions.Easy.P00119_PascalsTriangleII;

public class Solution
{
    public IList<int> Generate(int rowIndex)
    {
        List<int> last = null;
        List<int> row = null;
        for (int i = 0; i <= rowIndex; i++)
        {
            row = new List<int>(i + 1);

            row.Add(1);
            if (i > 1)
            {
                for (int j = 1; j < last.Count; j++)
                {
                    row.Add(last[j - 1] + last[j]);
                }
            }
            if (i > 0) row.Add(1);
            last = row;
        }

        return row;
    }
}