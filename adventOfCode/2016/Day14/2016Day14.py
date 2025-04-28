import hashlib
import pytest
import re

def main(): 
    print(hashlib.md5(b'abc18').hexdigest())

def part1(salt: str) -> int: 
    candidates = {} 
    keys = {}
    key_count = 0
    i = 0
    while key_count < 64: 
        #if i > 900: 
        #    break

        val = (salt + str(i)).encode()
        hashed = hashlib.md5(val).hexdigest()
        #pattern = r'(\w)\1{2}(?!\1)|(\w)\2{4}(?!\2)'
        pattern5 = r"(\w)\1{4,}"
        pattern3 = r"(\w)\1{2,}"
        #matches = re.finditer(pattern, hashed)

        """
        m = re.search(pattern_five, s)
        if m:
            print(f"Found 5+: {m.group()}")
        else:
            # If no 5+, try to find at least 3
            m = re.search(pattern_three, s)
            if m:
                print(f"Found 3+: {m.group()}")
            else:
                print("No match")
        """
        match = re.search(pattern5, hashed)
        if match:
            match_group = match.group() 
            if match_group[0] in candidates and i - candidates[match_group[0]] < 1000:
                keys[match_group] = i
                del candidates[match_group[0]] 
                key_count += 1
        else: 
            match = re.search(pattern3, hashed)
            if match: 
                match_group = match.group()
                if not match_group[0] in candidates: 
                    candidates[match_group[0]] = 0
                candidates[match_group[0]] = i
            
        i += 1

    return i
                        
    
def test_part1(): 
    salt = 'abc'
    expected = 22728
    result = part1(salt)
    assert(expected == result)

def test_capture3(): 
    s = "0034e0923cc38887aaaab57bd7b1d4f953dfbbbbba"

    pattern = r'(\w)\1{2,}'
    match = re.search(pattern, s)
    assert(match) 
    match_group = match.group()
    expected = '888'
    assert(match_group == expected)

def test_capture5(): 
    s = "0034e0923cc38887a57bd7b1d4f953dfaaaabbbbbccccc888"
    pattern = r'(\w)\1{4,}'
    match = re.search(pattern, s)
    assert(match) 
    match_group = match.group()
    expected = 'bbbbb'
    assert(match_group == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 
    main()