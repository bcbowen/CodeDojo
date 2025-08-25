import pytest
import time

class Solution:
    def countBinarySubstrings(self, s: str) -> int:
        groups = []
        current = s[0]
        current_count = 0
        for c in s: 
            if c != current: 
                groups.append((current, current_count))
                current = c
                current_count = 1
            else: 
                current_count += 1
        groups.append((current, current_count))

        substring_count = 0

        for i in range(1, len(groups)): 
            substring_count += min(groups[i][1], groups[i - 1][1])
            
        return substring_count
    
    def countBinarySubstrings_3(self, s: str) -> int:
        substrings = [] 
        stack = [] 
        for i in range(len(s)): 
            start_char = s[i]
            stack.clear()
            stack.append(s[i])
            j = i + 1
            while j < len(s) and s[j] == start_char: 
                stack.append(s[j])
                j += 1
            
            while j < len(s) and s[j] != start_char:
                if len(stack) > 0: 
                    stack.pop()
                    j += 1
                    if len(stack) == 0: 
                        substrings.append(s[i:j])
                        break 


        return len(substrings)
    
    def countBinarySubstrings_2(self, s: str) -> int:
        turn = 1
        i = 0
        j = 1
        count1 = 1
        count2 = 0
        current_char = s[0]
        substrings = []
        while i < len(s): 
            while j < len(s) and s[j] == current_char: 
                count1 += 1
                j += 1
            
            current_char = s[j]
            while j < len(s) and s[j] == current_char: 
                count2 += 1
                if count1 == count2: 
                    substrings.append(s[i:j + 1])
            i += 1

            count1 = 1
            current_char = s[i]
            j = i + 1
            if count1 == count2: 
                substrings.append(s[i - 1: i + 1])

        return len(substrings) 

    
    # Note: need to stop as soon as we have seen both 0s and 1s and 
    # increment i and start over
    def countBinarySubstrings_1(self, s: str) -> int:
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

TC 24: 
s: 00110 expected: 3
"""
@pytest.mark.parametrize("s, expected", [
    ("00110011", 6), 
    ("10101", 4), 
    ("00110", 3), 
    ("01", 1), 
    ("0000000001", 1),
    ("1000000000", 1)
])
def test_countBinarySubstrings(s: str, expected: int):
    result = Solution().countBinarySubstrings(s);
    assert(result == expected)

"""
1: 2207
0: 22665
1: 20459
0: 671
1: 671
0: 1562
1: 1562
0: 1
1: 74
0: 73
1: 14
0: 19
1: 5
0: 1
1: 4
0: 3
1: 3
0: 4
1: 1

"""

# initial tle: 65 seconds
def test_tc87(): 
    s = f"{'1' * 2207}{'0' * 22665}{'1' * 20459}{'0' * 671}{'1' * 671}{'0' * 1562}{'1' * 1562}0{'1' * 74}{'0' * 73}{'1' * 14}{'0' * 19}{'1' * 5}0{'1' * 4}{'0' * 3}{'1' * 3}{'0' * 4}1"
    expected = 26361
    begin_time = time.perf_counter()
    result = Solution().countBinarySubstrings(s)

    end_time = time.perf_counter()
    assert(result == expected)
    elapsed_time = end_time - begin_time
    print(f"Elapsed time: {elapsed_time:.6f} seconds")


if __name__ == "__main__": 
    pytest.main([__file__])