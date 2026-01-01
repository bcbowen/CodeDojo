from typing import List

class Solution:
    def plusOne(self, digits: List[int]) -> List[int]:
        result = [0] * len(digits) 
        carry = 1
        for i in range(len(digits) -1, -1, -1): 
            if digits[i] == 9 and carry == 1: 
                result[i] = 0
            elif carry == 1: 
                result[i] = digits[i] + 1
                carry = 0
            else: 
                result[i] = digits[i]
        if carry == 1: 
            result.insert(0, 1)
        return result