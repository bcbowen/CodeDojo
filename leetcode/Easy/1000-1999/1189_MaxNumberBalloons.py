import pytest

class Solution:
    def maxNumberOfBalloons(self, text: str) -> int:
        char_counts = { 'b': 0, 'a': 0, 'l': 0, 'o': 0, 'n': 0 }

        for c in text: 
            if c in char_counts: 
                char_counts[c] += 1

        min_count = float('inf')
        for key in char_counts.keys(): 
            if key in ['l', 'o']: 
                count = char_counts[key] // 2
            else: 
                count = char_counts[key]
            
            min_count = min(min_count, count)

        return min_count if min_count < float('inf') else 0

"""
Example 1:
Input: text = "nlaebolko"
Output: 1

Example 2:
Input: text = "loonbalxballpoon"
Output: 2

Example 3:
Input: text = "leetcode"
Output: 0
"""
@pytest.mark.parametrize("text, expected", [
    ("nlaebolko", 1), 
    ("loonbalxballpoon", 2), 
    ("leetcode", 0)
])
def test_maxNumberOfBalloons(text: str, expected: int):
    sol = Solution()
    result = sol.maxNumberOfBalloons(text)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])