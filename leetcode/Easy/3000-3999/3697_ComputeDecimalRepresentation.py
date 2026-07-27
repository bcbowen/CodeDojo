from typing import List

class Solution:
    def decimalRepresentation(self, n: int) -> List[int]:
        components = [] 
        factor = 1
        while n > 0: 
            r = n % 10 
            if r > 0: 
                components.insert(0, r * factor)
            factor *= 10
            n //= 10

        return components