namespace LeetCode.Solutions.Medium.P00835_ImageOverlap;

public class Solution
{
    private int _size;
    private int _margin;
    private int _blowupSize;

    public int LargestOverlap(int[][] img1, int[][] img2)
    {
        _size = img1.Length;
        _blowupSize = _size * 3 - 2;
        _margin = (_blowupSize - _size) / 2;
        int maxScore = 0;

        int[][] superSize = BlowUpImage(img1);
        for (int i = 0; i <= _blowupSize - _size; i++)
        {
            for (int j = 0; j <= _blowupSize - _size; j++)
            {
                int score = GetScore(i, j, superSize, img2);
                maxScore = Math.Max(score, maxScore);
            }
        }

        return maxScore;
    }

    private int[][] BlowUpImage(int[][] image)
    {
        int[][] superSize = new int[_blowupSize][];
        for (int i = 0; i < _blowupSize; i++)
        {
            superSize[i] = new int[_blowupSize];
            Array.Fill(superSize[i], 0);
        }

        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                superSize[i + _margin][j + _margin] = image[i][j];
            }
        }

        return superSize;
    }

    private int GetScore(int windowI, int windowJ, int[][] superSize, int[][] image2)
    {
        int score = 0;
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                if (1 == superSize[windowI + i][windowJ + j] && 1 == image2[i][j])
                {
                    score++;
                }
            }
        }

        return score;
    }
}
