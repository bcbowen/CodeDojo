import pytest

class Solution:
    def lemonadeChange(self, bills: list[int]) -> bool:
        rx = {}
        for bill in bills: 
            if not bill in rx: 
                rx[bill] = 0
            rx[bill] += 1
            if bill > 5: 
                (result, rx) = self.makeChange(bill - 5, rx)
                if not result: 
                    return False
        return True


    def makeChange(self, amountNeeded: int, bills: dict[int, int]) -> tuple[bool, dict[int, int]]: 
        while amountNeeded >= 20 and 20 in bills and bills[20] > 0: 
            amountNeeded -= 20
            bills[20] -= 1
        
        while amountNeeded >= 10 and 10 in bills and bills[10] > 0: 
            amountNeeded -= 10
            bills[10] -= 1
        
        while amountNeeded >= 5 and 5 in bills and bills[5] > 0: 
            amountNeeded -= 5
            bills[5] -= 1

        result = amountNeeded == 0
        return (result, bills)


"""
At a lemonade stand, each lemonade costs $5. Customers are standing in a queue to buy from you 
and order one at a time (in the order specified by bills). Each customer will only buy one 
lemonade and pay with either a $5, $10, or $20 bill. You must provide the correct change to 
each customer so that the net transaction is that the customer pays $5.

Note that you do not have any change in hand at first.

Given an integer array bills where bills[i] is the bill the ith customer pays, return true if 
you can provide every customer with the correct change, or false otherwise.

 

Example 1:
Input: bills = [5,5,5,10,20]
Output: true
Explanation: 
From the first 3 customers, we collect three $5 bills in order.
From the fourth customer, we collect a $10 bill and give back a $5.
From the fifth customer, we give a $10 bill and a $5 bill.
Since all customers got correct change, we output true.

Example 2:
Input: bills = [5,5,10,10,20]
Output: false
Explanation: 
From the first two customers in order, we collect two $5 bills.
For the next two customers in order, we collect a $10 bill and give back a $5 bill.
For the last customer, we can not give the change of $15 back because we only have two $10 bills.
Since not every customer received the correct change, the answer is false.

"""

@pytest.mark.parametrize("bills, expected", [
    ([5,5,5,10,20], True),
    ([5,5,10,10,20], False), 
    ([10,10], False)
])
def test_lemonadeChange(bills: list[int], expected: bool):
    result = Solution().lemonadeChange(bills)
    assert result == expected

if __name__ == "__main__":
    pytest.main([__file__])