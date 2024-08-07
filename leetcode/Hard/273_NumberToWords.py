import math
import pytest

class Solution:
    def numberToWords(self, num: int) -> str:
        result = ""; 
        if num > 1000000000: 
            result = self.getBillions(int)
        
        if num > 1000000: 
            result += self.getMillions(int)

        if num > 1000: 
            result += self.getThousands(int)

        result += self.getHundreds(int)
        return result

    def getBillions(self, num: int) -> str: 
        pass

    def getMillions(self, num:int) -> str: 
        pass 

    def getThousands(self, num: int) -> str: 
        pass

    """
        getHundreds will be called for any number 0 - 2^31.. needs to handle number smaller than 100
    """
    def getHundreds(self, num: int) -> str: 
        val = num
        if num > 1000: 
            n2 = math.floor(num / 1000)
            n2 *= 1000
            val -= n2

        result = ""
        if val > 99: 
            h = math.floor(val / 100)
            result = f"{self.getOnes(h)} Hundred"
        
        tens = self.getTens(val)
        if len(tens) > 0 and len(result) > 0: 
            return f"{result} {tens}"
        if len(tens) > 0: 
            return tens
        return result
        

    def getTens(self, num: int) -> str: 
        if num < 10: 
            return ""
        val = num
        if num > 100: 
            n2 = math.floor(num / 100)
            n2 *= 100
            val -= n2
        if val > 99: 
            raise Exception("val should be a digit between 1 and 99 here. ")
        if val == 10: 
            return "Ten"
        if val == 11: 
            return "Eleven"
        if val == 12: 
            return "Twelve"
        if val == 13: 
            return "Thirteen"
        if val == 15: 
            return "Fifteen"
        if val > 13 and val < 20: 
            return f"{self.getOnes()(val)}teen"
        if val >= 20 and val < 30: 
            return ("Twenty " + self.getOnes(val)).strip()
        if val >= 30 and val < 40: 
            return ("Thirty " + self.getOnes(val)).strip()
        if val >= 40 and val < 50: 
            return ("Forty " + self.getOnes(val)).strip()
        if val >= 50 and val < 60: 
            return ("Fifty " + self.getOnes(val)).strip()
        if val >= 60 and val < 70: 
            return ("Sixty " + self.getOnes(val)).strip()
        if val >= 70 and val < 80: 
            return ("Seventy " + self.getOnes(val)).strip()
        if val >= 80 and val < 90: 
            return ("Eighty " + self.getOnes(val)).strip()
        # ex: 100 will pass 0 to ths method
        if val == 0: 
            return ""
        
        return ("Ninety " + self.getOnes(val)).strip()

    def getOnes(self, num: int) -> str: 
        if num == 0:
            return "Zero"
        val = num
        if num > 10: 
            n2 = math.floor(num / 10)
            n2 *= 10
            val -= n2
        if val > 9: 
            raise Exception("val should be a digit between 0 and 9 here. ")
        
        match val: 
            case 9: 
                return "Nine"
            case 8: 
                return "Eight"
            case 7: 
                return "Seven"
            case 6: 
                return "Six"
            case 5: 
                return "Five"
            case 4: 
                return "Four"
            case 3: 
                return "Three"
            case 2: 
                return "Two"
            case 1: 
                return "One"
            case 0: 
                return ""
            case _: 
                raise Exception ("How the hell did we get here?")



"""
Convert a non-negative integer num to its English words representation.


Example 1:
Input: num = 123
Output: "One Hundred Twenty Three"

Example 2:
Input: num = 12345
Output: "Twelve Thousand Three Hundred Forty Five"

Example 3:
Input: num = 1234567
Output: "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"
"""

@pytest.mark.parametrize("num, expected", [
    (123, "One Hundred Twenty Three"),
    (12345, "Twelve Thousand Three Hundred Forty Five"),
    (1234567, "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven")
])
def test_numberToWords(num: int, expected: str):
    result = Solution().numberToWords(num)
    assert result == expected

@pytest.mark.parametrize("num, expected", [
(123, "One Hundred Twenty Three"),
(23, "Twenty Three"),
(3, "Three"),
(12345, "Three Hundred Forty Five"),
(1234567, "Five Hundred Sixty Seven")
])
def test_getHundreds(num: int, expected: str):
    result = Solution().getHundreds(num)
    assert result == expected

@pytest.mark.parametrize("num, expected", [
(123, "Twenty Three"),
(23, "Twenty Three"),
(30, "Thirty"),
(12345, "Forty Five"),
(1234567, "Sixty Seven"), 
(90, "Ninety")
])
def test_getTens(num: int, expected: str):
    result = Solution().getTens(num)
    assert result == expected

@pytest.mark.parametrize("num, expected", [
(123, "Three"),
(23, "Three"),
(3, "Three"),
(12345, "Five"),
(1234567, "Seven"), 
(0, "Zero")
])
def test_getOnes(num: int, expected: str):
    result = Solution().getOnes(num)
    assert result == expected

if __name__ == "__main__":
    pytest.main([__file__])