class Solution:
    def countLetters(self, s: str) -> int:
        result = 0
        for i in range(len(s)): 
            for j in range(i, len(s)): 
                if i == j: 
                    result += 1
                elif s[i] == s[j]: 
                    result += 1
                else: 
                    break

        return result 

        