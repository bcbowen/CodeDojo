import pytest
from typing import List

class Solution:
    def candy(self, ratings: List[int]) -> int:
        if len(ratings) < 2: 
            return len(ratings)
        elif len(ratings) == 2: 
            return 2 if ratings[0] == ratings[1] else 3

        distribution = [1] * len(ratings)
        for i in range(1, len(ratings)): 
            if ratings[i] > ratings[i - 1]: 
                distribution[i] = distribution[i - 1] + 1
        sum = distribution[-1]

        for i in range(len(ratings) - 2, -1, -1): 
            if ratings[i] > ratings[i + 1] and distribution[i] <= distribution[i + 1]: 
                distribution[i] = distribution[i + 1] + 1
            sum += distribution[i]

        return sum

"""
Example 1:
Input: ratings = [1,0,2]
Output: 5
Explanation: You can allocate to the first, second and third child with 2, 1, 2 candies respectively.

Example 2:
Input: ratings = [1,2,2]
Output: 4
Explanation: You can allocate to the first, second and third child with 1, 2, 1 candies respectively.
The third child gets 1 candy because it satisfies the above two conditions.

TC17 
[1,2,87,87,87,2,1] -> 13

TC18
[1,3,2,2,1] -> 7
"""
@pytest.mark.parametrize("ratings, expected", [
     ([1,0,2], 5), 
     ([1,2,2], 4), 
     ([1,3,2,2,1], 7), 
     ([1,2,87,87,87,2,1], 13)
])
def test_candy(ratings: List[int], expected: int):
    result = Solution().candy(ratings)
    assert(result == expected)
if __name__ == "__main__":
    pytest.main([__file__]) 