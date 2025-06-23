from typing import List

class Solution:
    """
    the first row consists of the characters "qwertyuiop",
    the second row consists of the characters "asdfghjkl", and
    the third row consists of the characters "zxcvbnm".
    """
    def findWords(self, words: List[str]) -> List[str]:
        rows = {0: "qwertyuiop", 1: "asdfghjkl", 2: "zxcvbnm"}

        def find_key(c: str) -> int: 
            for key in rows.keys(): 
                if c in rows[key]: 
                    return key
            raise Exception(f"Invalid letter: {c}")
        
        result = [] 

        for word in words: 
            key = find_key(word[0].lower()) 
            for c in word: 
                if not c.lower() in rows[key]: 
                    break
            else: 
                result.append(word) 

        return result
        
