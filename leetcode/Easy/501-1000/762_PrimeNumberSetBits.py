import pytest 

class Solution:
    def countPrimeSetBits(self, left: int, right: int) -> int:
        def get_bit_count(val: int) -> int: 
            return bin(val).count('1')
        
        def is_prime(val: int) -> bool:
            if val < 2:
                return False
            if val == 2:
                return True
            if val % 2 == 0:
                return False
            for i in range(3, int(val ** 0.5) + 1, 2):
                if val % i == 0:
                    return False
            return True
        
        prime_count = 0
        for num in range(left, right + 1):
            bit_count = get_bit_count(num)
             
            if is_prime(bit_count): 
                prime_count += 1

        return prime_count
    
"""
Example 1:

Input: left = 6, right = 10
Output: 4
Explanation:
6  -> 110 (2 set bits, 2 is prime)
7  -> 111 (3 set bits, 3 is prime)
8  -> 1000 (1 set bit, 1 is not prime)
9  -> 1001 (2 set bits, 2 is prime)
10 -> 1010 (2 set bits, 2 is prime)
4 numbers have a prime number of set bits.
Example 2:

Input: left = 10, right = 15
Output: 5
Explanation:
10 -> 1010 (2 set bits, 2 is prime)
11 -> 1011 (3 set bits, 3 is prime)
12 -> 1100 (2 set bits, 2 is prime)
13 -> 1101 (3 set bits, 3 is prime)
14 -> 1110 (3 set bits, 3 is prime)
15 -> 1111 (4 set bits, 4 is not prime)
5 numbers have a prime number of set bits.

left = 289051
right = 294301
Expected = 1465

"""
@pytest.mark.parametrize("left, right, expected", [
    (6, 10, 4), 
    (10, 15, 5), 
    (990, 1048, 28), 
    (289051, 294301, 1465)
])
def test_countPrimeSetBits(left: int, right: int, expected: int):
    result = Solution().countPrimeSetBits(left, right)
    assert(result == expected)


if __name__ == "__main__":
    pytest.main([__file__]) 