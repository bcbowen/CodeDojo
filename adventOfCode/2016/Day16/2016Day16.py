import pytest

def get_next_dragon_curve_value(val: str) -> str: 
    inverse = val[::-1].replace('0', 'x').replace('1', '0').replace('x', '1')
    return val + '0' + inverse

def get_checksum(val) -> str: 
    result = ""
    for i in range(1, len(val), 2): 
        if val[i] == val[i - 1]: 
            result += '1'
        else: 
            result += '0'
        
    if len(result) % 2 == 1: 
        return result
    else: 
        return get_checksum(result)

def part1(val: str, disk_size: int) -> str:
    while len(val) < disk_size: 
        val = get_next_dragon_curve_value(val)

    val = val[0:disk_size]
    return get_checksum(val)
    

def main(): 
    val = "01111001100111011"
    disk_size = 272
    result = part1(val, disk_size)
    print(f"Part1: {result}")
    #part 2
    disk_size = 35651584
    result = part1(val, disk_size)
    print(f"Part2: {result}")

"""
1 becomes 100.
0 becomes 001.
11111 becomes 11111000000.
111100001010 becomes 1111000010100101011110000.
"""
@pytest.mark.parametrize("val, expected", [
    ("1", "100"), 
    ("0", "001"), 
    ("11111", "11111000000"), 
    ("111100001010", "1111000010100101011110000")
])
def test_get_next_dragon_curve_value(val: str, expected: str):
    result = get_next_dragon_curve_value(val)
    assert(result == expected)

"""
110010110100 -> 100
10000011110010000111 -> 01100
"""
@pytest.mark.parametrize("val, expected", [
    ("110010110100", "100"),
    ("10000011110010000111", "01100") 
])
def test_get_checksum(val: str, expected: str): 
    result = get_checksum(val)
    assert(result == expected)

def test_part1(): 
    val = "10000"
    disk_size = 20
    expected = "01100"
    result = part1(val, disk_size)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__])
    main()