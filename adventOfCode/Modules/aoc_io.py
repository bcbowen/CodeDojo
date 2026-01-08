from pathlib import Path
import os

def input_path(year: int, day: int, file_name: str) -> Path:
    base = os.environ.get("AOC_INPUTS_DIR")
    if not base:
        raise RuntimeError(
            "Set AOC_INPUTS_DIR to your private inputs folder "
            "(e.g. ~/workspace/github.com/bcbowen/adventOfCodePrivateFiles or C:\\github\\bcbowen\\adventOfCodePrivateFiles)."
        )
    p = Path(base) / str(year) / f"Day{day:02d}/{file_name}"
    if not p.exists():
        raise FileNotFoundError(f"Input not found: {p}")
    return p

def read_input(year: int, day: int, file_name: str) -> str:
    return input_path(year, day, file_name).read_text(encoding="utf-8").rstrip("\n")