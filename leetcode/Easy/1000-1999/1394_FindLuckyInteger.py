from collections import Counter
from typing import List

class Solution:
    def findLucky(self, arr: List[int]) -> int:
        counts = Counter(arr)
        largest = -float('inf')
        for key in counts.keys(): 
            if counts[key] == key: 
                largest = max(largest, key)
        return -1 if largest == -float('inf') else int(largest)