import pytest
from typing import List
from collections import defaultdict

class Solution:
    def minSetSize(self, arr: List[int]) -> int:
        remaining = len(arr)
        limit = len(arr) / 2
        steps = 0
        counts = defaultdict(int)
        for i in arr: 
            counts[i] += 1

        sorted_items = sorted(counts.items(), key=lambda item: item[1], reverse=True)

        for key, value in sorted_items: 
            remaining -= value
            steps += 1
            if remaining <= limit:
                break

        """
        my_dict = {'a': 10, 'b': 5, 'c': 15, 'd': 5}

        # Sort the dictionary items by value
        sorted_items = sorted(my_dict.items(), key=lambda item: item[1])

        # Iterate through the sorted items
        for key, value in sorted_items:
            print(key, value)
        """
        return steps

"""
Example 1:
Input: arr = [3,3,3,3,5,5,5,2,2,7]
Output: 2
Explanation: Choosing {3,7} will make the new array [5,5,5,2,2] which has size 5 (i.e equal to half of the size of the old array).
Possible sets of size 2 are {3,5},{3,2},{5,2}.
Choosing set {2,7} is not possible as it will make the new array [3,3,3,3,5,5,5] which has a size greater than half of the size of the old array.

Example 2:
Input: arr = [7,7,7,7,7,7]
Output: 1
Explanation: The only possible set you can choose is {7}. This will make the new array empty.
"""
@pytest.mark.parametrize("arr, expected", [
    ([1000, 1000, 3, 7], 1),
    ([3,3,3,3,5,5,5,2,2,7], 2), 
    ([7,7,7,7,7,7], 1)
])
def test_minSetSize(arr: List[int], expected: int):
    result = Solution().minSetSize(arr)
    assert(result == expected)    

if __name__ == "__main__": 
    pytest.main([__file__])