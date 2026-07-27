class Solution:
    def smallestNumber(self, n: int) -> int:
        i = 1
        accumulator = 2
        while i < n: 
            i += accumulator
            accumulator *= 2
        return i