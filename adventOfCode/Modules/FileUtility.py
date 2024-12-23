from pathlib import Path

def get_input_filepath(file_name: str, caller_path: str) -> Path:
    current_path = Path(caller_path).parent
    day = current_path.name
    current_path = current_path.parent
    year = current_path.name

    # traverse up directories to the private files
    private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

    input_path = private_files_base / year / day / file_name
    return input_path