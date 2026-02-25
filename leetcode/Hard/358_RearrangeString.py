import heapq
import pytest

from collections import Counter

class Solution:
    def rearrangeString(self, s: str, k: int) -> str:
        counts = Counter(s)
        result = ""
        heap = [] 
        for letter, count in counts.items(): 
            heapq.heappush(heap, (-count, 0, letter))

        while len(heap) > 0: 
            not_ready = [] 
            count, min_index, letter = heapq.heappop(heap)
            while len(heap) > 0 and min_index > len(result): 
                not_ready.append((count, min_index, letter))
                count, min_index, letter = heapq.heappop(heap)

            if min_index > len(result): 
                result = ""
                break
            
            result += letter
            new_index = min_index + k 
            count += 1
            if count < 0: 
                heapq.heappush(heap, (count, new_index, letter))

            while len(not_ready) > 0: 
                heapq.heappush(heap, not_ready.pop())

        return result

"""
Example 1:
Input: s = "aabbcc", k = 3
Output: "abcabc"
Explanation: The same letters are at least a distance of 3 from each other.

Example 2:
Input: s = "aaabc", k = 3
Output: ""
Explanation: It is not possible to rearrange the string.

Example 3:
Input: s = "aaadbbcc", k = 2
Output: "abacabcd"
Explanation: The same letters are at least a distance of 2 from each other.

TC 58
s = "aaabc"
k = 2
"abaca"

"""
@pytest.mark.parametrize("s, k, expected", [
    ("aabbcc", 3, "abcabc"), 
    ("aaabc", 3, ""), 
    ("aaadbbcc", 2, "abacabcd"), 
    ("aaabc", 2, "abaca")
])
def test_rearrangeString(s: str, k: int, expected: str): 
    result = Solution().rearrangeString(s, k)
    if result == "": 
        assert(expected == "") 
    
    else: 
        assert(is_valid_solution(result, k))

@pytest.mark.parametrize("s, k, expected", [
    ("abcabc", 3, True), 
    ("abacabcd", 2, True), 
    ("abaca", 2, True),
    ("abcbac", 3, False), 
    ("abaacbcd", 2, False), 
    ("abaac", 2, False)
])
def test_is_valid_solution(s: str, k: int, expected: bool): 
    result = is_valid_solution(s, k)
    assert(result == expected)

def is_valid_solution(s: str, k: int) -> bool: 
    for i in range(len(s) - k): 
        c = s[i]
        next = s[i + 1: i + k]
        if c in next: 
            return False 
    return True

if __name__ == "__main__":
    pytest.main([__file__]) 