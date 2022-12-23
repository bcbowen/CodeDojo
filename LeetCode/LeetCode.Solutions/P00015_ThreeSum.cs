namespace LeetCode.Solutions.P00015_ThreeSum;

public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);
        IList<IList<int>> result = new List<IList<int>>();

        for (int x = 0; x < nums.Length - 2; x++)
        {
            if (x == 0 || (x > 0 && nums[x] != nums[x - 1]))
            {
                int y = x + 1;
                int z = nums.Length - 1;
                while (y < z)
                {
                    int diff = 0 - nums[x];
                    int current = nums[y] + nums[z];
                    if (current == diff)
                    {
                        while (y < z && nums[y + 1] == nums[y]) y++;
                        while (z > y && nums[z - 1] == nums[z]) z--;
                        result.Add(new List<int> { nums[x], nums[y], nums[z] });
                        z--;
                    }
                    else if (current < diff)
                    {

                        y++;
                    }
                    else
                    {

                        z--;
                    }

                }
            }

        }
        return result;
    }

    public IList<IList<int>> ThreeSumBrute(int[] nums)
    {
        // exceeds max time
        Array.Sort(nums);
        IList<IList<int>> result = new List<IList<int>>();

        for (int x = 0; x < nums.Length - 2; x++)
        {
            for (int y = x + 1; y < nums.Length - 1; y++)
            {
                for (int z = y + 1; z < nums.Length; z++)
                {
                    if (nums[x] + nums[y] + nums[z] == 0)
                    {
                        if (!result.Any(r => r[0] == nums[x] && r[1] == nums[y] && r[2] == nums[z]))
                        {
                            result.Add(new List<int> { nums[x], nums[y], nums[z] });
                        }

                    }
                }

            }
        }
        return result;
    }

    public IList<IList<int>> ThreeSum1(int[] nums)
    {
        // doesn't work sometimes
        Array.Sort(nums);
        IList<IList<int>> result = new List<IList<int>>();

        for (int x = 0; x < nums.Length - 2; x++)
        {
            //if (nums[x] == nums[x + 1]) x++; 
            int y = x + 1;
            int z = nums.Length - 1;

            while (y < z)
            {
                if (nums[x] + nums[y] + nums[z] == 0)
                {
                    if (!result.Any(r => r[0] == nums[x] && r[1] == nums[y] && r[2] == nums[z]))
                    {
                        result.Add(new List<int> { nums[x], nums[y], nums[z] });
                    }

                }
                while (y < z && nums[y + 1] == nums[y]) y++;
                while (z > y && nums[z - 1] == nums[z]) z--;
                y++;
                z--;
            }
        }
        return result;
    }
}