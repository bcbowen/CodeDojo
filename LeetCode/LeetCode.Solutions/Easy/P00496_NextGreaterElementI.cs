namespace LeetCode.Solutions.Easy.P00496_NextGreaterElementI;

public class Solution
{
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        int[] result = new int[nums1.Length];
        Dictionary<int, int> lookUp = new Dictionary<int, int>();
        for (int i = 0; i < nums2.Length; i++)
        {
            lookUp.Add(nums2[i], i);
        }

        for (int i = 0; i < nums1.Length; i++)
        {
            int value = nums1[i];
            int n2Index = lookUp[value];
            for (int j = n2Index; j < nums2.Length; j++)
            {
                if (nums2[j] > value)
                {
                    result[i] = nums2[j];
                    break;
                }
            }
            if (result[i] == 0) result[i] = -1;
        }

        return result;
    }
}

