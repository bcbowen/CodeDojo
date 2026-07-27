class Solution:
    def minimumFlips(self, n: int) -> int:
        bf = str(bin(n))[2:]
        br = bf[::-1]
        flips = 0
        for i in range(len(bf)): 
            if bf[i] != br[i]: 
                flips += 1
        return flips