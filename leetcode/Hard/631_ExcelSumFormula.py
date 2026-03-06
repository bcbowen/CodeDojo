import pytest 

from typing import List

class Excel:

    def __init__(self, height: int, width: str):
        self._sheet = [[0 for col in range(Excel.get_col(width))] for row in range(height)]

    def set(self, row: int, column: str, val: int) -> None:
        pass

    def get(self, row: int, column: str) -> int:
        return 3

    def sum(self, row: int, column: str, numbers: List[str]) -> int:
        return 3

    @staticmethod    
    def get_col(col: str) -> int: 
        if len(col) != 1: 
            raise Exception(f'Invalid value for column: "{col}"')
        return ord(col.upper()) - 64

# Your Excel object will be instantiated and called as such:
# obj = Excel(height, width)
# obj.set(row,column,val)
# param_2 = obj.get(row,column)
# param_3 = obj.sum(row,column,numbers)

@pytest.mark.parametrize("col, expected", [
    ("A", 1),
    ("a", 1), 
    ("Z", 26) 
])
def test_get_col(col: str, expected: int): 
    result = Excel.get_col(col)
    assert(result == expected)

def test_init(): 
    e = Excel(2, 'C')
    assert(len(e._sheet) == 2)
    assert(len(e._sheet[0]) == 3)
    assert(e._sheet[0][0] == 0)

if __name__ == "__main__":
    pytest.main([__file__]) 