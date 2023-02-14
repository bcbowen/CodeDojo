namespace LeetCode.Solutions.Easy.P00001_TwoSum;

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        int[] solution = new int[2];
        Dictionary<int, int> map = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int compliment = target - nums[i];
            if (map.ContainsKey(compliment))
            {
                solution[0] = map[compliment];
                solution[1] = i;
                break;
            }
            else
            {
                if (!map.ContainsKey(nums[i]))
                {
                    map.Add(nums[i], i);
                }
            }
        }

        return solution;
    }

    public int[] TwoSumBrute(int[] nums, int target)
    {
        int[] solution = new int[2];
        bool done = false;

        for (int x = 0; x < nums.Length - 1; x++)
        {
            for (int y = x + 1; y < nums.Length; y++)
            {
                if (nums[x] + nums[y] == target)
                {
                    solution[0] = x;
                    solution[1] = y;
                    done = true;
                    break;
                }
            }
            if (done) break;
        }
        return solution;
    }
}