import pytest

class Solution:
    def rotateString(self, s: str, goal: str) -> bool:
        if len(s) != len(goal): 
            return False
        if s == goal: 
            return True
        
        start_points = [] 
        for i in range(len(goal)):
            if goal[i] == s[0]: 
                start_points.append(i)
        while len(start_points) > 0: 
            i = 0
            j = start_points.pop()

            while i < len(s): 
                if s[i] != goal[j]: 
                    break
                i += 1
                j = j + 1 if j < len(goal) - 1 else 0
            else: 
                return True
        return False
    
"""
Example 1:
Input: s = "abcde", goal = "cdeab"
Output: true

Example 2:
Input: s = "abcde", goal = "abced"
Output: false
"""
@pytest.mark.parametrize("s, goal, expected", [
    ("abcde", "cdeab", True), 
    ("abcde", "abced", False)
])
def test_rotateString(s: str, goal: str, expected: bool):
        result = Solution().rotateString(s, goal)
        assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 