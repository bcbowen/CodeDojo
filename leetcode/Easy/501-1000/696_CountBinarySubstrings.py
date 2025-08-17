import pytest

class Solution:
    # Note: need to stop as soon as we have seen both 0s and 1s and 
    # increment i and start over
    def countBinarySubstrings(self, s: str) -> int:
        i = 0
        j = 1
        substrings = []
        def reset_count(next: str):
            nonlocal ones
            nonlocal zeros
            if next == '0': 
                zeros = 0
            else: 
                ones = 0

        def update_count(next: str, is_increase: bool): 
            nonlocal ones
            nonlocal zeros
            val = 1 if is_increase else -1
            if next == '1': 
                ones += val
            else: 
                zeros += val
         
        ones = 0
        zeros = 0
        last = s[i]
        update_count(last, True)
        
        while i < len(s):
            #j = i + 1 
            while j < len(s) and s[j] == last: 
                update_count(last, True)
                if ones == zeros: 
                    substrings.append(s[i:j + 1])
                j += 1   
            if j == len(s): 
                i += 1
            else: 
                last = s[j]
                reset_count(last)

        return len(substrings)

"""
Example 1:
Input: s = "00110011"
Output: 6
Explanation: There are 6 substrings that have equal number of consecutive 1's and 0's: "0011", "01", "1100", "10", "0011", and "01".
Notice that some of these substrings repeat and are counted the number of times they occur.
Also, "00110011" is not a valid substring because all the 0's (and 1's) are not grouped together.

Example 2:
Input: s = "10101"
Output: 4
Explanation: There are 4 substrings: "10", "01", "10", "01" that have equal number of consecutive 1's and 0's.
"""
@pytest.mark.parametrize("s, expected", [
    ("00110011", 6), 
    ("10101", 4)
])
def test_countBinarySubstrings(s: str, expected: int):
    result = Solution().countBinarySubstrings(s);
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])