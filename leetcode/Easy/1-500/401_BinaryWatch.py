import pytest
from typing import List


class Solution:
    def readBinaryWatch(self, turnedOn: int) -> List[str]:
        
        # position 1 - 4 are hours, 5 - 10 are minutes
        def backtrack(position: int, hour: int, minute: int): 
            hour_bits = bin(hour)
            minute_bits = bin(minute) 
            bit_count = hour_bits.count('1') + minute_bits.count('1')
            if bit_count == turnedOn and is_valid(hour, minute): 
                time = get_time(hour, minute)
                if not time in result: 
                    result.append(time)
                return 
            
            match position: 
                case 0: 
                    backtrack(1, 0, 0)
                    backtrack(1, 1, 0)
                case 1: 
                    backtrack(2, hour, 0)
                    backtrack(2, hour + 2, 0)
                case 2: 
                    backtrack(3, hour, 0)
                    backtrack(3, hour + 4, 0)
                case 3: 
                    backtrack(4, hour, 0)
                    backtrack(4, hour + 8, 0)
                case 4: 
                    backtrack(5, hour, 0)
                    backtrack(5, hour, 1)
                case 5: 
                    backtrack(6, hour, 0)
                    backtrack(6, hour, minute + 2)
                case 6: 
                    backtrack(7, hour, 0)
                    backtrack(7, hour, minute + 4)
                case 7: 
                    backtrack(8, hour, 0)
                    backtrack(8, hour, minute + 8)
                case 8: 
                    backtrack(9, hour, 0)
                    backtrack(9, hour, minute + 16)
                case 9: 
                    backtrack(10, hour, 0)
                    backtrack(10, hour, minute + 32)
                

        def is_valid(hour: int, minute: int) -> bool: 
            return hour < 13 and minute < 60

        def get_time(hour: int, minute: int) -> str:
            return f"{str(hour)}:{str(minute).zfill(2)}" 

        result = [] 
        backtrack(0, 0, 0)
        result.sort()
        return result 
"""
Example 1:
Input: turnedOn = 1
Output: ["0:01","0:02","0:04","0:08","0:16","0:32","1:00","2:00","4:00","8:00"]

Example 2:
Input: turnedOn = 9
Output: []

"""
@pytest.mark.parametrize("turnedOn, expected", [
    (1, ["0:01","0:02","0:04","0:08","0:16","0:32","1:00","2:00","4:00","8:00"]), 
    (9, []), 
    (2, ["0:03","0:05","0:06","0:09","0:10","0:12","0:17","0:18","0:20","0:24","0:33","0:34","0:36","0:40","0:48","1:01","1:02","1:04","1:08","1:16","1:32","2:01","2:02","2:04","2:08","2:16","2:32","3:00","4:01","4:02","4:04","4:08","4:16","4:32","5:00","6:00","8:01","8:02","8:04","8:08","8:16","8:32","9:00","10:00"])
])
def test_readBinaryWatch(turnedOn: int, expected:  List[str]):
    result = set(Solution().readBinaryWatch(turnedOn))
    assert(len(result) == len(expected))
    for val in expected: 
        assert(val in result)
    

if __name__ == "__main__":
    pytest.main([__file__]) 