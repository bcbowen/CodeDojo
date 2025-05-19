import pytest

# The guess API is already defined for you.
# @param num, your guess
# @return -1 if num is higher than the picked number
#          1 if num is lower than the picked number
#          otherwise return 0
# def guess(num: int) -> int:

class Solution:
    def __init__(self): 
        self.api = GuessApi(4)
    
    def guessNumber(self, n: int) -> int:
        left = 0
        right = n
        while left < right: 
            mid = (left + right) // 2
            result = self.guess(mid)
            if result == 0: 
                return mid
            elif result == -1: 
                left = mid + 1
            else: 
                right = mid - 1
        raise Exception("Not found!")

    def setApi(self, pick: int): 
        self.api = GuessApi(pick)

    def guess(self, val: int) -> int: 
        return self.api.guess(val)

class GuessApi:

    def __init__(self, pick: int): 
        self.pick = pick

    def guess(self, num: int) -> int:
        if num < self.pick:
            return -1
        elif num > self.pick: 
            return 1
        else: 
            return 0

"""
Example 1:

Input: n = 10, pick = 6
Output: 6
Example 2:

Input: n = 1, pick = 1
Output: 1
Example 3:

Input: n = 2, pick = 1
Output: 1
 
"""
@pytest.mark.parametrize("n, pick", [
    (10, 6), 
    (1, 1), 
    (2, 1)
])
def test_guess(n: int, pick: int): 
    sol = Solution()
    sol.setApi(pick)
    result = Solution().guessNumber(n)
    assert(result == pick)


if __name__ == "__main__": 
    pytest.main([__file__])