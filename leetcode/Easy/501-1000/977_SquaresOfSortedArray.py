class Solution:
    def sortedSquares(self, nums: list[int]) -> list[int]:
        squares = [0] * len(nums)
        for i, n in enumerate(nums):
            squares[i] = n**2
        
        squares.sort()
        return squares