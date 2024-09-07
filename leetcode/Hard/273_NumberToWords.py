import math
import pytest

class Solution:
    def __append(self, val, appendage): 
        if val == "": 
            return appendage.strip()
        return val.strip() + " " + appendage.strip()
    
    def numberToWords(self, num: int) -> str:
        if num == 0: 
            return "Zero"
        result = self.getBillions(num)
        result = self.__append(result, self.getMillions(num)) 
        result = self.__append(result, self.getThousands(num))
        result = self.__append(result, self.getHundreds(num))
        return result.strip()

    def getBillions(self, num: int) -> str: 
        if num < 1_000_000_000: 
            return ""
        
        val = num
        if num > 999_999_999_999: 
            n2 = math.floor(num / 1_000_000_000_000)
            n2 *= 1_000_000_000_000
            val -= n2
        result = ""
        
        # convert val to hundreds; 234,432,123,343 -> 234; 6,343,322,878 -> 6
        val = int(val / 1_000_000_000)
        result = self.getHundreds(val)
        if result != "": 
            result += " Billion"

        return result 

    def getMillions(self, num:int) -> str: 
        if num < 1_000_000: 
            return ""
        
        val = num
        if num > 999_999_999: 
            n2 = math.floor(num / 1_000_000_000)
            n2 *= 1_000_000_000
            val -= n2
        result = ""
        
        # convert val to hundreds; 234,432,123 -> 234; 6,343,322 -> 6
        val = int(val / 1_000_000)

        result = self.getHundreds(val)
        if result != "": 
            result += " Million"

        return result 

    def getThousands(self, num: int) -> str: 
        if num < 1_000: 
            return ""
        
        val = num
        if num > 999_999: 
            n2 = math.floor(num / 1_000_000)
            n2 *= 1_000_000
            val -= n2
        result = ""
        
        # convert val to hundreds; 234,432 -> 234; 4343 -> 4
        val = int(val / 1000)
        result = self.getHundreds(val)
        if result != "": 
            result += " Thousand"
        return result
            
    """
        getHundreds will be called for any number 0 - 2^31.. needs to handle number smaller than 100
    """
    def getHundreds(self, num: int) -> str: 
        val = num
        if num > 999: 
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
        
        if num % 100 == 0: 
            return ""
        val = num
        if num > 100: 
            n2 = math.floor(num / 100)
            n2 *= 100
            val -= n2
        if val < 10: 
            return self.getOnes(num)
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
        if val == 18: 
            return "Eighteen"
        if val > 13 and val < 20: 
            return f"{self.getOnes(val)}teen"
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
        
        return ("Ninety " + self.getOnes(val)).strip()

    def getOnes(self, num: int) -> str: 
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
    (0, "Zero"),
    (3, "Three"),
    (10, "Ten"),
    (23, "Twenty Three"),
    (14, "Fourteen"),
    (17, "Seventeen"),
    (18, "Eighteen"),
    (100, "One Hundred"),
    (101, "One Hundred One"),
    (123, "One Hundred Twenty Three"),
    (1_223, "One Thousand Two Hundred Twenty Three"),
    (1_000, "One Thousand"),
    (1_001, "One Thousand One"),
    (100, "One Hundred"),
    (4_000, "Four Thousand"),
    (4_001, "Four Thousand One"),
    (4_013, "Four Thousand Thirteen"),
    (10_000, "Ten Thousand"),
    (12_345, "Twelve Thousand Three Hundred Forty Five"),
    (1_234_567, "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"),
    (1_000_000, "One Million"),
    (1_000_001, "One Million One"),
    (10_000_000, "Ten Million"),
    (100_000_000, "One Hundred Million"),
    (1_000_000_000, "One Billion"),
    (1_000_000_001, "One Billion One"),
    (10_000_000_000, "Ten Billion")
])
def test_numberToWords(num: int, expected: str):
    result = Solution().numberToWords(num)
    assert result == expected

@pytest.mark.parametrize("num, expected", [
(123_020_343_656, "One Hundred Twenty Three Billion"),
(23_004_323_454, "Twenty Three Billion"),
(3_342_535_656, "Three Billion"),
(12_345_655_343_455, "Three Hundred Forty Five Billion"),
(1_234_567_343_343, "Two Hundred Thirty Four Billion")
])
def test_getBillions(num: int, expected: str):
    result = Solution().getBillions(num)
    assert result == expected

@pytest.mark.parametrize("num, expected", [
(123_020_343, "One Hundred Twenty Three Million"),
(23_004_323, "Twenty Three Million"),
(3_342_535, "Three Million"),
(12_345_655_343, "Three Hundred Forty Five Million"),
(1_234_567_343, "Two Hundred Thirty Four Million")
])
def test_getMillions(num: int, expected: str):
    result = Solution().getMillions(num)
    assert result == expected

@pytest.mark.parametrize("num, expected", [
(123_020, "One Hundred Twenty Three Thousand"),
(23_004, "Twenty Three Thousand"),
(3_342, "Three Thousand"),
(12_345_655, "Three Hundred Forty Five Thousand"),
(1_234_567, "Two Hundred Thirty Four Thousand")
])
def test_getThousands(num: int, expected: str):
    result = Solution().getThousands(num)
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
(1234567, "Seven")
])
def test_getOnes(num: int, expected: str):
    result = Solution().getOnes(num)
    assert result == expected

if __name__ == "__main__":
    pytest.main([__file__])