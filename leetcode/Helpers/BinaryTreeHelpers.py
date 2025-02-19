import pytest
import json
#  [1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]

class TreeNode:
    def __init__(self, val=0, left=None, right=None):
         self.val = val
         self.left = left
         self.right = right

"""
example definition: [1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]
"""
def parse_values(definition: str) -> list[int | None]: 
    definition = definition.strip()
    if definition == "[]": 
        return []
    definition = definition.strip().replace("null", "None")
    return eval(definition)


"""
example definition: [1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]
"""
def populate_tree(definition: str) -> TreeNode: 
    tree_vals = parse_values(definition)
    #root = TreeNode(tree_vals[0])
    if not tree_vals: 
        return None
    
    it = iter(tree_vals)
    root = TreeNode(next(it))
    current = [root]
    for node in current: 
        val = next(it, None)
        if val is not None: 
            node.left = TreeNode(val)
            current.append(node.left)
        val = next(it, None)
        if val is not None: 
            node.right = TreeNode(val)
            current.append(node.right)
    return root


@pytest.mark.parametrize("definition, expected", [
    ("[]", []), 
    ("[1,2,3]", [1,2,3]), 
    ("[1,2,null]", [1, 2, None])
])
def test_parse_values(definition: str, expected: list[int | None]): 
    result = parse_values(definition)
    assert(result == expected)


def test_get_empty_tree(): 
    definition = "[]"
    root = populate_tree(definition)
    expected = None
    assert(root == expected) 

"""
Test tree for the following definition: 
[1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]

Expected tree: 
                 1
               /    \\
              4      4
              \\    /
                2  2
               /  / \\
              1  6   8
                    / \\
                   1   3

"""
def test_get_tree(): 
   definition = "[1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]"

   root = populate_tree(definition)
   current = root
   assert current.val == 1
   assert current.left.val == 4
   assert current.right.val == 4
   current = current.left
   assert current.right.val == 2
   assert current.right.left.val == 1
   current = root.right
   assert current.left.val == 2
   assert current.left.left.val == 6
   assert current.right == None
   current = current.left
   assert current.right.val == 8
   assert current.right.left.val == 1
   assert current.right.right.val == 3

if __name__ == "__main__":
    pytest.main([__file__])
