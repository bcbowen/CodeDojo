from typing import List

class Solution:
    def sortByAbsoluteValue(self, nums: List[int]) -> List[int]:
        vals = [] 
        for num in nums: 
            vals.append((num, abs(num)))
            vals.sort(key = lambda x: x[1])
        return [n[0] for n in vals]