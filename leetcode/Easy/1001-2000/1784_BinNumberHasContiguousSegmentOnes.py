class Solution:
    def checkOnesSegment(self, s: str) -> bool:
        if len(s) == 1: 
            return s == '1'
        for i in range(1, len(s)): 
            if s[i] == '1' and s[i - 1] == '1': 
                return True
        return False       