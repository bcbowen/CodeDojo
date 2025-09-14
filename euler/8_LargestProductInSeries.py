import pytest
from collections import deque
from typing import List

# TODO: When we come accross a zero we have to flush the digits array and move to the number following 
# the zero and start over

def get_max_product(digit_count: int, values: List[int]) -> int: 
    return 4

"""
def 

def get_max_product(digit_count: int) -> int:
    product = 1
    max_product = 1
    numbers = get_numbers()
    i = 0
    #max_digits = deque()
    digits = deque()
    while i < digit_count: 
        val = int(numbers[i])
        if val > 0: 
            product *= int(numbers[i])
            digits.append(numbers[i])
        i += 1
    max_product = product
    #max_digits = digits.copy()

    while i < len(numbers): 
        if numbers[i] == '0'
        val = int(digits.popleft())
        product //= val    
        if numbers[i].isdigit() and numbers[i] != '0': 
            val = int(numbers[i])
            product *= val
            digits.append(numbers[i])
            if product > max_product: 
                max_product = product
                #max_digits = digits.copy()
        
        i += 1
        
        
    return max_product

"""

def get_input() -> List[int]: 
    values = """73167176531330624919225119674426574742355349194934
    96983520312774506326239578318016984801869478851843
    85861560789112949495459501737958331952853208805511
    12540698747158523863050715693290963295227443043557
    66896648950445244523161731856403098711121722383113
    62229893423380308135336276614282806444486645238749
    30358907296290491560440772390713810515859307960866
    70172427121883998797908792274921901699720888093776
    65727333001053367881220235421809751254540594752243
    52584907711670556013604839586446706324415722155397
    53697817977846174064955149290862569321978468622482
    83972241375657056057490261407972968652414535100474
    82166370484403199890008895243450658541227588666881
    16427171479924442928230863465674813919123162824586
    17866458359124566529476545682848912883142607690042
    24219022671055626321111109370544217506941658960408
    07198403850962455444362981230987879927244284909188
    84580156166097919133875499200524063689912560717606
    05886116467109405077541002256983155200055935729725
    71636269561882670428252483600823257530420752963450"""

    result = []
    for line in values.split('\n'):
        result.extend([int(c) for c in line if c.isdigit()])
    return result

def big_test(): 
    inputs = get_input()
    expected = 5832
    result = get_max_product(4, inputs)
    assert(result == expected)

def test_get_input(): 
    result = get_input()
    assert (len(result) == 1000)

def main(): 
    print("coming soon")

if __name__ == "__main__":
    pytest.main([__file__]) 