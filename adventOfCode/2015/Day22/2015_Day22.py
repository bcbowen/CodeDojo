from pathlib import Path
from contextlib import redirect_stdout
import pytest
import copy
from enum import Enum

class GameState(Enum): 
    Running = 1
    PlayerWins = 2
    BossWins = 3
    TooMuchManaUsed = 4

class Stats: 
    def __init__(self, player_hp: int, mana: int, boss_hp: int, boss_damage: int, armor: int, total_mana: int, player_id: str):
        self.player_hp = player_hp
        self.mana = mana
        self.boss_hp = boss_hp 
        self.boss_damage = boss_damage
        self.armor = armor
        self.total_mana = total_mana
        self.player_id = player_id

class Spell: 
    def __init__(self, cost: int,  name: str, armor: int, damage: int, mana: int, heal: int, duration: int, description: str):
        self.cost = cost
        self.name = name
        self.armor = armor
        self.damage = damage
        self.mana = mana
        self.heal = heal
        self.duration = duration
        self.description = description

    def copy(self) -> 'Spell': 
        spell = Spell(cost = self.cost, name = self.name, armor = self.armor, damage = self.damage, mana = self.mana, heal = self.heal, duration = self.duration, description = self.description)
        return spell 


class RunParams: 
    def __init__(self, initial_player_hp: int, initial_mana: int, initial_boss_hp: int, boss_damage: int): 
        self.initial_player_hp = initial_player_hp
        self.initial_mana = initial_mana
        self.initial_boss_hp = initial_boss_hp
        self.boss_damage = boss_damage

    def __repr__(self) -> str:
        return f"player_hp: {self.initial_player_hp}; mana: {self.initial_mana}; boss_hp: {self.initial_boss_hp}; boss damage: {self.boss_damage}"

    def load(initial_player_hp, initial_mana, file_name):
        data_path = RunParams.get_data_path()
        file_path = Path(data_path, file_name).resolve()
        initial_boss_hp = 0
        boss_damage = 0
        with open(file_path) as file: 
            text = file.read() 
            lines = text.split('\n')
            initial_boss_hp = int(lines[0].split(':')[1])
            boss_damage = int(lines[1].split(':')[1])
            file.close()
        return RunParams(initial_player_hp, initial_mana, initial_boss_hp, boss_damage)
    
    def get_data_path() -> str: 
        path = str(Path(__file__).parent)
        data_path = path.replace("CodeDojo\\adventOfCode", "adventOfCodePrivateFiles")
        return data_path

class Game: 
    """
    - Magic Missile costs 53 mana. It instantly does 4 damage.
    - Drain costs 73 mana. It instantly does 2 damage and heals you for 2 hit points.
    - Shield costs 113 mana. It starts an effect that lasts for 6 turns. While it is active, your armor is increased by 7.
    - Poison costs 173 mana. It starts an effect that lasts for 6 turns. At the start of each turn while it is active, it deals the boss 3 damage.
    - Recharge costs 229 mana. It starts an effect that lasts for 5 turns. At the start of each turn while it is active, it gives you 101 new mana.
    """
    def load_spells(self) -> dict[str, Spell]: 
        spellBook = {}
        spellBook["Magic Missile"] = Spell(cost=53, name="Magic Missile", armor=0, damage=4, mana=0, heal=0, duration=0, description="Player casts Magic Missile for 53 mana, causing 4 damage")
        spellBook["Drain"] = Spell(cost=73, name="Drain", armor=0, damage=2, mana=0, heal=2, duration=0, description="Player casts Drain for 73 mana, causing 2 damage and healing for 2")
        spellBook["Shield"] = Spell(cost=113, name="Shield", armor=7, damage=0, mana=0, heal=0, duration=6, description="Player casts Shield for 113 mana, providing 7 armor and lasting for 6 turns")
        spellBook["Poison"] = Spell(cost=173, name="Poison", armor=0, damage=3, mana=0, heal=0, duration=6, description="Player casts Poison for 173 mana, causing 3 damage per turn lasting 6 turns")
        spellBook["Recharge"] = Spell(cost=229, name="Recharge", armor=0, damage=0, mana=101, heal=0, duration=5, description="Player casts Recharge for 229 mana, increasing mana by 101 and lasting for 5 turns")
        
        return spellBook

    def __init__(self): 
        self.min_cost = float("inf")
        self.next_id = 1
        self.min_cost_log = []
        self.spellBook = self.load_spells()
        self.hard_mode = False
        self.verbose = False

    def play(self, initial_player_hp: int, initial_mana: int, file_name: str, hard_mode : bool = False, verbose : bool = False) -> tuple[int, list[str]]:
        self.min_cost = float("inf")
        self.hard_mode = hard_mode
        self.verbose = verbose
        self.min_cost_log = []
        params = RunParams.load(initial_player_hp, initial_mana, file_name) 
        stats = Stats(initial_player_hp, initial_mana, params.initial_boss_hp, params.boss_damage, armor=0, total_mana=0, player_id="")
        self.move(stats=stats, effects={}, spell="LFG", output=[])
        #print(f"Lowest mana cost: {self.min_cost}")
        return (self.min_cost, self.min_cost_log)

    def check_run_state(self, stats: Stats, output: list[str], check_mana: bool) -> GameState: 
        min_mana = self.spellBook["Magic Missile"].cost
        if stats.player_hp < 1: 
            output.append(f"Boss wins! Player is dead! Hasta la vista, buddy")
            if self.verbose: 
                self.take_a_dump(stats.player_id, output)
            return GameState.BossWins
        if stats.mana < min_mana and check_mana: 
            output.append(f"Boss wins! Player doesn't have enough mana! Should have eaten your Wheaties!")
            if self.verbose: 
                self.take_a_dump(stats.player_id, output)
            return GameState.BossWins
        if stats.boss_hp < 1: 
            output.append("Player wins! Boss is dead! And there was much rejoicing!")
            if self.verbose: 
                self.take_a_dump(stats.player_id, output)

            if stats.total_mana < self.min_cost: 
                output.append(f"New min mana cost: {stats.total_mana}")
                self.min_cost = stats.total_mana
                self.min_cost_log = output.copy()
            elif self.verbose: 
                self.take_a_dump(stats.player_id, output)
            return GameState.PlayerWins
        if stats.total_mana > self.min_cost: 
            output.append(f"Min mana already exceeded. Min: {self.min_cost}; Current Total: {stats.total_mana}")
            if self.verbose: 
                self.take_a_dump(stats.player_id, output)
            return GameState.TooMuchManaUsed
        return GameState.Running

    def __add_effect__(self, spell: str, effects: dict[str, Spell]): 
        if spell in ["Shield", "Poison", "Recharge"]:
            copySpell = self.spellBook[spell].copy()
            effects[spell] = Spell(cost=copySpell.cost, name=copySpell.name, armor=copySpell.armor, damage=copySpell.damage, mana=copySpell.mana, heal=copySpell.heal, duration=copySpell.duration, description=copySpell.description)
 
    def write_stats(self, stats: Stats, output: list[str]):
        output.append(f"- Player has {stats.player_hp} hit points, {stats.armor} armor, {stats.mana} mana. Mana used: {stats.total_mana}")
        output.append(f"- Boss has {stats.boss_hp} hit points");

    def apply_effects(self, stats: Stats, effects: dict[str, Spell], output: list[str]) -> GameState:
            key = "Shield"
            if key in effects: 
                stats.armor = effects[key].armor
                effects[key].duration -= 1
                output.append(f"{key} provides {effects[key].armor} armor, raising armor to {stats.armor}; its timer is now {effects[key].duration}")
                if effects[key].duration < 1: 
                    del effects[key]
            else: 
                stats.armor = 0

            key = "Poison"
            if key in effects: 
                stats.boss_hp -= effects[key].damage
                effects[key].duration -= 1
                output.append(f"{key} deals {effects[key].damage}; its timer is now {effects[key].duration}")
                if effects[key].duration < 1: 
                    del effects[key]
                if self.check_run_state(stats, output, False) == GameState.PlayerWins: 
                    return GameState.PlayerWins
            key = "Recharge"
            if key in effects: 
                stats.mana += effects[key].mana
                effects[key].duration -= 1
                output.append(f"Recharge provides {effects[key].mana} mana; its timer is now {effects[key].duration}."); 
                if effects[key].duration < 1: 
                    del effects[key]

            return GameState.Running

    def move(self, stats: Stats, effects: dict[str, Spell], spell: str, output: list[str]):
        #updated_effects = copy.deepcopy(effects)
        if spell != "LFG": 
            # first turn skip attacks, we just start iterating through possible move combinations

            output.append("-- Player turn --")
            output.append(" ")
            if self.hard_mode: 
                output.append("- Hard Mode! Player loses 1 hp per turn!")
                stats.player_hp -= 1
                if self.check_run_state(stats=stats, output=output, check_mana=False) == GameState.BossWins: 
                    return
            self.write_stats(stats=stats, output=output)
            
            if self.apply_effects(stats=stats, effects=effects, output=output) == GameState.PlayerWins: 
                return
            
            castSpell : Spell = self.spellBook[spell].copy()
            output.append(castSpell.description)
            stats.total_mana += castSpell.cost
            stats.mana -= castSpell.cost
            if spell not in ["Shield", "Poison", "Recharge"]: 
                # This spell has instant effect, the others are over time and start next turn
                stats.player_hp += castSpell.heal
                stats.mana += castSpell.mana
                stats.boss_hp -= castSpell.damage
                if self.check_run_state(stats=stats, output=output, check_mana=False) != GameState.Running: 
                    return
            
            self.__add_effect__(spell, effects=effects)
            
            output.append(" ")
            output.append("-- Boss turn --")
            output.append(" ")
            self.write_stats(stats=stats, output=output)
            if self.apply_effects(stats=stats, effects=effects, output=output) == GameState.PlayerWins: 
                return
            damage = max(stats.boss_damage - stats.armor, 1)
            output.append(f"Boss attacks for {damage} damage!")
            stats.player_hp -= damage
            if self.check_run_state(stats=stats, output=output, check_mana=False) != GameState.Running: 
                return

        if self.check_run_state(stats=stats, output=output, check_mana=True) != GameState.Running: 
            return

        for key in self.spellBook: 
            nextSpell = self.spellBook[key].copy()
            if stats.mana >= nextSpell.cost and not key in effects: 
                #stats.player_id += f"{key[0]}_" 
                nextStats = copy.deepcopy(stats)
                nextStats.player_id += f"{key[0]}_"
                self.move(stats=nextStats, effects=copy.deepcopy(effects), spell=key, output=output.copy())
            

    def take_a_dump(self, player_id: int, log: list[str]): 
        path = Path(Path(__file__).parent, f"dump_{player_id}.txt").resolve()
        with open(path, 'w') as f:
            for line in log: 
                f.write(line + '\n')
            f.close()

def part1(): 
    game = Game()
    path = Path(Path(__file__).parent, "part1.txt").resolve()
    with open(path, 'w') as f:
        with redirect_stdout(f):
            print("Part 1")   
            player_hp = 50
            mana = 500 
            file_name = "input.txt"
            part1Result, log = game.play(initial_player_hp=player_hp, initial_mana=mana, file_name=file_name,hard_mode=False); 
            for line in log: 
                print(line)
            print(f"Part 1 result: {part1Result}")


def part2(): 
    game = Game()
    path = Path(Path(__file__).parent, "part2.txt").resolve()
    with open(path, 'w') as f:
        with redirect_stdout(f):
            print("Part 2")   
            player_hp = 50
            mana = 500 
            file_name = "input.txt"
            part2Result, log = game.play(initial_player_hp=player_hp, initial_mana=mana, file_name=file_name, hard_mode=True); 
            for line in log: 
                print(line)
            print(f"Part 2 result: {part2Result}")


@pytest.mark.parametrize("name, player_hp, mana, file_name, expected, verbose", [
    ("test1", 10, 250, "sample1.txt", 226, False),
    ("test2", 10, 250, "sample2.txt", 641, False)
])
def test_wiz_part1(name: str, player_hp: int, mana: int, file_name: str, expected: int, verbose: bool):
    print(f"*** TEST {name}***")
    game = Game()
    path = Path(Path(__file__).parent, f"{name}.txt").resolve()
    with open(path, 'w') as f:
        with redirect_stdout(f):
            result, output = game.play(initial_player_hp=player_hp, initial_mana=mana, file_name=file_name,hard_mode=False, verbose=verbose); 
            for line in output: 
                print(line)
            assert result == expected

if __name__ == "__main__":
    pytest.main([__file__])
    part1()
    part2()