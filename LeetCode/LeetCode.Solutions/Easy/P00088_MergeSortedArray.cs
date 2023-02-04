namespace LeetCode.Solutions.Easy.P00088_MergeSortedArray;

public class Solution
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int l = nums1.Length - 1;
        m--;
        n--;
        while (n >= 0)
        {
            if (m >= 0 && nums1[m] > nums2[n])
            {
                nums1[l] = nums1[m];
                m--;
            }
            else
            {
                nums1[l] = nums2[n];
                n--;
            }
            l--;
        }
    }
}