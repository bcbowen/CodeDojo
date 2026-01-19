import Modules.aoc_io
import pytest
import sys

from typing import List
from pathlib import Path
sys.path.insert(0, str(Path(__file__).resolve().parents[2]))  # repo root


def get_inputs(file_name: str) -> str:
    text = Modules.aoc_io.read_input(2016, 25, file_name)
    return text

def main(): 
    pass

if __name__ == "__main__":
    pytest.main([__file__])
    main()