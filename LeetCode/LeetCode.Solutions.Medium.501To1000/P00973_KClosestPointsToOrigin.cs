namespace LeetCode.Solutions.Medium.P00973_KClosestPointsToOrigin;

public class Solution
{
    public int[][] KClosest(int[][] points, int k)
    {
        int[] origin = new int[] { 0, 0 };
        PriorityQueue<int[], double> distanceQueue = new PriorityQueue<int[], double>();
        foreach (int[] point in points)
        {
            double distance = CalcDistance(origin, point);
            distanceQueue.Enqueue(point, distance);
        }
        int[][] closestPoints = new int[k][];
        for (int i = 0; i < k; i++)
        {
            closestPoints[i] = distanceQueue.Dequeue();
        }
        return closestPoints;
    }

    internal static double CalcDistance(int[] p1, int[] p2)
    {
        // The distance between two points on the X-Y plane is the Euclidean distance (i.e., √(x1 - x2)2 + (y1 - y2)2).
        double[] dp1 = new[] { (double)p1[0], (double)p1[1] };
        double[] dp2 = new[] { (double)p2[0], (double)p2[1] };
        double distance = Math.Sqrt(Math.Pow((dp1[0] - dp2[0]), 2) + Math.Pow((dp1[1] - dp2[1]), 2));
        return distance;
    }

}
