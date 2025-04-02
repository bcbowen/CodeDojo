import pytest
from typing import List

class Solution:
    def maximumUnits(self, boxTypes: List[List[int]], truckSize: int) -> int:
        boxTypes.sort(key=lambda x: x[1], reverse=True)
        units = 0
        for box_count, unit_count in boxTypes:
            if truckSize > box_count: 
                units += box_count * unit_count
                truckSize -= box_count
            else: 
                units += truckSize * unit_count
                truckSize = 0
            if truckSize == 0: 
                break
        return units
"""
Example 1:
Input: boxTypes = [[1,3],[2,2],[3,1]], truckSize = 4
Output: 8
Explanation: There are:
- 1 box of the first type that contains 3 units.
- 2 boxes of the second type that contain 2 units each.
- 3 boxes of the third type that contain 1 unit each.
You can take all the boxes of the first and second types, and one box of the third type.
The total number of units will be = (1 * 3) + (2 * 2) + (1 * 1) = 8.

Example 2:
Input: boxTypes = [[5,10],[2,5],[4,7],[3,9]], truckSize = 10
Output: 91
"""
@pytest.mark.parametrize("boxTypes, truckSize, expected", [
    ([[1,3],[2,2],[3,1]], 4, 8), 
    ([[5,10],[2,5],[4,7],[3,9]], 10, 91)
])
def test_maximumUnits(boxTypes: List[List[int]], truckSize: int, expected: int):
    result = Solution().maximumUnits(boxTypes, truckSize)
    assert(result == expected)
    

if __name__ == "__main__":
    pytest.main([__file__]) 