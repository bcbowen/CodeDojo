class RBNode:
    def __init__(self, val):
        self.red = False
        self.parent = None
        self.val = val
        self.left = None
        self.right = None


class RBTree:
    def __init__(self):
        self.nil = RBNode(None)
        self.nil.red = False
        self.nil.left = None
        self.nil.right = None
        self.root = self.nil

    def insert(self, val):
        node = RBNode(val)
        node.red = True
        node.left = self.nil 
        node.right = self.nil

        parent = None
        current = self.root
        
        while current != self.nil: 
            parent = current 
            if val < current.val:
                current = current.left
            elif val > current.val: 
                current = current.right
            else: 
                return
        
        node.parent = parent
        if parent == None: 
            self.root = node
        elif val < parent.val: 
            parent.left = node
        else: 
            parent.right = node
