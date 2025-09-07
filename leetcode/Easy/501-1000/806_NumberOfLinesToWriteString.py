import pytest
from typing import List


class Solution:
    def numberOfLines(self, widths: List[int], s: str) -> List[int]:
        
        current_line_total = 0
        line_count = 1
        a = 97
        for c in s: 
            index = ord(c) - a
            c_width = widths[index]
            if current_line_total + c_width > 100: 
                line_count += 1
                current_line_total = c_width
            else: 
                current_line_total += c_width


        return [line_count, current_line_total]

"""

Example 1:
Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
Output: [3,60]
Explanation: You can write s as follows:
abcdefghij  // 100 pixels wide
klmnopqrst  // 100 pixels wide
uvwxyz      // 60 pixels wide
There are a total of 3 lines, and the last line is 60 pixels wide.

Example 2:
Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "bbbcccdddaaa"
Output: [2,4]
Explanation: You can write s as follows:
bbbcccdddaa  // 98 pixels wide
a            // 4 pixels wide
There are a total of 2 lines, and the last line is 4 pixels wide.

"""
@pytest.mark.parametrize("widths, s, expected", [
    ([10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], "abcdefghijklmnopqrstuvwxyz", [3,60]), 
    ([4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], "bbbcccdddaaa", [2, 4])
])
def test_numberOfLines(widths: List[int], s: str, expected: List[int]):
    result = Solution().numberOfLines(widths, s)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 