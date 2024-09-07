import pytest

# Definition for a binary tree node.
class TreeNode(object):
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution(object):
    def countPairs(self, root, distance):
        """
        :type root: TreeNode
        :type distance: int
        :rtype: int
        """
        count = 0

    def get_pair(self, root, distance): 
        steps = 1
        nodeStack = []
        nodeStack.push(root)
        while steps < distance and len(nodeStack > 0):
            current = nodeStack.pop()
            if current.left != None: 
                




    

@pytest.mark.parametrize("rating, expected", [
    ([2, 5, 3, 4, 1], 3),
    ([2, 1, 3], 0),
    ([1, 2, 3, 4], 4), 
    ([4, 3, 2, 1], 4)
])
def test_number_of_pairs(rating, expected):
    result = Solution().numTeams(rating)
    assert result == expected

if __name__ == "__main__":
    pytest.main([__file__])