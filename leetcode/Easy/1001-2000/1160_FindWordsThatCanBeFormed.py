from typing import List 
from collections import Counter

class Solution:
    def countCharacters(self, words: List[str], chars: str) -> int:
        result = 0 
        master_chars = Counter(chars)
        for word in words: 
            is_valid = True
            word_chars = Counter(word)
            for letter, count in word_chars.items(): 
                if not is_valid: 
                    continue
                if letter not in master_chars: 
                    is_valid = False
                if count > master_chars[letter]: 
                    is_valid = False
            if is_valid: 
                result += len(word)
        return result

