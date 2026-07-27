class Solution:
    def possibleStringCount(self, word: str) -> int:
        result = 1
        for i in range(1, len(word)): 
            if word[i] == word[i - 1]: 
                result += 1
        return result