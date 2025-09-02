from typing import List

class Solution:
    def nextGreatestLetter(self, letters: List[str], target: str) -> str:
        t = ord(target)
        for letter in letters: 
            r = ord(letter)
            if r > t:
                return letter
        return letters[0]