from typing import List, Dict


class Solution:
    def shortestCompletingWord(self, licensePlate: str, words: List[str]) -> str:
        def get_counts(word: str) -> Dict[str, int]:
            counts = {} 
            for c in word: 
                if c.isalpha(): 
                    c = c.lower()
                    if not c in counts: 
                        counts[c] = 0
                    counts[c] += 1    
            return counts

        def is_match(main: Dict[str, int], test: Dict[str, int]) -> bool: 
            for key, val in main.items(): 
                if not key in test or test[key] < main[key]: 
                    return False
            return True

        lp_counts = get_counts(licensePlate) 
                
        min_len = float('inf')
        min_word = ""

        for word in words: 
            if len(word) > min_len: 
                continue

            word_counts = get_counts(word)
            if is_match(lp_counts, word_counts) and len(word) < min_len: 
                min_len = len(word)
                min_word = word
        return min_word
        
        
    