import pytest
import math

def sum_primes(limit: int) -> int: 
    prime_sum = 0
    for i in range(limit):
        if is_prime(i): 
            prime_sum += i 
    return prime_sum
 

def is_prime(val: int) -> bool: 
    if val < 2: 
        return False
    elif val == 2: 
        return True
    elif val % 2 == 0: 
        return False 
    else: 
        limit = int(math.ceil(math.sqrt(val)))
        for i in range(3, limit + 1):
            if val % i == 0: 
                return False
	
    return True

def main(): 
    limit = 2_000_000
    result = sum_primes(limit)
    print(f"Sum of primes below {limit}: {result}")

"""
The sum of the primes below 10 is: 
2 + 3 + 5 + 7 = 17 
.

Find the sum of all the primes below two million.
"""

@pytest.mark.parametrize("n, expected", [
    (2, True),
    (3, True), 
    (13, True), 
    (1187, True), 
    (6113, True), 
    (4482, False), 
    (4485, False), 
    (4753, False), 
    (21269, True),
    (1555, False), 
    (121, False), 
    (25, False)
])
def test_is_prime(n: int, expected: bool): 
    result = is_prime(n) 
    assert(expected == result) 

def test_sum_primes(): 
    limit = 10
    expected = 17
    result = sum_primes(limit)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 
    main()