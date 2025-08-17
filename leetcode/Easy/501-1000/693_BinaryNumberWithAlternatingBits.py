class Solution:
    def hasAlternatingBits(self, n: int) -> bool:
        if (n & 1) == 1: 
            test = 1
            while test <= n: 
                if test == n: 
                    return True
                test <<= 2
                test |= 1
        else: 
            test = 2
            while test <= n: 
                if test == n: 
                    return True
                test <<= 2
                test |= 2
        return False