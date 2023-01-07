namespace LeetCode.Solutions.P01337_KWeakestRowsInMatrix;

public class Solution
{
    public int[] KWeakestRows(int[][] mat, int k)
    {
        PriorityQueue<int, int[]> queue = new PriorityQueue<int, int[]>(new ScoreComparer());
        for (int i = 0; i < mat.Length; i++)
        {
            int score = 0;
            for (int j = 0; j < mat[i].Length; j++)
            {
                if (mat[i][j] == 1)
                {
                    score++;
                }
                else
                {
                    queue.Enqueue(i, new[] { i, score });
                    break;
                }

                if (j == mat[i].Length - 1)
                {
                    queue.Enqueue(i, new[] { i, score });
                }
            }
        }

        int[] result = new int[k];
        for (int i = 0; i < k; i++)
        {
            result[i] = queue.Dequeue();
        }

        return result;
    }
}

internal class ScoreComparer : IComparer<int[]>
{
    public int Compare(int[] score1, int[] score2)
    {
        if (score1.Length != 2) throw new ArgumentException("Bad score dickface", "score1");
        if (score2.Length != 2) throw new ArgumentException("Bad score dickface", "score2");

        if (score1[1] != score2[1]) return score1[1].CompareTo(score2[1]);
        return score1[0].CompareTo(score2[0]);
    }
}