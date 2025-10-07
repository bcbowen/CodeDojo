import pytest
from typing import List, Tuple


class Solution:
    """
        Binary Watch Bits - 10 bits
        H1, H2, H4, H4, M1, M2, M4, M8, M16, M32
    """
    def readBinaryWatch(self, turnedOn: int) -> List[str]:
        
        def backtrack(bits : List[int]): 
            set_count = bits.count(1)
            if set_count == turnedOn: 
                if Solution.is_valid(bits): 
                    time_string = Solution.get_time_string(bits)
                    if time_string not in result: 
                        result.append(time_string)
                return
            
            if len(bits) < 10: 
                new_bits = bits.copy()
                new_bits.append(0)
                backtrack(new_bits)

                new_bits = bits.copy()
                new_bits.append(1)
                backtrack(new_bits)


        result = [] 
        backtrack([])
        result.sort()
        return result
    
    # position 1 - 4 are hours, 5 - 10 are minutes
    @staticmethod
    def get_time_components(bits: List[int]) -> Tuple[int, int]:
            hour = 0
            minute = 0
            # hour is in first 4 bits
            accumulator = 1
            for i in range(min(len(bits), 4)): 
                if bits[i] == 1: 
                    hour += accumulator
                accumulator <<= 1

            # minute is last 6 bits
            accumulator = 1
            if len(bits) > 4: 
                for i in range(4,min(len(bits), 10)): 
                    if bits[i] == 1: 
                        minute += accumulator
                    accumulator <<= 1
            return (hour, minute)


    @staticmethod
    def get_time_string(bits: List[int]) -> str:         
        hour, minute = Solution.get_time_components(bits)            
        return f"{str(hour)}:{str(minute).zfill(2)}" 
    
    @staticmethod
    def is_valid(bits: List[int]) -> bool:
        hour, minute = Solution.get_time_components(bits) 
        return hour < 12 and minute < 60 
"""
Example 1:
Input: turnedOn = 1
Output: ["0:01","0:02","0:04","0:08","0:16","0:32","1:00","2:00","4:00","8:00"]

Example 2:
Input: turnedOn = 9
Output: []

Binary Watch Bits - 10 bits
H1, H2, H4, H4, M1, M2, M4, M8, M16, M32

"""
@pytest.mark.parametrize("turnedOn, expected", [
    (1, ["0:01","0:02","0:04","0:08","0:16","0:32","1:00","2:00","4:00","8:00"]), 
    (9, []), 
    (2, ["0:03","0:05","0:06","0:09","0:10","0:12","0:17","0:18","0:20","0:24","0:33","0:34","0:36","0:40","0:48","1:01","1:02","1:04","1:08","1:16","1:32","2:01","2:02","2:04","2:08","2:16","2:32","3:00","4:01","4:02","4:04","4:08","4:16","4:32","5:00","6:00","8:01","8:02","8:04","8:08","8:16","8:32","9:00","10:00"])
])
def test_readBinaryWatch(turnedOn: int, expected:  List[str]):
    result = list(set(Solution().readBinaryWatch(turnedOn)))
    result.sort()
    expected.sort()
    assert(len(result) == len(expected))
    for val in expected: 
        assert(val in result)

"""
    [1,0,0,0,0,0,0,0,0,0]: "1:00"
    [0,1,0,0,0,0,0,0,0,0]: "2:00"
    [0,0,1,0,0,0,0,0,0,0]: "4:00"
    [0,0,0,1,0,0,0,0,0,0]: "8:00"
    [1,1,0,0,0,0,0,0,0,0]: "3:00"
    [1,0,1,0,0,0,0,0,0,0]: "5:00"
    [0,0,0,0,1,0,0,0,0,0]: "0:01"
    [0,0,0,0,0,0,0,0,0,0]: "0:00"
    [0,0,0,0,0,1,0,0,0,0]: "0:02"
    [0,0,0,0,0,0,1,0,0,0]: "0:04"
    [0,0,0,0,0,0,0,1,0,0]: "0:08"
    [0,0,0,0,0,0,0,0,1,0]: "0:16"
    [0,0,0,0,0,0,0,0,0,1]: "0:32"
    [0,0,0,8,1,0,0,0,0,1]: "8:33"
    [0,1,0,0,0,1,0,1,0,0]: "2:10"
    [1,0,0,1,0,0,1,0,0,1]: "9:36"
"""    
@pytest.mark.parametrize("bits, expected", [
    ([1,0,0,0,0,0,0,0,0,0], "1:00"), 
    ([0,1,0,0,0,0,0,0,0,0], "2:00"), 
    ([0,0,1,0,0,0,0,0,0,0], "4:00"), 
    ([0,0,0,1,0,0,0,0,0,0], "8:00"),
    ([1,1,0,0,0,0,0,0,0,0], "3:00"),
    ([1,0,1,0,0,0,0,0,0,0], "5:00"),
    ([0,0,0,0,1,0,0,0,0,0], "0:01"),
    ([0,0,0,0,0,0,0,0,0,0], "0:00"),
    ([0,0,0,0,0,1,0,0,0,0], "0:02"),
    ([0,0,0,0,0,0,1,0,0,0], "0:04"),
    ([0,0,0,0,0,0,0,1,0,0], "0:08"),
    ([0,0,0,0,0,0,0,0,1,0], "0:16"),
    ([0,0,0,0,0,0,0,0,0,1], "0:32"),
    ([0,0,0,1,1,0,0,0,0,1], "8:33"),
    ([0,1,0,0,0,1,0,1,0,0], "2:10"),
    ([1,0,0,1,0,0,1,0,0,1], "9:36") 
])
def test_get_time_string(bits: List[int], expected: str): 
    result = Solution.get_time_string(bits)
    assert(result == expected)

@pytest.mark.parametrize("bits, expected", [
    ([1,0,0,0,0,0,0,0,0,0], True), # "1:00")  
    ([0,1,0,0,0,0,0,0,0,0], True), # "2:00" 
    ([0,0,1,0,0,0,0,0,0,0], True), # "4:00"
    ([0,0,0,1,0,0,0,0,0,0], True), # "8:00"
    ([1,1,0,0,0,0,0,0,0,0], True), # "3:00"
    ([1,0,1,0,0,0,0,0,0,0], True), # "5:00"
    ([0,0,1,1,0,0,0,0,0,0], False), # "12:00"
    ([0,0,0,0,1,0,0,0,0,0], True), # "0:01"
    ([0,0,0,0,0,0,0,0,0,0], True), # "0:00"
    ([0,0,0,0,0,1,0,0,0,0], True), # "0:02"
    ([0,0,0,0,0,0,1,0,0,0], True), # "0:04"
    ([0,0,0,0,0,0,0,1,0,0], True), # "0:08"
    ([0,0,0,0,0,0,0,0,1,0], True), # "0:16"
    ([0,0,0,0,0,0,0,0,0,1], True), # "0:32"
    ([0,0,0,1,1,0,0,0,0,1], True), # "8:33"
    ([0,1,0,0,0,1,0,1,0,0], True), # "2:10"
    ([1,0,0,1,0,0,1,0,0,1], True), # "9:36"
    ([1,0,1,1,0,0,1,0,0,1], False), # 13:36 
    ([1,1,1,1,0,0,1,0,0,1], False), # 15:36
    ([1,0,0,1,0,0,1,1,1,1], False), # "9:60" 
    ([1,0,0,1,1,1,1,1,1,1], False), # "9:63"

    # bits might have less than 10, evaluate the ones that are there
    ([1], True), # "1:00")  
    ([0,1], True), # "2:00" 
    ([0,0,1], True), # "4:00"
    ([0,0,0,1], True), # "8:00"
    ([1,1], True), # "3:00"
    ([1,0,1], True), # "5:00"
    ([0,0,1,1], False), # "12:00"
    ([0,0,0,0,1], True), # "0:01" 
])
def test_is_valid(bits: List[int], expected: bool): 
    result = Solution.is_valid(bits)
    assert(result == expected)

@pytest.mark.parametrize("bits, expected_hour, expected_minutes", [
    ([1,0,0,0,0,0,0,0,0,0], 1, 0), 
    ([0,1,0,0,0,0,0,0,0,0], 2, 0), 
    ([0,0,1,0,0,0,0,0,0,0], 4, 0), 
    ([0,0,0,1,0,0,0,0,0,0], 8, 0),
    ([1,1,0,0,0,0,0,0,0,0], 3, 0),
    ([1,0,1,0,0,0,0,0,0,0], 5, 0),
    ([0,0,0,0,1,0,0,0,0,0], 0, 1),
    ([0,0,0,0,0,0,0,0,0,0], 0, 0),
    ([0,0,0,0,0,1,0,0,0,0], 0, 2),
    ([0,0,0,0,0,0,1,0,0,0], 0, 4),
    ([0,0,0,0,0,0,0,1,0,0], 0, 8),
    ([0,0,0,0,0,0,0,0,1,0], 0, 16),
    ([0,0,0,0,0,0,0,0,0,1], 0, 32),
    ([0,0,0,1,1,0,0,0,0,1], 8, 33),
    ([0,1,0,0,0,1,0,1,0,0], 2, 10),
    ([1,0,0,1,0,0,1,0,0,1], 9, 36) 
])
def test_get_time_components(bits: List[int], expected_hour: int, expected_minutes: int): 
    hour, minutes = Solution.get_time_components(bits)
    assert(hour == expected_hour)
    assert(minutes == expected_minutes) 

if __name__ == "__main__":
    pytest.main([__file__]) 