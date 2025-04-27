import hashlib
import pytest
import re

def main(): 
    print(hashlib.md5(b'abc18').hexdigest())

def part1(salt: str) -> int: 
    candidates = {} 
    key_count = 0
    i = 0
    while key_count < 64: # this will be 64
        
        val = (salt + str(i)).encode()
        hashed = hashlib.md5(val).hexdigest()
        pattern = r'(\w)\1{2}(?!\1)|(\w)\2{4}(?!\2)'
        matches = re.finditer(pattern, hashed)

        for match in matches:
            match_group = match.group()
            if len(match_group) == 5: 
                if match_group[0] in candidates and i - candidates[match_group[0]] <= 1000:
                    key_count += 1

                del candidates[match_group[0]]
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

def test_capture(): 
    s = "0034e0923cc38887aaaab57bd7b1d4f953dfbbbbba"

    pattern = r'(\w)\1{2}(?!\1)|(\w)\2{4}(?!\2)'
    matches = re.finditer(pattern, s)

    for match in matches:
        print(match.group())

def test_capture2(): 
    s = "0034e0923cc38887a57bd7b1d4f953dfaaaabbbbbccccc888"
    matches = re.findall(r'((\w)\2{2}|(\w)\3{4})', s)

    # Extract the full matched sequences
    results = [match[0] for match in matches]
    print(results)

if __name__ == "__main__":
    pytest.main([__file__]) 
    main()