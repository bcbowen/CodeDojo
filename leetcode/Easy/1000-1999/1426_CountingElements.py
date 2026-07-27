import pytest

class Solution:
    def countElements(self, arr: list[int]) -> int:
        values = set() 
        for num in arr: 
            values.add(num)
        
        result = 0
        for num in arr: 
            if num + 1 in values: 
                result += 1

        return result

"""
Example 1:
Input: arr = [1,2,3]
Output: 2
Explanation: 1 and 2 are counted cause 2 and 3 are in arr.

Example 2:
Input: arr = [1,1,3,3,5,5,7,7]
Output: 0
Explanation: No numbers are counted, cause there is no 2, 4, 6, or 8 in arr.
"""
@pytest.mark.parametrize("arr, expected", [
    ([1,2,3], 2),
    ([1,1,3,3,5,5,7,7], 0) 
])
def test_countElements(arr: list[int], expected: int):
    sol = Solution()
    result = sol.countElements(arr)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])