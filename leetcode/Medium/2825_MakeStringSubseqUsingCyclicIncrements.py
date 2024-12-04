import pytest

class Solution:
    

    def canMakeSubsequence(self, str1: str, str2: str) -> bool:
        i1 = 0
        i2 = 0
        matched = 0
        while(i1 < len(str1) and i2 < len(str2) and matched < len(str2)): 
            
            alt = 'a' if str1[i1] == 'z' else chr(ord(str1[i1]) + 1)
            if str1[i1] == str2[i2] or alt == str2[i2]: 
                i2 += 1
                matched += 1
            
            i1 += 1

        return matched == len(str2)

@pytest.mark.parametrize("str1, str2, expected", [
    ("abc", "ad", True), 
    ("zc", "ad", True), 
    ("ab", "d", False)
])
def test(str1 : str, str2: str, expected: bool): 
    sol = Solution()
    result = sol.canMakeSubsequence(str1, str2); 
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])