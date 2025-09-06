import pytest

class Solution:
    def similarRGB(self, color: str) -> str:
        r = color[1 : 3]
        g = color[3 : 5]
        b = color[5 : 7]
        return f"#{Solution.get_closest(r)}{Solution.get_closest(g)}{Solution.get_closest(b)}"

    
    @staticmethod
    def get_closest(hex_val: str) -> str: 
        num = int(hex_val, 16)

        x = round(num / 17)

        return hex(x)[-1] * 2

"""
Example 1:
Input: color = "#09f166"
Output: "#11ee66"
Explanation: 
The similarity is -(0x09 - 0x11)2 -(0xf1 - 0xee)2 - (0x66 - 0x66)2 = -64 -9 -0 = -73.
This is the highest among any shorthand color.

Example 2:
Input: color = "#4e3fe1"
Output: "#5544dd"
 
"""
@pytest.mark.parametrize("color, expected", [
    ("#09f166", "#11ee66"),
    ("#4e3fe1", "#5544dd")
])
def test_similarRGB(color: str, expected: str):
    result = Solution().similarRGB(color)
    assert(result == expected)

"""
09 -> 11
f1 -> ee
66 -> 66
4e -> 55
3f -> 44
e1 -> dd
"""
@pytest.mark.parametrize("val, expected", [
    ("09", "11"), 
    ("f1", "ee"), 
    ("66", "66"), 
    ("4e", "55"), 
    ("3f", "44"), 
    ("e1", "dd"), 
])
def test_get_closest(val: str, expected: str): 
    result = Solution.get_closest(val)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 

