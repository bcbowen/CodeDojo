class Solution:
    def numberOfDays(self, year: int, month: int) -> int:
        # January, March, may, July, August, October, and December
        longs = [1, 3, 5, 7, 8, 10, 12]
        shorts = [4, 6, 9, 11] 
        if month in longs: 
            return 31
        elif month in shorts: 
            return 30
        else: 
            is_leap = (year % 100 != 0 and year % 4 == 0) or year % 400 == 0
            return 28 if not is_leap else 29
    
    def dayOfYear(self, date: str) -> int:
        year = int(date[0:4])
        month = int(date[5:7])
        day = int(date[8:])

        days = 0 
        for i in range(1, month): 
            days += self.numberOfDays(year, i)
        days += day
        return days