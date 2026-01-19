import pytest
import sys
from pathlib import Path
sys.path.insert(0, str(Path(__file__).resolve().parents[2]))  # repo root
import Modules.aoc_io

def main(): 
    pass

if __name__ == "__main__":
    pytest.main([__file__])
    main()