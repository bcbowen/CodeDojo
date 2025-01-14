import pytest

"""
Example 1:
Input: A = [1,3,2,4], B = [3,1,2,4]
Output: [0,2,3,4]
Explanation: At i = 0: no number is common, so C[0] = 0.
At i = 1: 1 and 3 are common in A and B, so C[1] = 2.
At i = 2: 1, 2, and 3 are common in A and B, so C[2] = 3.
At i = 3: 1, 2, 3, and 4 are common in A and B, so C[3] = 4.

Example 2:
Input: A = [2,3,1], B = [3,1,2]
Output: [0,1,3]
Explanation: At i = 0: no number is common, so C[0] = 0.
At i = 1: only 3 is common in A and B, so C[1] = 1.
At i = 2: 1, 2, and 3 are common in A and B, so C[2] = 3.
"""
class Solution:
    def findThePrefixCommonArray(self, A: list[int], B: list[int]) -> list[int]:
        counts = [0] * (len(A) + 1)
        result = [0] * len(A)
        running_count = 0
        for i in range(len(A)): 
            counts[A[i]] += 1
            if counts[A[i]] == 2: 
                running_count += 1
            counts[B[i]] += 1
            if counts[B[i]] == 2: 
                running_count += 1
            result[i] = running_count
        return result


@pytest.mark.parametrize("list1, list2, expected", [
    ([1,3,2,4],[3,1,2,4],[0,2,3,4]),
    ([2,3,1],[3,1,2],[0,1,3]),
])
def test_findThePrefixCommonArray(list1 : list[int], list2 : list[int], expected: list[int]): 
    solution = Solution()
    result = solution.findThePrefixCommonArray(list1, list2)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__])