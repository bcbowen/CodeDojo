import pytest

class CodeGenerator: 
    def __init__(self): 
        self.multiplier = 252533
        self.divisor = 33554393
    
    def calculate(self, row: int, col: int) -> int: 
        currentRow = 1
        currentCol = 1
        maxRow = 1
        maxCol = 1
        currentValue = 20151125
        while currentRow != row or currentCol != col: 
            if currentRow == 1: 
                currentCol = 1
                currentRow = maxRow + 1
                maxRow += 1
                maxCol += 1
            else: 
                currentRow -= 1
                currentCol += 1
            lastValue = currentValue
            currentValue = lastValue * self.multiplier % self.divisor
        return currentValue




"""
So, to find the second code (which ends up in row 2, column 1), 
start with the 
previous value, 20151125. Multiply it by 252533 to get 5088824049625. 
Then, divide 
that by 33554393, which leaves a remainder of 31916031. That remainder
 is the second 
code.

   |    1         2         3         4         5         6
---+---------+---------+---------+---------+---------+---------+
 1 | 20151125  18749137  17289845  30943339  10071777  33511524
 2 | 31916031  21629792  16929656   7726640  15514188   4041754
 3 | 16080970   8057251   1601130   7981243  11661866  16474243
 4 | 24592653  32451966  21345942   9380097  10600672  31527494
 5 |    77061  17552253  28094349   6899651   9250759  31663883
 6 | 33071741   6796745  25397450  24659492   1534922  27995004
"""

def part1(): 
    row = 3010
    col = 3019
    generator = CodeGenerator()

    result = generator.calculate(row, col) 
    print(f"Part 1 result: {result}")
    
def part2(): 
    print(f"Part2 result coming soon")


@pytest.mark.parametrize("row, col, expected", [
    (1, 1, 20151125),
    (2, 1, 31916031),
    (1, 2, 18749137),
    (4, 2, 32451966),
    (5, 5, 9250759)
])
def test_wiz_part1(row: int, col: int, expected: int):
    generator = CodeGenerator()

    result = generator.calculate(row, col) 
    assert result == expected

if __name__ == "__main__": 
    pytest.main([__file__])
    part1()
    part2()