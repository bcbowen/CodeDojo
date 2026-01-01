from typing import List

class Solution:
    def diStringMatch(self, s: str) -> List[int]:
        result = []
        i = 0
        j = len(s)
        for c in s: 
            if c == 'I': 
                result.append(i)
                i += 1
            else: 
                result.append(j)
                j -= 1
        result.append(i)
        return result