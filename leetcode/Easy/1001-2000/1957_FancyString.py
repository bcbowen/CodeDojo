class Solution:
    def makeFancyString(self, s: str) -> str:
        if len(s) < 3: 
            return s
        result = [s[0]] 
        c = s[0]
        count = 1
        i = 1
        while i < len(s): 
            if s[i] == c: 
                count += 1
                if count < 3: 
                    result.append(c)
            else: 
                c = s[i]
                count = 1
                result.append(c)
            i += 1

        return ''.join(result)