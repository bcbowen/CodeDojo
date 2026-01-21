from typing import List

class Solution:
    def divideString(self, s: str, k: int, fill: str) -> List[str]:
        result = [] 
        i = 0 
        segment = ""
        while i < len(s):
            for j in range(i, i + k): 
                if j < len(s): 
                    segment += s[j]
                else: 
                    segment += fill
            result.append(segment)
            segment = ""
            i += k

        return result