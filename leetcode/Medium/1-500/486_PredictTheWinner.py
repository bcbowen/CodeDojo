import pytest 

from typing import List, Tuple

class Solution:
    
    def predictTheWinner(self, nums: List[int]) -> bool:
        self.memo = []
        n = len(nums)
        for _ in range(n): 
            self.memo.append([-1] * n)
            
        result = self.max_diff(nums, 0, n - 1)
        return result >= 0

    def max_diff(self, nums: List, l: int, r: int) -> int: 
        if l > r: 
            return 0

        if self.memo[l][r] != -1: 
            self.memo[l][r]

        left = nums[l] - self.max_diff(nums, l + 1, r)
        right = nums[r] - self.max_diff(nums, l, r - 1)

        result = max(left, right)
        self.memo[l][r] = result
        return result

"""
Example 1:
Input: nums = [1,5,2]
Output: false
Explanation: Initially, player 1 can choose between 1 and 2. 
If he chooses 2 (or 1), then player 2 can choose from 1 (or 2) and 5. If player 2 chooses 5, then player 1 will be left with 1 (or 2). 
So, final score of player 1 is 1 + 2 = 3, and player 2 is 5. 
Hence, player 1 will never be the winner and you need to return false.

Example 2:
Input: nums = [1,5,233,7]
Output: true
Explanation: Player 1 first chooses 1. Then player 2 has to choose between 5 and 7. No matter which number player 2 choose, player 1 can choose 233.
Finally, player 1 has more score (234) than player 2 (12), so you need to return True representing player1 can win.
"""

@pytest.mark.parametrize("nums, expected", [
    ([1,5,2], False), 
    ([1,5,233,7], True)
])
def test(nums: List[int], expected: bool): 
    result = Solution().predictTheWinner(nums)
    assert(result == expected)


"""
@pytest.mark.parametrize("nums, expected1, expected2", [
    ([1,5,2], 2, 5), 
    ([1,5,233,7], 234, 12)
])
def test_play(nums: List[int], expected1: int, expected2: int):
    result1, result2 = Solution.play(0, 0, nums)
    assert(result1 == expected1) 
    assert(result2 == expected2)
"""

if __name__ == "__main__": 
    pytest.main([__file__])