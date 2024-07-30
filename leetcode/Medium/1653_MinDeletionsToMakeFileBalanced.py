
import pytest

class Solution(object):
    def minimumDeletions(self, s):
        """
        :type s: str
        :rtype: int
        """

        counts = []
        counts.append([0, s[0], 0])
        for i in range (1, len(s)):
            counts.append([s[i - 1][0] + 1 if s[i - 1][1] == 'b' else s[i - 1][0], s[i], 0])

        for i in range(len(s) - 2, -1, -1): 
            if s[i + 1][1] == 'a': 
                s[i][2] = s[i + 1][2] + 1
            else:
                s[i][2] = s[i + 1][2]
        

        min  = float("inf")
        for i in range(0, len(s)):
            score = counts[i][0] + counts[i][2] 
            if score < min: 
                min = score
        # bs before, c, as after
        return min

"""
You are given a string s consisting only of characters 'a' and 'b'​​​​.
You can delete any number of characters in s to make s balanced. s is balanced if there is no pair of indices (i,j) such that i < j and s[i] = 'b' and s[j]= 'a'.
Return the minimum number of deletions needed to make s balanced.
 

Example 1:
Input: s = "aababbab"
Output: 2
Explanation: You can either:
Delete the characters at 0-indexed positions 2 and 6 ("aababbab" -> "aaabbb"), or
Delete the characters at 0-indexed positions 3 and 6 ("aababbab" -> "aabbbb").

Example 2:
Input: s = "bbaaaaabb"
Output: 2
Explanation: The only solution is to delete the first two characters.
"""


@pytest.mark.parametrize("value, expected", [
    ("aababbab", 2),
    ("bbaaaaabb", 2),
])
def test_number_of_pairs(value, expected):
    result = Solution().sortPeople(minimumDeletions, heights)
    print(f"hey dude {minimumDeletions} --> {result} [{expected}] ")
    assert result == expected

if __name__ == "__main__":
    pytest.main([__file__])