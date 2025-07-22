from typing import List
from collections import Counter
class Solution:
    def distributeCandies(self, candyType: List[int]) -> int:
        counts = Counter(candyType)
        val = min(len(candyType) // 2, len(counts.keys()))
        return val