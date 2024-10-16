import pytest

def get_next(nums: list[int]) -> int: 
    matrix = []
    matrix.append([])
    matrix[0] = nums.copy()
    i = 1
    NonZero = False
    while not NonZero: 
        matrix[i - 1].append([])

        NonZero = False 
        for j in range(1, len(matrix[i - 1])): 
            val = matrix[i - 1][j] - matrix[i - 1][j - 1]
            matrix[i].append(val)
            if val != 0: 
                NonZero = True
        if not NonZero: 
            break
        i += 1
    for i in range(len(matrix) - 2,-1,-1): 
        matrix[i - 1].append(matrix[i][-1])
    
    return matrix[0][-1]


def part1(): 
    pass




@pytest.mark.parametrize("nums, expected", [
    ([0, 3, 6, 9, 12, 15], 18),
    ([1, 3, 6, 10, 15, 21], 28),
    ([10, 13, 16, 21, 30, 45], 68)
])
def test_get_next(nums: list[int], expected: int):
    result = get_next(nums)
    assert(expected == result)


if __name__ == "__main__": 
    pytest.main([__file__])
    part1()