from typing import List

def findErrorNums(self, nums: List[int]) -> List[int]:
        counts = [0] * (len(nums) + 1)
        dupe = -1
        for n in nums: 
            counts[n] += 1
            if counts[n] == 2: 
                dupe = n
        for i in range(1, len(nums) + 1): 
            if counts[i] == 0: 
                return [dupe, i]
        return []