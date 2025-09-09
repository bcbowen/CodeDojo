from collections import defaultdict
from typing import List
import re

class Solution:
    def mostCommonWord(self, paragraph: str, banned: List[str]) -> str:
        ban_lookup = set(banned)
        counts = defaultdict(int)
        max_word = [0, ""]

        words = re.findall(r"\w+", paragraph.lower())
        for word in words: 
            if not word in ban_lookup: 
                counts[word] += 1
                if counts[word] > max_word[0]: 
                    max_word[0] = counts[word]
                    max_word[1] = word

        return max_word[1]
