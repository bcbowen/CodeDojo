class Solution:
    def isPerfectSquare(self, num: int) -> bool:
        val = num**.5
        return val % 1 == 0