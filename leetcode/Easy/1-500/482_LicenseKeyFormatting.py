import pytest


class Solution:
    def licenseKeyFormatting(self, s: str, k: int) -> str:
        sections = [] 
        section = []
        s = s.upper()
        for i in range(len(s) - 1, -1, -1): 
            if s[i].isalnum():
                section.insert(0, s[i])
                if len(section) == k: 
                    sections.insert(0, "".join(section))
                    section.clear()
        if len(section) > 0: 
            sections.insert(0, "".join(section))

        return "-".join(sections)

"""
Example 1:

Input: s = "5F3Z-2e-9-w", k = 4
Output: "5F3Z-2E9W"
Explanation: The string s has been split into two parts, each part has 4 characters.
Note that the two extra dashes are not needed and can be removed.
Example 2:

Input: s = "2-5g-3-J", k = 2
Output: "2-5G-3J"
Explanation: The string s has been split into three parts, each part has 2 characters except the first part as it could be shorter as mentioned above.
"""
@pytest.mark.parametrize("s, k, expected", [
    ("5F3Z-2e-9-w", 4, "5F3Z-2E9W"), 
    ("2-5g-3-J", 2, "2-5G-3J")
])
def test_licenseKeyFormatting(s: str, k: int, expected: str):
    result = Solution().licenseKeyFormatting(s, k)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])