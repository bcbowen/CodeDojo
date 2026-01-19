from typing import List

class Solution:
    def minMoves(self, nums: List[int]) -> int:
        m = max(nums)
        moves = 0
        for num in nums: 
            moves += m - num
        return moves