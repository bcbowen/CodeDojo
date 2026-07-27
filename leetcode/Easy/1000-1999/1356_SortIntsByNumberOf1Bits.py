from typing import List

class Solution:
    def sortByBits(self, arr: List[int]) -> List[int]:
        arr.sort(key=lambda n: (bin(n).count('1'), n))
        return arr