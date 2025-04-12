import pytest
from typing import List

class Solution:
    def answerQueries(self, nums: List[int], queries: List[int]) -> List[int]:
        nums.sort()
        result = [] 
        for i in queries: 
            current = 0
            count = 0
            for num in nums: 
                current += num

                if current > i: 
                    break
                count += 1
            result.append(count)
        return result


"""
Example 1:
Input: nums = [4,5,2,1], queries = [3,10,21]
Output: [2,3,4]
Explanation: We answer the queries as follows:
- The subsequence [2,1] has a sum less than or equal to 3. It can be proven that 2 is the maximum size of such a subsequence, so answer[0] = 2.
- The subsequence [4,5,1] has a sum less than or equal to 10. It can be proven that 3 is the maximum size of such a subsequence, so answer[1] = 3.
- The subsequence [4,5,2,1] has a sum less than or equal to 21. It can be proven that 4 is the maximum size of such a subsequence, so answer[2] = 4.

Example 2:
Input: nums = [2,3,4,5], queries = [1]
Output: [0]
Explanation: The empty subsequence is the only subsequence that has a sum less than or equal to 1, so answer[0] = 0.
 
"""
@pytest.mark.parametrize("nums, queries, expected", [
    ([4,5,2,1], [3,10,21], [2,3,4]), 
    ([2,3,4,5], [1], [0])
])
def test_answerQueries(nums: List[int], queries: List[int], expected: List[int]):
    result = Solution().answerQueries(nums, queries)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])