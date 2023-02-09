using LeetCode.Models.Tree.BinaryTree;

namespace LeetCode.Solutions.Easy.P00108_ConvertSortedArrayToBST;

public class Solution
{
    public TreeNode SortedArrayToBST(int[] nums)
    {
        TreeNode node = null;
        if (nums == null || nums.Length == 0) return node;

        if (nums.Length == 1) return new TreeNode(nums[0]);

        int mid = nums.Length / 2;
        node = new TreeNode(nums[mid]);
        for (int i = mid - 1; i >= 0; i--)
        {
            node.AddNode(nums[i]);
        }
        for (int i = mid + 1; i <= nums.Length; i++)
        {
            node.AddNode(nums[i]);
        }

        return node;
    }
}