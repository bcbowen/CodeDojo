import pytest
from bisect import bisect_left
from dataclasses import dataclass
from typing import List, Tuple
from pathlib import Path
import sys

sys.path.insert(0, str(Path(__file__).resolve().parents[2]))  # repo root
import Modules.aoc_io


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

    @staticmethod
    def parse(line: str) -> "ProductRange":
        fields = line.split("-")
        return ProductRange(int(fields[0]), int(fields[1]))

    """
        23-40
        35-60
        23-25
        40-60

        41-50

    """

    @staticmethod
    def moige(product_ranges: List["ProductRange"]) -> List["ProductRange"]:
        if not product_ranges:
            return []

        # Sort by the *start* of the range
        product_ranges.sort(key=lambda p: p.min_id)

        current_range: "ProductRange" = product_ranges[0]
        moiged: List["ProductRange"] = []

        for i in range(1, len(product_ranges)):
            r = product_ranges[i]

            # No overlap → push current and start a new one
            if (
                r.min_id > current_range.max_id
            ):  # use >= if touching ranges shouldn't merge
                moiged.append(current_range)
                current_range = r
            else:
                # Overlap → extend current range
                current_range.max_id = max(current_range.max_id, r.max_id)

        # Append the last accumulated range
        moiged.append(current_range)

        return moiged


def get_inputs(file_name: str) -> Tuple[List[ProductRange], List[int]]:
    content = Modules.aoc_io.read_input(2025, 5, file_name)
    product_ranges = []
    product_ids = []
    for line in content.splitlines(keepends=True):
        if line.strip() == "":
            continue
        elif "-" in line:
            product_ranges.append(ProductRange.parse(line))
        else:
            product_ids.append(int(line))

    # product_ranges = ProductRange.moige(product_ranges)

    return (product_ranges, product_ids)


def part1(file_name: str) -> int:
    product_ranges, product_ids = get_inputs(file_name)
    fresh_count = 0
    for id in product_ids:
        _, is_good = ProductRange.find(product_ranges, id)
        if is_good:
            fresh_count += 1
    return fresh_count


def part1_brute(file_name: str) -> int:
    product_ranges, product_ids = get_inputs(file_name)
    fresh_count = 0
    for id in product_ids:
        for pr in product_ranges:
            if pr.min_id <= id <= pr.max_id:
                fresh_count += 1
                # print(f"fresh product: {id}")
                break
    return fresh_count


def part2(file_name: str) -> int:
    product_ranges, _ = get_inputs(file_name)
    # fresh_ids = set()
    fresh_count = 0
    product_ranges = ProductRange.moige(product_ranges)
    for pr in product_ranges:
        # for p in range(pr.min_id, pr.max_id + 1):
        #    fresh_ids.add(p)
        fresh_count += pr.max_id - pr.min_id + 1
    return fresh_count


def main():
    file_name = "input.txt"
    result = part1(file_name)
    print(f"Part 1 result: {result}")

    result = part1_brute(file_name)
    print(f"Part 1 brute result: {result}")

    # 336047116961610 too low
    result = part2(file_name)
    print(f"Part 2 result: {result}")


def test_part1():
    file_name = "sample.txt"
    expected = 3
    result = part1(file_name)
    assert result == expected


def test_part1_brute():
    file_name = "sample.txt"
    expected = 3
    result = part1_brute(file_name)
    assert result == expected


def test_part2():
    file_name = "sample.txt"
    expected = 14
    result = part2(file_name)
    assert result == expected


def test_load_inputs():
    file_name = "sample.txt"
    products, product_ids = get_inputs(file_name)
    assert len(products) > 1
    assert len(product_ids) == 6


"""
100 product ranges [1 - 5, 11 - 15, ..., 991 - 995]
"""


@pytest.mark.parametrize(
    "product_id, expected",
    [
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
        (1000, (99, False)),
    ],
)
def test_product_find(product_id: int, expected: Tuple[int, bool]):
    products = []
    base = 1
    for _ in range(100):
        products.append(ProductRange(base, base + 4))
        base += 10
    result = ProductRange.find(products, product_id)
    assert result == expected


if __name__ == "__main__":
    pytest.main([__file__])
    main()
