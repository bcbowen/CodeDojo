import pytest
from typing import List

from collections import Counter

class Solution:
    def minDistinctFreqPair(self, nums: List[int]) -> List[int]:
        counts = Counter(nums)
        pairs = [[k, v] for k, v in counts.items()]
        result = [-1, -1]
        if len(pairs) > 1:
            pairs.sort()
            result[0] = pairs[0][0]
            for i in range(1, len(pairs)): 
                if pairs[i][1] != counts[result[0]]: 
                    result[1] = pairs[i][0]
                    break

        if result[1] == -1: 
            result[0] = -1

        return result

"""
Example 1:
Input: nums = [1,1,2,2,3,4]
Output: [1,3]
Explanation:
The smallest value is 1 with a frequency of 2, and the smallest value greater than 1 that has a different frequency from 1 is 3 with a frequency of 1. Thus, the answer is [1, 3].

Example 2:
Input: nums = [1,5]
Output: [-1,-1]
Explanation:
Both values have the same frequency, so no valid pair exists. Return [-1, -1].

Example 3:
Input: nums = [7]
Output: [-1,-1]
Explanation:
There is only one value in the array, so no valid pair exists. Return [-1, -1].

TC 540
Input: [1,5,8,1,4,1,8]
Expected: [1,4]

TC 712
nums = [2,6,6,7,8,2,2,10]
Output [2,7]
Expected [2,6]

"""
@pytest.mark.parametrize("nums, expected", [
    ([1, 1, 2, 2, 3, 4], [1, 3]), 
    ([1 ,5], [-1, -1]), 
    ([7], [-1, -1]), 
    ([1, 5, 8, 1, 4, 1, 8], [1, 4]),
    ([2, 6, 6, 7, 8, 2, 2, 10], [2, 6])
])
def test_minDistinctFreqPair(nums: List[int], expected: List[int]):
    result = Solution().minDistinctFreqPair(nums)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 