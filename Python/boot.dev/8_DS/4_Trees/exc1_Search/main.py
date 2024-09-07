class BSTNode:
    def search_range(self, lower_bound, upper_bound):

        result = []
        if self.val == None: 
            return result
        
        if self.val.gamertag >= lower_bound and self.val.gamertag <= upper_bound: 
            result.append(self.val)
        if self.left != None and self.val.gamertag >= lower_bound: 
            result.extend(self.left.search_range(lower_bound, upper_bound))
        if self.right!= None and self.val.gamertag <= upper_bound: 
            result.extend(self.right.search_range(lower_bound, upper_bound))

        return result

    # don't touch below this line

    def exists(self, val):
        if val == self.val:
            return True

        if val < self.val:
            if self.left is None:
                return False
            return self.left.exists(val)

        if self.right is None:
            return False
        return self.right.exists(val)

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