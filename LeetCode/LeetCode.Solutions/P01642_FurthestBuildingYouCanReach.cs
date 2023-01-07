namespace LeetCode.Solutions.P01642_FurthestBuildingYouCanReach;

public class Solution
{
    public int FurthestBuilding(int[] heights, int bricks, int ladders)
    {
        PriorityQueue<int, int> laddersQueue = new PriorityQueue<int, int>();
        for (int i = 0; i < heights.Length - 1; i++)
        {
            int diff = heights[i + 1] - heights[i];
            if (diff > 0)
            {
                if (ladders > 0)
                {
                    laddersQueue.Enqueue(diff, diff);
                    ladders--;
                }
                else if (laddersQueue.Count > 0 && laddersQueue.Peek() < diff)
                {
                    int bricksCount = laddersQueue.Dequeue();
                    if (bricksCount <= bricks)
                    {
                        bricks -= bricksCount;
                        laddersQueue.Enqueue(diff, diff);
                    }
                    else
                    {
                        return i;
                    }
                }
                else
                {
                    if (bricks >= diff)
                    {
                        bricks -= diff;
                    }
                    else
                    {
                        return i;
                    }
                }
            }
        }

        return heights.Length - 1;
    }

    public int FurthestBuildingA(int[] heights, int bricks, int ladders)
    {
        int reached = 0;
        for (int i = 0; i < heights.Length - 1; i++)
        {
            int diff = heights[i + 1] - heights[i];
            if (diff > 0)
            {
                if (diff <= bricks)
                {
                    bricks -= diff;
                }
                else if (ladders > 0)
                {
                    ladders--;
                }
                else
                {
                    break;
                }
            }
            reached++;
        }
        return reached;
    }
}
