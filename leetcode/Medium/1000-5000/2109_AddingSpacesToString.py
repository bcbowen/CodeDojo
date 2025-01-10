import pytest

class Solution:
    def addSpaces(self, s: str, spaces: list[int]) -> str:
        
        j = 0
        output = ""
        for i in range(len(s)): 
            if spaces[j] == i: 
                output += " "
                j += 1
            output += s[i]
            if j == len(spaces): 
                output += s[i + 1:]
                break
        return output

@pytest.mark.parametrize("s, spaces, expected", [
    ("LeetcodeHelpsMeLearn", [8,13,15], "Leetcode Helps Me Learn"), 
    ("icodeinpython", [1,5,7,9], "i code in py thon"), 
    ("spacing", [0,1,2,3,4,5,6], " s p a c i n g")
])
def test_add_spaces(s: str, spaces: list[int], expected: str): 
    spacer = Solution()
    result = spacer.addSpaces(s, spaces)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])