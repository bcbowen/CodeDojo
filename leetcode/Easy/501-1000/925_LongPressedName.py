import pytest

class Solution:
    def isLongPressedName(self, name: str, typed: str) -> bool:
        if name == typed: return True
        if len(typed) < len(name): return False
        if name[0] != typed[0] or name[-1] != typed[-1]: return False

        j = 0
        for i in range(len(name)):
            if j >= len(typed): 
                if i < len(name): 
                    return False
                break
            
            if name[i] != typed[j]: 
                if i == 0 or name[i - 1] != typed[j]: 
                    return False
                while j < len(typed) and name[i] != typed[j]:
                    if typed[j] != name[i] and typed[j] != name[i - 1]: 
                        return False
                    j += 1
            j += 1
            

        last = name[-1]
        while j < len(typed): 
            if typed[j] != last: 
                return False
            j += 1

        return True

    def isLongPressedName_1(self, name: str, typed: str) -> bool:
        if name == typed: 
            return True
        
        if len(typed) < len(name): 
            return False
        
        if name[0] != typed[0]: 
            return False
    
        i = 1
        j = 1
        while i < len(name) and j < len(typed): 
            if typed[j] != name[i]: 
                if typed[j] != name[i - 1]: 
                    return False
                while j < len(typed) and typed[j] != name[i]: 
                    if typed[j] != name[i] and typed[j] != typed[j - 1]: 
                        return False
                    j += 1
            
            i += 1
            j += 1


        if j == len(typed) and i < len(name): 
            return False
        
        last = name[-1]
        while j < len(typed): 
            if typed[j] != last: 
                return False
            j += 1

        return True

        

"""
Example 1:
Input: name = "alex", typed = "aaleex"
Output: true
Explanation: 'a' and 'e' in 'alex' were long pressed.

Example 2:
Input: name = "saeed", typed = "ssaaedd"
Output: false
Explanation: 'e' must have been pressed twice, but it was not in the typed output.

TC 25: 
name = "alex" typed = "aaleexeex" ex = False

TC 27:
name = "plpkoh" typed = "plppkkh"

TC 37
in: alex, typed: aaleexa, ex: False

TC 41
name = "pyplrz" typed = "ppyypllr" expecetd: False

name = "kikcxmvzi" typed = "kiikcxxmmvvzz" ex = False

TC 90: 
name = "alex" typed = "aaleelx" ex = False

TC 92: 
name = "bdad" typed = "bbbd" ex: False

"""
@pytest.mark.parametrize("name, typed, expected", [
    ("bdad", "bbbd", False),
    ("alex", "aaleelx", False),
    ("plpkoh", "plppkkh", False), 
    ("alex", "aaleexeex", False), 
    ("alex", "aaleex", True), 
    ("saeed", "ssaaedd", False), 
    ("alex", "aalleax", False), 
    ("alex", "aaleexa", False), 
    ("pyplrz", "ppyypllr", False), 
    ("kikcxmvzi", "kiikcxxmmvvzz", False)
])
def test_isLongPressedName(name: str, typed: str, expected: bool):
    result = Solution().isLongPressedName(name, typed)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])