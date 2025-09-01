import pytest
from typing import List

class Solution:
    def is_self_dividing(self, value: int) -> bool: 
        digits = [int(c) for c in str(value)]
        if 0 in digits: 
            return False
        for d in digits: 
            if value % d != 0: 
                return False
        
        return True
    
    def selfDividingNumbers(self, left: int, right: int) -> List[int]:
        result = [] 
        for val in range(left, right + 1): 
            if self.is_self_dividing(val): 
                result.append(val)
        
        return result
    
@pytest.mark.parametrize("value, expected", [
    (1, True), 
    (7, True), 
    (11, True), 
    (12, True), 
    (15, True), 
    (22, True), 
    (48, True), 
    (55, True), 
    (66, True), 
    (77, True), 
    (10, False), 
    (13, False), 
    (21, False), 
    (49, False), 
    (50, False), 
    (68, False), 
    (76, False)
])
def test_is_self_dividing(value: int, expected: bool): 
    result = Solution().is_self_dividing(value)
    assert(result == expected)

"""
Example 1:
Input: left = 1, right = 22
Output: [1,2,3,4,5,6,7,8,9,11,12,15,22]

Example 2:
Input: left = 47, right = 85
Output: [48,55,66,77]
"""
@pytest.mark.parametrize("left, right, expected", [
    (1, 22, [1,2,3,4,5,6,7,8,9,11,12,15,22]), 
    (47, 85, [48,55,66,77])
])
def test_selfDividingNumbers(left: int, right: int, expected: List[int]):
    result = Solution().selfDividingNumbers(left, right)
    assert(result == expected)


if __name__ == "__main__": 
    pytest.main([__file__])