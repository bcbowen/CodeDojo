import hashlib
import pytest

def main(): 
    pass

def part1(salt: str) -> int: 
    pass

def test_part1(): 
    salt = 'abc'
    expected = 22728
    result = part1(salt)
    assert(expected == result)

if __name__ == "__main__":
    pytest.main([__file__]) 
    main()