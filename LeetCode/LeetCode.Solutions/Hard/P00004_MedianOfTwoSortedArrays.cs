using System.ComponentModel;

namespace LeetCode.Solutions.Hard.P00004_MedianOfTwoSortedArrays;

public class Solution
{    
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        double[] merged = Merge(nums1, nums2);
        
        double median = 0; 

        if (merged.Length % 2 == 0)
        {
            median = (merged[(merged.Length / 2) - 1] + merged[merged.Length / 2]) / 2;
        }
        else
        {
            median = merged[merged.Length / 2];
        }

        return median; 
    }

    internal double[] Merge(int[] nums1, int[] nums2) 
    {
        double[] merged = new double[nums1.Length + nums2.Length];
        int i1 = 0;
        int i2 = 0;
        int i3 = 0;
        while (i3 < merged.Length)
        {
            if (i1 == nums1.Length)
            {
                merged[i3++] = nums2[i2++];
            }
            else if (i2 == nums2.Length) 
            {
                merged[i3++] = nums1[i1++];
            }
            else if (nums1[i1] < nums2[i2])
            {
                merged[i3++] = nums1[i1++];
            }
            else
            {
                merged[i3++] = nums2[i2++];
            }
        }

        return merged; 
    }
}