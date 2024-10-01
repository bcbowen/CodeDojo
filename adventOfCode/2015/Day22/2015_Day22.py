from pathlib import Path

def get_data_path() -> str: 
    path = str(Path(__file__).parent)
    data_path = path.replace("CodeDojo\\adventOfCode", "adventOfCodePrivateFiles")
    return data_path


class RunParams: 
    def __init__(self, player_hp, mana, boss_hp, boss_damage): 
        self.player_hp = player_hp
        self.mana = mana
        self.boss_hp = boss_hp
        self.boss_damage = boss_damage

    def __repr__(self) -> str:
        return f"player_hp: {self.player_hp}; mana: {self.mana}; boss_hp: {self.boss_hp}; boss damage: {self.boss_damage}"

    def load(player_hp, mana, file_name):
        data_path = get_data_path()
        file_path = Path(data_path, file_name).resolve()
        boss_hp = 0
        boss_damage = 0
        with open(file_path) as file: 
            text = file.read() 
            lines = text.split('\n')
            boss_hp = int(lines[0].split(':')[1])
            boss_damage = int(lines[1].split(':')[1])
            file.close()
        return RunParams(player_hp, mana, boss_hp, boss_damage)

def play_game(RunParams) -> int: 
    return 0

def main(): 
    print("Part 1")
    player_hp = 50
    mana = 500 
    params = RunParams.load(player_hp, mana, "input.txt")
    print(params)

"""
# Hope you don't be imprisoned by legacy Python code :)
from pathlib import Path

# `cwd`: current directory is straightforward
cwd = Path.cwd()

# `mod_path`: According to the accepted answer and combine with future power
# if we are in the `helper_script.py`
mod_path = Path(__file__).parent
# OR if we are `import helper_script`
mod_path = Path(helper_script.__file__).parent

# `src_path`: with the future power, it's just so straightforward
relative_path_1 = 'same/parent/with/helper/script/'
relative_path_2 = '../../or/any/level/up/'
src_path_1 = (mod_path / relative_path_1).resolve()
src_path_2 = (mod_path / relative_path_2).resolve()
"""


main()