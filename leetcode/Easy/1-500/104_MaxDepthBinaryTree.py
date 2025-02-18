import pytest
import sys 
import os 

helper_path = os.path.abspath(os.path.join(os.path.dirname(__file__), "../..", "Helpers"))

if helper_path not in sys.path: 
    sys.path.append(helper_path)

import BinaryTreeHelpers

def test_import(): 
    vals = "[1,2,3]"
    result = BinaryTreeHelpers.parse_values(vals)
    expected = [1,2,3]
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])