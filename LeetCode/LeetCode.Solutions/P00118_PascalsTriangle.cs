namespace LeetCode.Solutions.P00118_PascalsTriangle;

public partial class Solution
{
    public IList<IList<int>> Generate(int numRows)
    {
        IList<IList<int>> triangle = new List<IList<int>>();
        for (int i = 0; i < numRows; i++)
        {
            List<int> row = new List<int>(i + 1);

            row.Add(1);
            if (i > 1)
            {
                for (int j = 1; j < triangle[i - 1].Count; j++)
                {
                    row.Add(triangle[i - 1][j - 1] + triangle[i - 1][j]);
                }
            }
            if (i > 0) row.Add(1);
            triangle.Add(row);
        }

        return triangle;
    }
}