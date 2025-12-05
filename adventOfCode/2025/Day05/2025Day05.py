import pytest
from typing import List, Tuple
from pathlib import Path

class ProductRange: 
    def __init__(self, min_id: int, max_id: int): 
        self.min_id = min_id
        self.max_id = max_id

    """
    Return the previous index and whether the next index contains the product id
    """
    @staticmethod
    def find(products: List[ProductRange], product_id: int) -> Tuple[int, bool]: 
        # first check if product goes at beginning or end of list 
        if len(products) == 0 or product_id < products[0].min_id: 
             return (0, False)
        elif product_id <= products[0].max_id: 
             return (0, True)
        elif product_id > products[-1].min_id: 
             return (len(products) - 1, product_id <= products[-1].max_id)

        left = 0
        right = len(products) - 1
        mid = right // 2
        while left <= right:
            if products[mid].min_id <= product_id and products[mid].max_id >= product_id: 
                 return (mid, True)
            elif products[mid].min_id > product_id and products[mid - 1].max_id < product_id: 
                 return (mid, False)
            elif products[mid].min_id > product_id: 
                 right = mid - 1
            elif products[mid].max_id < product_id: 
                 left = mid + 1
            mid = right // 2

        return (mid, False)

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

@pytest.mark.parametrize("products, product_id, expected", [
    ([ProductRange(1, 5), ProductRange(10, 15), ProductRange(20, 25)], 0, (0, False)), 
    ([ProductRange(1, 5), ProductRange(10, 15), ProductRange(20, 25)], 1, (0, True)), 
    ([ProductRange(1, 5), ProductRange(10, 15), ProductRange(20, 25)], 3, (0, True)), 
    ([ProductRange(1, 5), ProductRange(10, 15), ProductRange(20, 25)], 5, (0, True)), 
    ([ProductRange(1, 5), ProductRange(10, 15), ProductRange(20, 25)], 6, (1, False)), 
    ([ProductRange(1, 5), ProductRange(10, 15), ProductRange(20, 25)], 9, (1, False)),

    ([ProductRange(1, 5), ProductRange(10, 15), ProductRange(20, 25)], 10, (1, True)), 
    ([ProductRange(1, 5), ProductRange(10, 15), ProductRange(20, 25)], 11, (1, True)), 
    ([ProductRange(1, 5), ProductRange(10, 15), ProductRange(20, 25)], 15, (1, True)), 
    ([ProductRange(1, 5), ProductRange(10, 15), ProductRange(20, 25)], 16, (2, False)), 
    ([ProductRange(1, 5), ProductRange(10, 15), ProductRange(20, 25)], 19, (2, False)), 
    ([ProductRange(1, 5), ProductRange(10, 15), ProductRange(20, 25)], 20, (2, True)),
    ([ProductRange(1, 5), ProductRange(10, 15), ProductRange(20, 25)], 21, (2, True)),
    ([ProductRange(1, 5), ProductRange(10, 15), ProductRange(20, 25)], 25, (2, True)),
    ([ProductRange(1, 5), ProductRange(10, 15), ProductRange(20, 25)], 26, (2, False)),
])
def test_product_find(products: List[ProductRange], product_id: int, expected: Tuple[int, bool]):
    result = ProductRange.find(products, product_id)
    assert(result == expected)


if __name__ == "__main__":
    pytest.main([__file__])
    main()