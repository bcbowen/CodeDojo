class Solution:
    def makeGood(self, s: str) -> str:
        
        chars = []
        for c in s: 
            if chars: 
                c2 = chars[-1]
                if c.islower() and c2.isupper() and c2.lower() == c or \
                    c2.islower() and c.isupper() and c.lower() == c2:
                    chars.pop()
                    continue
                else: 
                    chars.append(c)
 
            else: 
                chars.append(c)
 
