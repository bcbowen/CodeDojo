from typing import List

class Solution:
    def isOneBitCharacter(self, bits: List[int]) -> bool:
        if bits[-1] == 1: 
            return False
        
        i = 0
        while i < len(bits): 
            if bits[i] == 1:
                i += 2
                if i >= len(bits): 
                    return False
            else: 
                i += 1
                if i == len(bits):
                    return True
         
        raise Exception("Well this is odd")
