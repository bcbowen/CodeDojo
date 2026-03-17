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
            pairs.sort(key=lambda p: p[1], reverse=True)
            for i in range(len(pairs)): 
                if pairs[i][1] != counts[result[0]]: 
                    result[1] = pairs[i][0]
                    break

        if result[1] == -1: 
            result[0] = -1

        return result
