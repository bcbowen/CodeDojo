import pytest
from pathlib import Path

class Solution:
    def canChange(self, start: str, target: str) -> bool:
        
        if start == target: 
            return True
        if start.replace('_', '') != target.replace('_', ''): 
            return False
        
        s_list = list(start)
        t_list = list(target)

        for i in range(len(t_list)): 
            if t_list[i] == s_list[i]: 
                continue

            if t_list[i] == 'L': 
                if s_list[i] == 'R': 
                    return False
                else: 
                    for j in range(i + 1, len(s_list)): 
                        if s_list[j] == 'R': 
                            return False
                        elif s_list[j] == 'L': 
                            s_list[i], s_list[j] = s_list[j], s_list[i]
                            break
            elif t_list[i] == 'R': 
                return False
            else:
                if s_list[i] == 'L': 
                    return False
                else: 
                    for j in range(i + 1, len(s_list)): 
                        if s_list[j] == 'L': 
                            return False
                        elif s_list[j] == '_': 
                            s_list[i], s_list[j] = s_list[j], s_list[i]
                            break
        return True



def get_input_filepath(file_name: str):
    data_path = Path(__file__).parent.parent / "Data"
    return data_path / file_name



def test_biginput(): 
    file_name = "2337_BigTest.txt"    

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