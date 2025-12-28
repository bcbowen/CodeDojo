import pytest
from typing import List

class Solution:
    def maximumHappinessSum(self, happiness: List[int], k: int) -> int:
        happiness.sort(reverse=True)
        i = 0
        result = 0
        while i < len(happiness) and i < k: 
            if happiness[i] - i <= 0: 
                break
            result += happiness[i] - i
            i += 1
            
        return result

"""
Example 1:
Input: happiness = [1,2,3], k = 2
Output: 4
Explanation: We can pick 2 children in the following way:
- Pick the child with the happiness value == 3. The happiness value of the remaining children becomes [0,1].
- Pick the child with the happiness value == 1. The happiness value of the remaining child becomes [0]. Note that the happiness value cannot become less than 0.
The sum of the happiness values of the selected children is 3 + 1 = 4.

Example 2:
Input: happiness = [1,1,1,1], k = 2
Output: 1
Explanation: We can pick 2 children in the following way:
- Pick any child with the happiness value == 1. The happiness value of the remaining children becomes [0,0,0].
- Pick the child with the happiness value == 0. The happiness value of the remaining child becomes [0,0].
The sum of the happiness values of the selected children is 1 + 0 = 1.

Example 3:
Input: happiness = [2,3,4,5], k = 1
Output: 5
Explanation: We can pick 1 child in the following way:
- Pick the child with the happiness value == 5. The happiness value of the remaining children becomes [1,2,3].
The sum of the happiness values of the selected children is 5.

TC9: [7,50,3] k=3 -> 57

"""
@pytest.mark.parametrize("happiness, k, expected", [
    ([1, 2, 3], 2, 4),
    ([1, 1, 1, 1], 2, 1), 
    ([2, 3, 4, 5], 1, 5), 
    ([7, 50, 3], 3, 57)
])
def test_maximumHappinessSum(happiness: List[int], k: int, expected: int):
    result = Solution().maximumHappinessSum(happiness, k)
    assert(result == expected)        


if __name__ == "__main__":
    pytest.main([__file__])