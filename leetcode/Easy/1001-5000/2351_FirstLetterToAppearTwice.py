import pytest

class Solution:
    def repeatedCharacter(self, s: str) -> str:
        seen = set() 
        for c in s: 
            if c in seen: 
                return c
            else: 
                seen.add(c)
        raise Exception("No repeats, buddy")

if __name__ == "__main__": 
    pytest.main([__file__])