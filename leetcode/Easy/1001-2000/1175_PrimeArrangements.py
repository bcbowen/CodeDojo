import math


class Solution:
    def numPrimeArrangements(self, n: int) -> int:
        primes = [] 
        nonprimes = [] 

        nonprimes.append(1)
        for i in range(2, n + 1): 
            if self.is_prime(i): 
                primes.append(i)
            else: 
                nonprimes.append(i)
        prime_permutations = math.factorial(len(primes))
        nonprime_permutations = math.factorial(len(nonprimes))

        return (prime_permutations * nonprime_permutations) % (10**9 + 7)

    def is_prime(self, val: int) -> bool: 
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