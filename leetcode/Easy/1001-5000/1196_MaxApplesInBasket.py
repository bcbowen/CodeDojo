import pytest
from typing import List 

class Solution:
    def maxNumberOfApples(self, weight: List[int]) -> int:
        max_weight = 5000
        total_weight = 0
        apple_count = 0
        weight.sort()
        for i in range(len(weight)): 
            if (total_weight + weight[i] <= max_weight): 
                total_weight += weight[i]
                apple_count += 1
            else: 
                break
        return apple_count

"""
Example 1:
Input: weight = [100,200,150,1000]
Output: 4
Explanation: All 4 apples can be carried by the basket since their sum of weights is 1450.

Example 2:
Input: weight = [900,950,800,1000,700,800]
Output: 5
Explanation: The sum of weights of the 6 apples exceeds 5000 so we choose any 5 of them.
"""
@pytest.mark.parametrize("weight, expected", [
    ([100,200,150,1000], 4), 
    ([900,950,800,1000,700,800], 5)
])
def test_maxNumberOfApples(weight: List[int], expected: int):
    result = Solution().maxNumberOfApples(weight)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 