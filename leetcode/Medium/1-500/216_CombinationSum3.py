import pytest
from typing import List

class Solution:
    def combinationSum3(self, k: int, n: int) -> List[List[int]]:
        result = [] 

        def backtrack(nums: List[int], start: int):
            if len(nums) == k: 
                if sum(nums) == n: 
                    result.append(nums)
                return 
            elif sum(nums) > n or start > 9: 
                return 
            
            for i in range(start, 10):
                if not i in nums: 
                    nums.append(i)
                    backtrack(nums.copy(), i + 1)
                    nums.pop()

        backtrack([], 1)
        return result

"""
Example 1:
Input: k = 3, n = 7
Output: [[1,2,4]]
Explanation:
1 + 2 + 4 = 7
There are no other valid combinations.

Example 2:
Input: k = 3, n = 9
Output: [[1,2,6],[1,3,5],[2,3,4]]
Explanation:
1 + 2 + 6 = 9
1 + 3 + 5 = 9
2 + 3 + 4 = 9
There are no other valid combinations.

Example 3:
Input: k = 4, n = 1
Output: []
Explanation: There are no valid combinations.
Using 4 different numbers in the range [1,9], the smallest sum we can get is 1+2+3+4 = 10 and since 10 > 1, there are no valid combination.
"""
@pytest.mark.parametrize("k, n, expected", [
    (3, 7, [[1,2,4]]), 
    (3, 9, [[1,2,6],[1,3,5],[2,3,4]]), 
    (4, 1, [])
])
def test_combinationSum3(k: int, n: int, expected: List[List[int]]):
    result = Solution().combinationSum3(k, n)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__])
