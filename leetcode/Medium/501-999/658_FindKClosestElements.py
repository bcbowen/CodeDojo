import pytest
from typing import List 

class Solution:
    def findClosestElements(self, arr: List[int], k: int, x: int) -> List[int]:
        if len(arr) == k: 
            return arr
        
        if x <= arr[0]: 
            return arr[0:k]
        elif x >= arr[-1]: 
            return arr[-k:]
        
        i = 0
        while arr[i] < x: 
            i += 1

        if arr[i] != x: 
            if x - arr[i - 1] <= arr[i] - x: 
                i -= 1
        result = [arr[i]]
        j = i
        while len(result) < k: 
            if (i == 0): 
                j += 1
                result.append(arr[j])
            elif j == len(arr) - 1: 
                i -= 1
                result.insert(0, arr[i])
            elif x - arr[i - 1] <= arr[j + 1] - x: 
                i -= 1
                result.insert(0, arr[i])
            else:
                j += 1
                result.append(arr[j])

        return result



"""
Example 1:
Input: arr = [1,2,3,4,5], k = 4, x = 3
Output: [1,2,3,4]

Example 2:
Input: arr = [1,1,2,3,4,5], k = 4, x = -1
Output: [1,1,2,3]

3: 
[-2,-1,1,2,3,4,5], k = 7, x = 3

4: 
[0,1,2,2,2,3,6,8,8,9], k = 5, x = 9

5: 
[1,3], k = 1, x = 2, [1]


"""
@pytest.mark.parametrize("arr, k, x, expected", [
    ([1,3], 1, 2, [1]),
    ([1,2,3,4,5], 4, 3, [1,2,3,4]), 
    ([1,1,2,3,4,5], 4, -1, [1,1,2,3]), 
    ([1,2,3,4,5], 2, 6, [4, 5]), 
    ([-2,-1,1,2,3,4,5], 7, 3, [-2,-1,1,2,3,4,5]), 
    ([0,1,2,2,2,3,6,8,8,9], 5, 9, [3,6,8,8,9]), 
    ([0,1,2,2,2,3,6,8,8,9], 5, 8, [3,6,8,8,9])
])
def test_findClosestElements(arr: List[int], k: int, x: int, expected: List[int]):
    result = Solution().findClosestElements(arr, k, x)
    assert(result == expected)

"""
65: [2,4,5,7,8,8,8,8,11,11,13,13,13,13,14,15,16,16,17,18,18,18,18,18,19,20,20,22,22,24,24,26,28,29,31,32,33,36,36,40,40,43,43,43,44,44,45,47,48,51,51,52,55,55,55,55,56,57,58,58,59,59,59,62,63,63,63,65,65,66,67,69,70,71,73,73,73,74,76,76,76,76,79,83,84,85,86,88,88,89,92,93,94,94,95,97,98,98,98,99]
k = 24
x = 77
[63,65,65,66,67,69,70,71,73,73,73,74,76,76,76,76,79,83,84,85,86,88,88,89]

"""
def test_case_65(): 
    arr = [2,4,5,7,8,8,8,8,11,11,13,13,13,13,14,15,16,16,17,18,18,18,18,18,19,20,20,22,22,24,24,26,28,29,31,32,33,36,36,40,40,43,43,43,44,44,45,47,48,51,51,52,55,55,55,55,56,57,58,58,59,59,59,62,63,63,63,65,65,66,67,69,70,71,73,73,73,74,76,76,76,76,79,83,84,85,86,88,88,89,92,93,94,94,95,97,98,98,98,99]
    k = 24
    x = 77
    expected = [63,65,65,66,67,69,70,71,73,73,73,74,76,76,76,76,79,83,84,85,86,88,88,89]
    result = Solution().findClosestElements(arr, k, x)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])