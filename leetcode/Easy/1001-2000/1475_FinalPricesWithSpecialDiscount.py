import pytest
from typing import List

class Solution:
    # monotonic stack
    def finalPrices(self, prices: List[int]) -> List[int]:
        result = prices.copy()
        indices = [] 
        for i in range(len(prices)): 
            if len(indices) > 0: 
                top = indices[-1]

                if prices[i] <= prices[top]: 
                    while len(indices) > 0 and prices[indices[-1]] >= prices[i]: 
                        discount_index = indices.pop()
                        result[discount_index] -= prices[i]
            indices.append(i)
        return result

    # first: brute force
    def finalPrices_1(self, prices: List[int]) -> List[int]:
        
        result = prices.copy()
        for i in range(len(prices)): 
            for j in range(i + 1, len(prices)): 
                if prices[j] <= prices[i]: 
                    result[i] -= prices[j]
                    break
        return result
    

"""
Example 1:
Input: prices = [8,4,6,2,3]
Output: [4,2,4,2,3]
Explanation: 
For item 0 with price[0]=8 you will receive a discount equivalent to prices[1]=4, therefore, the final price you will pay is 8 - 4 = 4.
For item 1 with price[1]=4 you will receive a discount equivalent to prices[3]=2, therefore, the final price you will pay is 4 - 2 = 2.
For item 2 with price[2]=6 you will receive a discount equivalent to prices[3]=2, therefore, the final price you will pay is 6 - 2 = 4.
For items 3 and 4 you will not receive any discount at all.

Example 2:
Input: prices = [1,2,3,4,5]
Output: [1,2,3,4,5]
Explanation: In this case, for all items, you will not receive any discount at all.

Example 3:
Input: prices = [10,1,1,6]
Output: [9,0,1,6]
    
TC 13: 
Input
prices =
[8,7,4,2,8,1,7,7,10,1]

Expected
[1,3,2,1,7,0,0,6,9,1]
"""
@pytest.mark.parametrize("prices, expected", [
    ([8,7,4,2,8,1,7,7,10,1], [1,3,2,1,7,0,0,6,9,1]), 
    ([8,4,6,2,3], [4,2,4,2,3]), 
    ([1,2,3,4,5], [1,2,3,4,5]), 
    ([10,1,1,6], [9,0,1,6])
])
def test_finalPrices(prices: List[int], expected: List[int]):
    result = Solution().finalPrices(prices)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])