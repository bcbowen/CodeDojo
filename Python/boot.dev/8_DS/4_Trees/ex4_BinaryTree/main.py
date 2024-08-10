class BSTNode:
    def __init__(self, val=None):
        self.left = None
        self.right = None
        self.val = val

    def insert(self, val):
        if self.val == None: 
            self.val = val
        elif val == self.val: 
            return 
        elif val < self.val: 
            if self.left == None: 
                self.left = BSTNode(val)                
            else: 
                self.left.insert(val)
        else: 
            if self.right == None: 
                self.right = BSTNode(val) 
            else: 
                self.right.insert(val)
