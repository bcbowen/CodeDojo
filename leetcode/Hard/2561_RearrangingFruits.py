import pytest
from typing import List
from collections import Counter

class Solution:
    
    """
    freq = Counter()
        m = float("inf")
        for b1 in basket1:
            freq[b1] += 1
            m = min(m, b1)
        for b2 in basket2:
            freq[b2] -= 1
            m = min(m, b2)

        merge = []
        for k, c in freq.items():
            if c % 2 != 0:
                return -1
            merge.extend([k] * (abs(c) // 2))

        if not merge:
            return 0
        merge.sort()
        return sum(min(2 * m, x) for x in merge[: len(merge) // 2])
    """

    def minCost(self, basket1: List[int], basket2: List[int]) -> int:
        counts = Counter() 
        m = float('inf')
        for i in basket1: 
            counts[i] += 1
            m = min(m, i)

        for i in basket2: 
            counts[i] -= 1
            m = min(m, i)   

        merge = []
        for k, c in counts.items(): 
            if c % 2 == 1: 
                return -1
            
            merge.extend([k] * (abs(c) // 2))

        if not merge: 
            return 0
        
        merge.sort() 

        return int(sum(min(x, 2 * m) for x in merge[: len(merge) // 2]))

    # Attempt 1: 
    def minCost_1(self, basket1: List[int], basket2: List[int]) -> int:
        b1_counts = Counter(basket1)
        b2_counts = Counter(basket2)
        diffs = {}
        # get diffs for items in b1 not in b2 or in both with different amounts
        for bi in b1_counts.items(): 
            if bi[0] not in b2_counts: 
                diffs[bi[0]] = bi[1]
            elif bi[1] != b2_counts[bi[0]]: 
                diffs[bi[0]] = abs(bi[1] - b2_counts[bi[0]])
        
        # get diffs for items in b2 not in b1
        for bi in b2_counts.items(): 
            if bi[0] not in b1_counts: 
                diffs[bi[0]] = bi[1]

        diff_items = diffs.items()
        if len(diff_items) % 2 == 1: 
            return -1
        for diff_item in diff_items: 
            if diff_item[1] % 2 == 1: 
                return -1
            
        return len(diff_items) // 2
    
"""
Example 1:
Input: basket1 = [4,2,2,2], basket2 = [1,4,1,2]
Output: 1
Explanation: Swap index 1 of basket1 with index 0 of basket2, which has cost 1. Now basket1 = [4,1,2,2] and basket2 = [2,4,1,2]. Rearranging both the arrays makes them equal.

Example 2:
Input: basket1 = [2,3,4,1], basket2 = [3,2,5,1]
Output: -1
Explanation: It can be shown that it is impossible to make both the baskets equal.

TC 13
basket1 =
[4,4,4,4,3]
basket2 =
[5,5,5,5,3]

Use Testcase
Output
3
Expected
8

"""
@pytest.mark.parametrize("basket1, basket2, expected", [
    ([4,2,2,2], [1,4,1,2], 1), 
    ([2,3,4,1], [3,2,5,1], -1), 
    ([4,4,4,4,3], [5,5,5,5,3], 8)
])
def test_minCost(basket1: List[int], basket2: List[int], expected: int):
    result = Solution().minCost(basket1, basket2)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 