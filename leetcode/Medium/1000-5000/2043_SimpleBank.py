import pytest 
from typing import List

class Bank:


    def __init__(self, balance: List[int]):
        self.balances = balance
        self.balances.insert(0, -1)        

    def is_valid_account_number(self, account: int) -> bool:
        return account < len(self.balances) and account > 0

    def transfer(self, account1: int, account2: int, money: int) -> bool:
        if self.is_valid_account_number(account1) and self.is_valid_account_number(account2) and self.balances[account1] >= money:
            self.balances[account1] -= money
            self.balances[account2] += money
            return True
        
        return False 

    def deposit(self, account: int, money: int) -> bool:
        if self.is_valid_account_number(account): 
            self.balances[account] += money
            return True
        
        return False

    def withdraw(self, account: int, money: int) -> bool:
        if self.is_valid_account_number(account) and self.balances[account] >= money:  
            self.balances[account] -= money
            return True
        return False

# Your Bank object will be instantiated and called as such:
# obj = Bank(balance)
# param_1 = obj.transfer(account1,account2,money)
# param_2 = obj.deposit(account,money)
# param_3 = obj.withdraw(account,money)

if __name__ == "__main__":
    pytest.main([__file__]) 