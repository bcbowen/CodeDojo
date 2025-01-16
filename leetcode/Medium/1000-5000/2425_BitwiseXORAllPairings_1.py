import os
import pytest

# initial attempt: Exceeds time limit for huge test case 33

"""
Example 1:
Input: nums1 = [2,1,3], nums2 = [10,2,5,0]
Output: 13
Explanation:
A possible nums3 array is [8,0,7,2,11,3,4,1,9,1,6,3].
The bitwise XOR of all these numbers is 13, so we return 13.

Example 2:
Input: nums1 = [1,2], nums2 = [3,4]
Output: 0
Explanation:
All possible pairs of bitwise XORs are nums1[0] ^ nums2[0], nums1[0] ^ nums2[1], nums1[1] ^ nums2[0],
and nums1[1] ^ nums2[1].
Thus, one possible nums3 array is [2,5,1,6].
2 ^ 5 ^ 1 ^ 6 = 0, so we return 0.
"""

class Solution:
    def xorAllNums(self, nums1: list[int], nums2: list[int]) -> int:
        
        list_generator = Solution.generate_combined_lists(nums1, nums2)
        result = next(list_generator) ^ next(list_generator)
        for val in list_generator: 
            result = val ^ result
            
        return result
    
            
    def generate_combined_lists(nums1: list[int], nums2: list[int]): 
        for n in nums1: 
            for m in nums2: 
                yield n ^ m

    

@pytest.mark.parametrize("nums1, nums2, expected", [
    ([2,1,3], [10,2,5,0], 13), 
    ([1,2], [3,4], 0), 
    ([25,29,3,10,0,15,2], [12], 12)
])
def test_xorAllNums(nums1: list[int], nums2: list[int], expected: int): 
    solution = Solution()
    result = solution.xorAllNums(nums1, nums2)
    assert(result == expected)

def get_path(file_name: str) -> str: 
    # Get the directory of the current script
    script_dir = os.path.dirname(os.path.abspath(__file__))

    # Construct the full path to the file
    path = os.path.join(script_dir, file_name)
    return path

@pytest.mark.parametrize("file_name, expected", [
    ("2425_27.txt", 223648314), 
    ("2425_33.txt", 472009107) 
])
def test_huge_arrays(file_name: str, expected: int): 
    def parse_list(line: str) -> list[int]: 
        return list(map(int, line.strip("[]\n").split(',')))

    path = get_path(file_name)
    with open(path, "r") as file: 
        nums1 = parse_list(file.readline())
        nums2 = parse_list(file.readline())

    solution = Solution() 
    result = solution.xorAllNums(nums1, nums2)
    assert(result == expected)

pytest.main([__file__])