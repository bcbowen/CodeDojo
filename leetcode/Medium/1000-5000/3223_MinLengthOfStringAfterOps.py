import pytest



"""

Example 1:
Input: s = "abaacbcbb"
Output: 5

Explanation:
We do the following operations:

Choose index 2, then remove the characters at indices 0 and 3. The resulting string is s = "bacbcbb".
Choose index 3, then remove the characters at indices 0 and 5. The resulting string is s = "acbcb".

Example 2:
Input: s = "aa"

Output: 2
Explanation:
We cannot perform any operations, so we return the length of the original string.
 

Constraints:

1 <= s.length <= 2 * 105
s consists only of lowercase English letters.

"""

class Solution:
    def minimumLength(self, s: str) -> int:
        if len(s) < 3: 
            return len(s)
        
        index = {}
        for i, c in enumerate(s): 
            if not c in index: 
                index[c] = [] 
            index[c].append(i)
        minLen = 0
        for key in index.keys(): 
            char_count = len(index[key])
            while char_count > 2: 
                char_count = char_count // 3 + char_count % 3
            minLen += char_count
        
        return minLen

@pytest.mark.parametrize("val, expected", [
    ("ucvbutgkohgbcobqeyqwppbxqoynxeuuzouyvmydfhrprdbuzwqebwuiejoxsxdhbmuaiscalnteocghnlisxxawxgcjloevrdcj", 38),
    ("abaacbcbb", 5),     
    ("aa", 2), 
])
def test_minLen(val: str, expected: int): 
    solution = Solution()
    result = solution.minimumLength(val)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])