from typing import Dict

class Logger:

    def __init__(self):
        self.messageHistory : Dict[str, int]= {};     

    def shouldPrintMessage(self, timestamp: int, message: str) -> bool:
        if not message in self.messageHistory or timestamp - self.messageHistory[message] >= 10: 
            self.messageHistory[message] = timestamp
            return True
        return False


# Your Logger object will be instantiated and called as such:
# obj = Logger()
# param_1 = obj.shouldPrintMessage(timestamp,message)