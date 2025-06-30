import random
import pytest

__lower_letter = 1
__upper_letter = 2
__digit = 3
__char = 4

def generate_password(password_length: int, use_upper: bool, use_digits: bool, use_chars: bool) -> str: 
    chars = []
    for _ in range(password_length): 
        chars.append(generate_char(use_upper, use_digits, use_chars))
    return ''.join(chars)

def generate_char(use_upper: bool, use_digits: bool, use_chars: bool) -> str: 
    
    next_type = get_next_character_type(use_upper, use_digits, use_chars)
    codes = []
    if next_type == 4: 
        for i in range(33, 48): 
            codes.append(i)
        for i in range(58, 65): 
            codes.append(i)
        for i in range(91, 97): 
            codes.append(i)
        for i in range(123, 127): 
            codes.append(i)

    else: 
        min, max = 97, 122 # default to lower
        match get_next_character_type(use_upper, use_digits, use_chars): 
            case 2: # upper
                min = 65
                max = 90
            case 3: # digits
                min = 48
                max = 57
        codes = [i for i in range(min, max + 1)]
    return chr(random.choice(codes))

def get_next_character_type(use_upper: bool, use_digits: bool, use_chars: bool) -> int: 
    if not use_upper and not use_digits and not use_chars: 
        return 1
    types = [1]
    if use_upper: 
        types.append(2)
    if use_digits: 
        types.append(3) 
    if use_chars: 
        types.append(4) 
    i = random.choice(types)
    return i

def test_generate_password_loweronly(): 
    for pw_len in range(8, 14): 
        password = generate_password(pw_len, False, False, False)
        assert(len(password) == pw_len)
        assert(password.islower())
        assert(password.isalpha())
        #print(password)
    
def test_generate_password_alphaonly(): 
    for pw_len in range(8, 14): 
        password = generate_password(pw_len, True, False, False)
        assert(len(password) == pw_len)
        assert(not password.islower())
        assert(password.isalpha())
        #print(password)

def test_generate_password_upper_lower_nums(): 
    for pw_len in range(8, 14): 
        password = generate_password(pw_len, True, True, False)
        assert(len(password) == pw_len)
        assert(not password.isalpha())
        assert(password.isalnum())
        #print(password)

def test_generate_password_upper_lower_nums_chars(): 
    for pw_len in range(8, 14): 
        password = generate_password(pw_len, True, True, True)
        assert(len(password) == pw_len)
        assert(not password.isalpha())
        assert(not password.isalnum())
        #print(password)


if __name__ == "__main__": 
    pytest.main([__file__])