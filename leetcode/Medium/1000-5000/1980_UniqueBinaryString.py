from typing import List

class Solution:
    def findDifferentBinaryString(self, nums: List[str]) -> str:
        n = len(nums)
        result = ""
        def backtrack(val: str):
            nonlocal result 
            if result != "": 
                return
            if len(val) == n:
                if val not in nums:
                    result = val
                return
            backtrack(val + '0')
            backtrack(val + '1')
        backtrack('')
        return result

