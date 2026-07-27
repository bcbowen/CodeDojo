from typing import List

class Solution:
    def findOcurrences(self, text: str, first: str, second: str) -> List[str]:
        occurences = []
        words = text.split(' ')
        if len(words) < 3: 
            return occurences
         
        for i in range(len(words) - 2): 
            if words[i] == first and words[i + 1] == second: 
                occurences.append(words[i + 2])
        return occurences