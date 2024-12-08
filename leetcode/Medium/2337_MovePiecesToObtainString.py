import pytest
from pathlib import Path

class Solution:
    def canChange(self, start: str, target: str) -> bool:
        si = 0
        ti = 0

        start_len = len(start)
        target_len = len(target)
        if start_len != target_len: 
            return False

        while si < start_len or ti < target_len: 

            while si < start_len and start[si] == '_': 
                si += 1

            while ti < target_len and target[ti] == '_': 
                ti += 1

            if ti == target_len or si == start_len: 
                return ti == si 

            if start[si] == 'L': 
                if target[ti] == 'R': 
                    return False
                # L can only move left in start
                if si < ti: 
                    return False
            else: 
                if target[ti] == 'L': 
                    return False
                # R can only move right in start
                if si > ti: 
                    return False
            si += 1
            ti += 1

        return True

def test_biginput(): 
    data_path = Path(__file__).parent.parent / "Data"
    file_name = "2337_BigTest.txt"    
    path = data_path / file_name
    with open(path, "r") as file: 
        start = file.readline()
        target = file.readline()
    sol = Solution()
    expected = False
    result = sol.canChange(start, target)
    assert(result == expected)



@pytest.mark.parametrize("start, target, expected", [
    ("_L__R__R_", "L______RR", True), 
    ("R_L_", "__LR", False), 
    ("_R", "R_", False), 
    ("_RL", "LR_", False)
])
def test(start: str, target: str, expected: bool): 
    sol = Solution()
    result = sol.canChange(start, target)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])