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
        pattern = r'(\w)\1{2,}'

        """
        def get_first_repeat(s):
    # Find the first sequence of at least 3 repeated characters
    match = re.search(r'(\w)\1{2,}', s)
    if match:
        repeated_seq = match.group()
        if len(repeated_seq) >= 5:
            return repeated_seq
        else:
            return repeated_seq[:3]
    return None
        """
        match = re.search(pattern, hashed)
        if match:
            match_group = match.group() 
            if len(match_group) >= 5: 
                if match_group[0] in candidates and i - candidates[match_group[0]] < 1000:
                    keys[match_group] = i
                    del candidates[match_group[0]] 
                    key_count += 1
            else: 
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