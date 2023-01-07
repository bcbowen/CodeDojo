namespace LeetCode.Solutions.P01232_CheckForStraightLine;

public class Solution
{
    // y1=m*x1+b
    // y2=m*x2+b
    // y1-y2=m*(x1-x2)
    // m=(y1-y2)/(x1-x2)
    // b=y1-m*x1;
    public bool CheckStraightLine(int[][] coordinates)
    {
        if (coordinates.Length == 2) return true;

        int x1 = coordinates[0][0];
        int x2 = coordinates[1][0];

        if (x1 == x2)
        {
            // horizontal line
            foreach (int[] point in coordinates)
            {
                if (point[0] != x1) return false;
            }
            return true;
        }

        int y1 = coordinates[0][1];
        int y2 = coordinates[1][1];
        if (y1 == y2)
        {
            // vertical line		
            foreach (int[] point in coordinates)
            {
                if (point[1] != y1) return false;
            }
            return true;
        }

        // m=(y1-y2)/(x1-x2)
        // b=y1-m*x1;
        double m = ((double)y1 - y2) / (x1 - x2);
        double b = y1 - m * x1;
        for (int i = 2; i < coordinates.Length; i++)
        {
            int x = coordinates[i][0];
            int y = coordinates[i][1];
            if (b != y - m * x) return false;
        }
        return true;
    }
}
