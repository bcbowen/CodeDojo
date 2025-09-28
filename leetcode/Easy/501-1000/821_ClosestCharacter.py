import pytest
from typing import List


class Solution:
    def shortestToChar(self, s: str, c: str) -> List[int]:
        result = [0] * len(s)

        locations = [] 
        for i, val in enumerate(s): 
            if val == c: 
                locations.append(i)

        previous = -1
        next_index = 0
        next = locations[next_index]
        for i in range(len(s)): 
            if next_index >= 0 and i == next_index: 
                previous = lo

        return result    
    """
        i = 0
        j = 0
        while i < len(s): 
                
            while j < len(s) and s[j] != c: 
                j += 1

            if j >= len(s):
                k = i
                i += 1
                while i < len(s):
                    result[i] = i - k
                    i += 1


            while i != j:        
                result[i] = j - i 
                i += 1
            result[i] = 0
            while i < len(s) and s[i] == c: 
                i = j + 1
                j = i
        
        return result
    """

"""
Example 1:
Input: s = "loveleetcode", c = "e"
Output: [3,2,1,0,1,0,0,1,2,2,1,0]
Explanation: The character 'e' appears at indices 3, 5, 6, and 11 (0-indexed).
The closest occurrence of 'e' for index 0 is at index 3, so the distance is abs(0 - 3) = 3.
The closest occurrence of 'e' for index 1 is at index 3, so the distance is abs(1 - 3) = 2.
For index 4, there is a tie between the 'e' at index 3 and the 'e' at index 5, but the distance is still the same: abs(4 - 3) == abs(4 - 5) = 1.
The closest occurrence of 'e' for index 8 is at index 6, so the distance is abs(8 - 6) = 2.

Example 2:
Input: s = "aaab", c = "b"
Output: [3,2,1,0]
"""
@pytest.mark.parametrize("s, c, expected", [
    ("loveleetcode", "e", [3,2,1,0,1,0,0,1,2,2,1,0]),
    ("aaab", "b", [3,2,1,0]) 
])
def test_shortestToChar(s: str, c: str, expected: List[int]):
    result = Solution().shortestToChar(s, c)
    assert(result == expected)    

if __name__ == "__main__":
    pytest.main([__file__]) 