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
        new_node = RBNode(val)
        new_node.parent = None
        new_node.left = self.nil
        new_node.right = self.nil
        new_node.red = True

        parent = None
        current = self.root
        while current != self.nil:
            parent = current
            if new_node.val < current.val:
                current = current.left
            elif new_node.val > current.val:
                current = current.right
            else:
                # duplicate, just ignore
                return

        new_node.parent = parent
        if parent is None:
            self.root = new_node
        elif new_node.val < parent.val:
            parent.left = new_node
        else:
            parent.right = new_node

        self.fix_insert(new_node)

    """
            
    1. While the new node isn't the root of the tree and its parent is red:
        1. If the parent is a right child:
            1. Set uncle to the parent's sibling
            2. If the uncle is red:
                1. Change the uncle to black
                2. Set the parent to black
                3. Set the grandparent to red
                4. Set the new node to be equal to the grandparent. This will allow the loop to continue the recoloring process up the tree
            3. Otherwise, if the uncle is black:
                1. If the new node is a left child:
                    1. Set the new node to its parent
                    2. Rotate the tree right around the new node
                2. Set the parent to black
                3. Set the grandparent to red
                4. Rotate the tree left around the grandparent
        2. Otherwise, if the parent is a left child:
            1. Set uncle to the parent's sibling
            2. If the uncle is red:
                1. Change the uncle to black
                2. Set the parent to black
                3. Set the grandparent to red
                4. Set the new node to its grandparent
            3. Otherwise, if the uncle is black:
                1. If the new node is a right child:
                    1. Set the new node to its parent
                    2. Rotate the tree left around the new node
                2. Set the parent to black
                3. Set the grandparent to red
                4. Rotate the tree right around the grandparent
    2. Set the root to black

    """

    def fix_insert(self, new_node):
        while new_node != self.root and new_node.parent.red: 
            if new_node.parent.parent != self.nil: 
                grandparent = new_node.parent.parent
                if grandparent.right == new_node.parent: 
                    uncle = grandparent.left
                    if uncle.red: 
                        uncle.red = False
                        new_node.parent.red = False
                        grandparent.red = True
                        new_node = grandparent
                    else:
                        if new_node == new_node.parent.left: 
                            new_node = new_node.parent
                            self.rotate_right(new_node)
                        new_node.parent.red = False
                        grandparent = new_node.parent.parent
                        grandparent.red = True
                        self.rotate_left(grandparent)
                else:
                    uncle = grandparent.right
                    if uncle.red: 
                        uncle.red = False
                        new_node.parent.red = False
                        grandparent.red = True
                        new_node = grandparent
                    else:
                        if new_node == new_node.parent.right: 
                            new_node = new_node.parent
                            self.rotate_left(new_node)
                        new_node.parent.red = False
                        grandparent = new_node.parent.parent
                        grandparent.red = True
                        self.rotate_right(grandparent)
        
        self.root.red = False

    def exists(self, val):
        curr = self.root
        while curr != self.nil and val != curr.val:
            if val < curr.val:
                curr = curr.left
            else:
                curr = curr.right
        return curr

    def rotate_left(self, x):
        if x == self.nil or x.right == self.nil:
            return
        y = x.right
        x.right = y.left
        if y.left != self.nil:
            y.left.parent = x

        y.parent = x.parent
        if x.parent is None:
            self.root = y
        elif x == x.parent.left:
            x.parent.left = y
        else:
            x.parent.right = y
        y.left = x
        x.parent = y

    def rotate_right(self, x):
        if x == self.nil or x.left == self.nil:
            return
        y = x.left
        x.left = y.right
        if y.right != self.nil:
            y.right.parent = x

        y.parent = x.parent
        if x.parent is None:
            self.root = y
        elif x == x.parent.right:
            x.parent.right = y
        else:
            x.parent.left = y
        y.right = x
        x.parent = y