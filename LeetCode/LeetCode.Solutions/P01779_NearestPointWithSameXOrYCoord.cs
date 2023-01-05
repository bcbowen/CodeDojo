namespace LeetCode.Solutions.P01779_NearestPointWithSameXOrYCoord;

public class Solution
{
    public int NearestValidPoint(int x, int y, int[][] points)
    {
        int mindex = -1;
        double minDistance = double.MaxValue;
        for (int i = 0; i < points.Length; i++)
        {
            if (points[i][0] == x || points[i][1] == y)
            {
                double distance = CalcDistance(x, y, points[i][0], points[i][1]);
                if (distance < minDistance)
                {
                    mindex = i;
                    minDistance = distance;
                }
            }
        }
        return mindex;
    }

    private double CalcDistance(int x1, int y1, int x2, int y2)
    {
        return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
    }
}
