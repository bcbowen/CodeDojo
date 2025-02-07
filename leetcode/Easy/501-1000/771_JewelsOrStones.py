import pytest

class Solution:
    def numJewelsInStones(self, jewels: str, stones: str) -> int:
        jewel_lookup = set() 
        for c in jewels: 
            jewel_lookup.add(c)

        count = 0
        for c in stones: 
            if c in jewel_lookup: 
                count += 1

        return count

if __name__ == "__main__":
    pytest.main([__file__]) 