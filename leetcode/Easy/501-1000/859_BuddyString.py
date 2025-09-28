from typing import List

class Solution:
    def buddyStrings(self, s: str, goal: str) -> bool:
        if len(s) != len(goal) or len(s) < 2: 
            return False
        
        mismatches = [] 
        has_repeat = False
        letters = set()
        for i in range(len(s)): 
            if s[i] != goal[i]: 
                mismatches.append(i)
            if s[i] in letters: 
                has_repeat = True
            else: 
                letters.add(s[i])

        if len(mismatches) != 2:
            if s == goal and has_repeat: 
                return True
            else: 
                return False 
        if s[mismatches[0]] != goal[mismatches[1]] or s[mismatches[1]] != goal[mismatches[0]]: 
            return False  

        return True

        