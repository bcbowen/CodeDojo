import pytest

class Solution:
    def dailyTemperatures(self, temperatures: list[int]) -> list[int]:
        result = [0] * len(temperatures)
        stack = []
        for i in range(len(temperatures)): 
            while stack and temperatures[stack[-1]] < temperatures[i]: 
                j = stack.pop()
                result[j] = i - j
            stack.append(i)
        return result

"""
Example 1:
Input: temperatures = [73,74,75,71,69,72,76,73]
Output: [1,1,4,2,1,1,0,0]

Example 2:
Input: temperatures = [30,40,50,60]
Output: [1,1,1,0]

Example 3:
Input: temperatures = [30,60,90]
Output: [1,1,0]
"""
@pytest.mark.parametrize("temperatures, expected", [
    ([73,74,75,71,69,72,76,73], [1,1,4,2,1,1,0,0]),
    ([30,40,50,60], [1,1,1,0]),
    ([30,60,90], [1,1,0]) 
])
def test_dailyTemperatures(temperatures: list[int], expected: list[int]):
    sol = Solution()
    result = sol.dailyTemperatures(temperatures)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 