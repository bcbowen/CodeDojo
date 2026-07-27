from collections import Counter

class Solution:
    def filterCharacters(self, s: str, k: int) -> str:
        char_counts = Counter(s)
        new_s = [] 
        for c in s: 
            if char_counts[c] < k: 
                new_s.append(c)

        return "".join(new_s)