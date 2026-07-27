import pytest

from collections import Counter

class Solution:
    def getLeastFrequentDigit(self, n: int) -> int:
        letterCounts = Counter(str(n))
        ordered = list(sorted(letterCounts.items(), key=lambda item: (item[1], item[0])))
        return int(ordered[0][0])     

"""
Example 1:
Input: n = 1553322
Output: 1
Explanation:
The least frequent digit in n is 1, which appears only once. All other digits appear twice.

Example 2:
Input: n = 723344511
Output: 2
Explanation:

The least frequent digits in n are 7, 2, and 5; each appears only once.
"""
@pytest.mark.parametrize("n, expected", [
    (1553322, 1), 
    (723344511, 2)
])
def test_getLeastFrequentDigit(n: int, expected: int):
    result = Solution().getLeastFrequentDigit(n)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])          