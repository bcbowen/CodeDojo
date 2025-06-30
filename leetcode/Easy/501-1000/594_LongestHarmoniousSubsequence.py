from collections import defaultdict, Counter
from typing import List

class Solution:
    def findLHS(self, nums: List[int]) -> int:
        counts = Counter(nums)
        print(counts)
        count_items = sorted(counts.items())
        longest_sequence = 0
        for i in range(1, len(count_items)): 
            if count_items[i][0] - count_items[i - 1][0] == 1: 
                longest_sequence = max(longest_sequence, count_items[i][1] + count_items[i - 1][1])
        return longest_sequence