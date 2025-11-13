from collections import Counter
from functools import reduce
from typing import List
import math

class Solution:
    def hasGroupsSizeX(self, deck: List[int]) -> bool:
        counts = Counter(deck)
        size = reduce(math.gcd, counts.values()) #min(counts.values())
        if size == 1: 
            return False

        for _, v in counts.items(): 
            if v == size: 
                continue
            elif v < size: 
                return False
            elif v % size != 0: 
                return False
            
        return True
    
