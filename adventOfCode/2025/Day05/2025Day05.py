import pytest
from bisect import bisect_left
from dataclasses import dataclass
from typing import List, Tuple
from pathlib import Path

@dataclass
class ProductRange: 
    def __init__(self, min_id: int, max_id: int): 
        self.min_id = min_id
        self.max_id = max_id

    """
    Return the previous index and whether the next index contains the product id
    """
    @staticmethod
    def find(products: List["ProductRange"], product_id: int) -> Tuple[int, bool]: 
        
          ends = [p.max_id for p in products]

          i = bisect_left(ends, product_id)

          if i == len(products): 
               i = len(products) - 1
          
          product = products[i]
          return (i, product_id >= product.min_id and product_id <= product.max_id)

def get_input_filepath(file_name: str) -> Path:
        current_path = Path(__file__).parent
        day = current_path.name
        current_path = current_path.parent
        year = current_path.name

        # traverse up directories to the private files
        private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

        input_path = private_files_base / year / day / file_name
        return input_path

def main(): 
    pass

"""
100 product ranges [1 - 5, 11 - 15, ..., 991 - 995]
"""
@pytest.mark.parametrize("product_id, expected", [
     (0, (0, False)), 
     (1, (0, True)), 
     (3, (0, True)), 
     (5, (0, True)), 
     (6, (1, False)), 
     (9, (1, False)),

     (10, (1, False)), 
     (11, (1, True)), 
     (15, (1, True)), 
     (16, (2, False)), 
     (19, (2, False)), 

     (20, (2, False)),
     (21, (2, True)),
     (25, (2, True)),
     (26, (3, False)),
     
     (930, (93, False)),
     (931, (93, True)), 
     (932, (93, True)), 
     (935, (93, True)), 
     (936, (94, False)), 

     (640, (64, False)),
     (641, (64, True)), 
     (642, (64, True)), 
     (645, (64, True)), 
     (646, (65, False)), 

     (500, (50, False)),
     (501, (50, True)), 
     (502, (50, True)), 
     (505, (50, True)), 
     (506, (51, False)), 

     (390, (39, False)),
     (391, (39, True)), 
     (392, (39, True)), 
     (395, (39, True)), 
     (396, (40, False)), 

     (180, (18, False)),
     (181, (18, True)), 
     (182, (18, True)), 
     (185, (18, True)), 
     (186, (19, False)), 

     (1000, (99, False))
])
def test_product_find(product_id: int, expected: Tuple[int, bool]):
     products = [] 
     base = 1
     for _ in range(100): 
          products.append(ProductRange(base, base + 4))
          base += 10
     result = ProductRange.find(products, product_id)
     assert(result == expected)


if __name__ == "__main__":
    pytest.main([__file__])
    main()