import pytest

class Solution:
    def compareVersion(self, version1: str, version2: str) -> int:
        if version1 == version2: 
            return 0
        
        parts1 = version1.split('.')
        parts2 = version2.split('.')

        i = 0
        while i < len(parts1) or i < len(parts2): 
            val1 = 0 if i >= len(parts1) else int(parts1[i])
            val2 = 0 if i >= len(parts2) else int(parts2[i])
            if val1 < val2: 
                return -1
            elif val1 > val2: 
                return 1
            i += 1
        return 0


"""
Example 1:
Input: version1 = "1.2", version2 = "1.10"
Output: -1
Explanation:
version1's second revision is "2" and version2's second revision is "10": 2 < 10, so version1 < version2.

Example 2:
Input: version1 = "1.01", version2 = "1.001"
Output: 0
Explanation:
Ignoring leading zeroes, both "01" and "001" represent the same integer "1".

Example 3:
Input: version1 = "1.0", version2 = "1.0.0.0"
Output: 0
Explanation:
version1 has less revisions, which means every missing revision are treated as "0".
"""
@pytest.mark.parametrize("version1, version2, expected", [
    ("1.2", "1.10", -1),
    ("1.01", "1.001", 0),
    ("1.0", "1.0.0.0", 0), 
    ("1.0", "1.0.0.1", -1),
    ("1.0.1", "1.0.0.0.0.0.1", 1)
])
def test_compareVersion(version1: str, version2: str, expected: int):
    result = Solution().compareVersion(version1, version2)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 