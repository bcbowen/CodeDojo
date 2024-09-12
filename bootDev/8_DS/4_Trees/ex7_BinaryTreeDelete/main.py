class BSTNode:
    def delete(self, val):
        if not self.val:
            return None
        if val < self.val: 
            if self.left: 
                self.left = self.left.delete(val)
            return self
        elif val > self.val: 
            if self.right: 
                self.right = self.right.delete(val)
            return self
        else: 
            if not self.right: 
                return self.left
            elif not self.left: 
                return self.right
            else: 
                current = self.right
                while current.left: 
                    current = current.left
                    
                self.val = current.val
                self.right = self.right.delete(current.val)
                return self
                

    # don't touch below this line

    def __init__(self, val=None):
        self.left = None
        self.right = None
        self.val = val

    def insert(self, val):
        if not self.val:
            self.val = val
            return

        if self.val == val:
            return

        if val < self.val:
            if self.left:
                self.left.insert(val)
                return
            self.left = BSTNode(val)
            return

        if self.right:
            self.right.insert(val)
            return
        self.right = BSTNode(val)
