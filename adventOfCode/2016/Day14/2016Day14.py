from functools import lru_cache
import hashlib
import pytest
import re

def main(): 
    salt = "cuanljph"
    result = day14(salt, 1)
    print(f"Part1: {result}")
    result = day14(salt, 2017)
    print(f"Part2: {result}")

@lru_cache(maxsize=1000)
def get_digest(salt: str, val: int, rounds: int) -> str: 
    s = (salt + str(val))
    for _ in range(rounds): 
        s = hashlib.md5(s.encode()).hexdigest()
    return s

def day14(salt: str, rounds: int) -> int: 
    confirmations = {} 

    keys = {}
    def add_found_key(key: str, index: int): 
        nonlocal key_count
        if not key in keys: 
            keys[key] = [] 
        keys[key].append(index)
        key_count += 1
        print(f'{key}({key_count}) {index}')

    key_count = 0
    i = 0
    while key_count < 64: 
        hashed = get_digest(salt, i, rounds)
        pattern3 = r"(\w)\1{2,}"
        pattern5 = r"(\w)\1{4,}"

        match = re.search(pattern3, hashed)
        if match:
            match_group = match.group() 
            key = match_group[0]
            found = False
            if key in confirmations and confirmations[key] > i: 
                add_found_key(key, confirmations[key]) 
            else: 
                for j in range(i + 1, i + 1001): 
                    hashed = get_digest(salt, j, rounds)
                    match = re.search(pattern5, hashed)
                    if match: 
                        match_group = match.group()
                        if match_group[0] == key: 
                            found = True
                        confirm_key = match_group[0]

                        if not confirm_key in confirmations: 
                            confirmations[confirm_key] = 0
                        confirmations[confirm_key] = j
                        if found: 
                            add_found_key(confirm_key, confirmations[confirm_key]) 
                            break
        i += 1
        
       

    return i - 1
                        
    
def test_part1(): 
    salt = 'abc'
    expected = 22728
    result = day14(salt, 1)
    assert(expected == result)

def test_part2(): 
    salt = 'abc'
    expected = 22859
    result = day14(salt, 2017)
    assert(expected == result)


@pytest.mark.parametrize("hash, pattern, expected", [
    ("12aaa34567890", r"(\w)\1{2,}", "aaa"), 
    ("12aaaaa34567890", r"(\w)\1{4,}", "aaaaa"), 
    ("12aaa3456bbb7890", r"(\w)\1{2,}", "aaa"), 
    ("12aaa3456bbbbb7890", r"(\w)\1{2,}", "aaa"), 
    ("12aaaaa34567890", r"(\w)\1{4,}", "aaaaa"), 
    ("12aaa345bbbbb67890", r"(\w)\1{4,}", "bbbbb")
])
def test_capture(hash: str, pattern: str, expected: str):   
    match = re.search(pattern, hash)
    assert(match) 
    match_group = match.group()
    assert(match_group == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 
    main()