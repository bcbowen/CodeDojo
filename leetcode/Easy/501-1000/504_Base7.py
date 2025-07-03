class Solution:
    def convertToBase7(self, num: int) -> str:
        if num == 0: 
            return "0"
        bits = [] 
        sign = "-" if num < 0 else ''
        num = abs(num)
        while num > 0: 
            bits.append(str(num % 7))
            num //=7

        return sign + ''.join(reversed(bits))