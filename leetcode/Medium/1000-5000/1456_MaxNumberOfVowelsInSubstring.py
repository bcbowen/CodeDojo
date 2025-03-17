import pytest

class Solution:
    def maxVowels(self, s: str, k: int) -> int:
        left = 0
        right = 0
        max_count = 0
        count = 0
        vowels = "aeiou"
        if s[0] in vowels: 
            count = 1
        while right - left + 1 < k: 
            right += 1
            if s[right] in vowels: 
                count += 1
        max_count = count

        while right < len(s) - 1: 
            if s[left] in vowels: 
                count -= 1
            left += 1
            right += 1
            if s[right] in vowels: 
                count += 1

            max_count = max(count, max_count)

        return max_count
"""
Example 1:
Input: s = "abciiidef", k = 3
Output: 3
Explanation: The substring "iii" contains 3 vowel letters.

Example 2:
Input: s = "aeiou", k = 2
Output: 2
Explanation: Any substring of length 2 contains 2 vowels.

Example 3:
Input: s = "leetcode", k = 3
Output: 2
Explanation: "lee", "eet" and "ode" contain 2 vowels.
"""
@pytest.mark.parametrize("val, k, expected", [
    ("abciiidef", 3, 3),
    ("aeiou", 2, 2),
    ("leetcode", 3, 2)
])
def test_maxVowels(val: str, k: int, expected: int):
    result = Solution().maxVowels(val, k)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])

