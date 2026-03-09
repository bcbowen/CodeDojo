import pytest


class Solution:
    def dayOfTheWeek(self, day: int, month: int, year: int) -> str:
        days_passed = 0
        current_year = 1971
        current_month = 1

        while current_year < year: 
            days_passed += Solution.daysPerYear(current_year)
            current_year += 1

        while current_month < month: 
            days_passed += Solution.daysPerMonth(year, current_month)
            current_month += 1   

        days_passed += day - 1

        return Solution.getDayName(days_passed)         

    @staticmethod
    def getDayName(daysPassed: int) -> str: 
        day_names = ['Friday', 'Saturday', 'Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday']
        offset = daysPassed % 7
        return day_names[offset] 

    @staticmethod
    def isLeap(year: int) -> bool: 
         return (year % 100 != 0 and year % 4 == 0) or year % 400 == 0
    
    @staticmethod
    def daysPerYear(year: int) -> int: 
         return 365 if not Solution.isLeap(year) else 366
    
    @staticmethod
    def daysPerMonth(year: int, month: int) -> int:
            # January, March, may, July, August, October, and December
            longs = [1, 3, 5, 7, 8, 10, 12]
            shorts = [4, 6, 9, 11] 
            if month in longs: 
                return 31
            elif month in shorts: 
                return 30
            else: 
                return 28 if not Solution.isLeap(year) else 29
        

"""
Example 1:
Input: day = 31, month = 8, year = 2019
Output: "Saturday"

Example 2:
Input: day = 18, month = 7, year = 1999
Output: "Sunday"

Example 3:
Input: day = 15, month = 8, year = 1993
Output: "Sunday"

Given: 
Input: day = 1, month = 1, year = 1971
Output: "Friday"

"""
@pytest.mark.parametrize("day, month, year, expected", [
     (31, 8, 2019, 'Saturday'), 
     (18, 7, 1999, 'Sunday'), 
     (15, 8, 1993, "Sunday"), 
     (1, 1, 1971, 'Friday')
])
def test_dayOfWeek(day: int, month: int, year: int, expected: str):
     result = Solution().dayOfTheWeek(day, month, year)
     assert(result == expected) 

@pytest.mark.parametrize("year, expected", [
     (2000, 366),
     (2001, 365), 
     (2024, 366), 
     (2026, 365) 
])
def test_days_per_year(year: int, expected: int):
     result = Solution.daysPerYear(year)
     assert(result == expected)

if __name__ == "__main__":
     pytest.main([__file__]) 