class Solution:
    def balancedStringSplit(self, s: str) -> int:
        result = 0
        level = 0
        open = s[0]
        for c in s: 
            if c == open: 
                level += 1
            else:
                level -= 1
            if level == 0: 
                result += 1

        return result