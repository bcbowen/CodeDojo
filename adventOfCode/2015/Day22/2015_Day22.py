from pathlib import Path
from contextlib import redirect_stdout
import pytest
import copy


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
        spell = Spell(cost = self.cost, name = self.name, armor = self.armor, damage = self.damage, mana = self.mana, heal  = self.heal, duration = self.duration, description = self.description)
        return spell 


class RunParams: 
    def __init__(self, player_hp: int, mana: int, boss_hp: int, boss_damage: int): 
        self.player_hp = player_hp
        self.mana = mana
        self.boss_hp = boss_hp
        self.boss_damage = boss_damage

    def __repr__(self) -> str:
        return f"player_hp: {self.player_hp}; mana: {self.mana}; boss_hp: {self.boss_hp}; boss damage: {self.boss_damage}"

    def load(player_hp, mana, file_name):
        data_path = RunParams.get_data_path()
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
        spellBook["Magic Missile"] = Spell(cost=53, name="Magic Missile", armor=0, damage=4, mana=0, heal=0, duration=0, description="Player casts Magic Missile, causing 4 damage")
        spellBook["Drain"] = Spell(cost=73, name="Drain", armor=0, damage=2, mana=0, heal=2, duration=0, description="Player casts Drain, causing 2 damage and healing for 2")
        spellBook["Shield"] = Spell(cost=113, name="Shield", armor=7, damage=0, mana=0, heal=0, duration=6, description="Player casts Shield, providing 6 armor and lasting for 6 turns")
        spellBook["Poison"] = Spell(cost=173, name="Poison", armor=0, damage=3, mana=0, heal=0, duration=6, description="Player casts Poison, causing 3 damage per turn lasting 6 turns")
        spellBook["Recharge"] = Spell(cost=229, name="Recharge", armor=0, damage=0, mana=101, heal=0, duration=5, description="Player casts Recharge, increasing mana by 101 and lasting for 5 turns")
        
        return spellBook

    def __init__(self): 
        self.min_cost = float("inf")
        self.next_id = 1
        self.min_cost_log = []
        self.spellBook = self.load_spells()
        self.hardMode = False

    def play(self, player_hp: int, mana: int, file_name: str, hardMode : bool = False) -> tuple[int, list[str]]:
        self.min_cost = float("inf")
        self.hardMode = hardMode
        self.min_cost_log = []
        params = RunParams.load(player_hp, mana, file_name) 
        self.move(player_hp=params.player_hp, mana=params.mana, boss_hp=params.boss_hp, effects={}, spell="LFG", params=params, total_mana_cost=0, player_id=0, output=[])
        #print(f"Lowest mana cost: {self.min_cost}")
        return (self.min_cost, self.min_cost_log)


    def __add_effect__(self, spell: str, effects: dict[str, Spell]): 
        if spell in ["Shield", "Poison", "Recharge"]:
            copySpell = self.spellBook[spell].copy()
            effects[spell] = Spell(cost=copySpell.cost, name=copySpell.name, armor=copySpell.armor, damage=copySpell.damage, mana=copySpell.mana, heal=copySpell.heal, duration=copySpell.duration, description=copySpell.description)
 
    def move(self, player_hp: int, mana: int, boss_hp: int, effects: dict[str, Spell], spell: str, params: RunParams, total_mana_cost: int, player_id: int, output: list[str]):
        armor = 0
        updated_effects = copy.deepcopy(effects)
        if spell != "LFG": 
            # first turn skip attacks, we just start iterating through possible move combinations

            output.append("-- Player turn --")
            if self.hardMode: 
                output.append("- Hard Mode! Player loses 1 hp per turn!")
                player_hp -= 1
                if player_hp < 1: 
                    output.append(f"Player {player_id} dies")
                    return
            output.append(" ")
            output.append(f"- Player has {player_hp} hit points, {armor} armor, {mana} mana")
            output.append(f"- Boss has {boss_hp} hit points");
             
            key = "Shield"
            if key in updated_effects: 
                armor += updated_effects[key].armor
                updated_effects[key].duration -= 1
                output.append(f"{key} provides {updated_effects[key].armor} armor, raising armor to {armor}; its timer is now {updated_effects[key].duration}")
                if updated_effects[key].duration < 1: 
                    del updated_effects[key]
            key = "Poison"
            if key in updated_effects: 
                boss_hp -= updated_effects[key].damage
                updated_effects[key].duration -= 1
                output.append(f"{key} deals {updated_effects[key].damage}; its timer is now {updated_effects[key].duration}")
                if updated_effects[key].duration < 1: 
                    del updated_effects[key]
            key = "Recharge"
            if key in updated_effects: 
                mana += updated_effects[key].mana
                updated_effects[key].duration -= 1
                output.append(f"Recharge provides {updated_effects[key].mana} mana; its timer is now {updated_effects[key].duration}."); 
                if updated_effects[key].duration < 1: 
                    del updated_effects[key]
            castSpell : Spell = self.spellBook[spell].copy()
            output.append(castSpell.description)
            if spell not in ["Shield", "Poison", "Recharge"]: 
                # This spell has instant effect, the others are over time and start next turn
                player_hp += castSpell.heal
                mana += castSpell.mana
                boss_hp -= castSpell.damage
            total_mana_cost += castSpell.cost
            mana -= castSpell.cost
            self.__add_effect__(spell, effects=updated_effects)
            
            output.append(" ")
            output.append("-- Boss turn --")
            output.append(" ")
            output.append(f"- Player has {player_hp} hit points, {armor} armor, {mana} mana")
            output.append(f"- Boss has {boss_hp} hit points")
            key = "Shield"
            if key in updated_effects: 
                armor += updated_effects[key].armor
                updated_effects[key].duration -= 1
                output.append(f"{key}'s timer is now {updated_effects[key].duration}")
                if updated_effects[key].duration < 1: 
                    del updated_effects[key]
            key = "Poison"
            if key in updated_effects: 
                boss_hp -= updated_effects[key].damage
                updated_effects[key].duration -= 1
                output.append(f"{key} deals {updated_effects[key].damage}; its timer is now {updated_effects[key].duration}")
                if updated_effects[key].duration < 1: 
                    del updated_effects[key]
            key = "Recharge"
            if key in updated_effects: 
                mana += updated_effects[key].mana
                updated_effects[key].duration -= 1
                output.append(f"Recharge provides {updated_effects[key].mana} mana; its timer is now {updated_effects[key].duration}."); 
                if updated_effects[key].duration < 1: 
                    del updated_effects[key]
            damage = max(params.boss_damage - armor, 1)
            output.append(f"Boss attacks for {damage} damage!")
            player_hp -= damage


        if boss_hp <= 0: 
            output.append(f"Player {player_id} wins: boss is dead!!")
            if total_mana_cost < self.min_cost: 
                output.append(f"New min mana cost: {total_mana_cost}")
                self.min_cost = total_mana_cost
                self.min_cost_log = output.copy()
        elif player_hp <= 0: 
            output.append(f"Player {player_id} dies")
            #self.take_a_dump(player_id, output)
        elif total_mana_cost > self.min_cost: 
            output.append(f"We've already exceeded the optimum cost of {self.min_cost}, pruning {player_id}!!")
            #self.take_a_dump(player_id, output)
        elif mana < 53: 
            output.append(f"No more mana, you lose, dickface {player_id}")
            #self.take_a_dump(player_id, output)
        else: 
            # make some moves: 
            key = "Magic Missile"
            nextSpell = self.spellBook[key].copy()
            if mana >= nextSpell.cost: 
                if spell == "LFG":
                    player_id += 1 
                self.move(player_hp, mana, boss_hp, updated_effects, key, params, total_mana_cost, player_id, output.copy())
            
            key = "Drain"
            nextSpell = self.spellBook[key].copy()
            if mana >= nextSpell.cost: 
                if spell == "LFG":
                    player_id += 1
                self.move(player_hp, mana, boss_hp, updated_effects, key, params, total_mana_cost, player_id, output.copy())

            key = "Shield"
            nextSpell = self.spellBook[key].copy()
            if mana >= nextSpell.cost:
                if spell == "LFG":
                    player_id += 1 
                self.move(player_hp, mana, boss_hp, updated_effects, key, params, total_mana_cost, player_id, output.copy())

            key = "Poison"
            nextSpell = self.spellBook[key].copy()
            if mana >= nextSpell.cost:
                if spell == "LFG":
                    player_id += 1 
                self.move(player_hp, mana, boss_hp, updated_effects, key, params, total_mana_cost, player_id, output.copy())
            
            key = "Recharge"
            nextSpell = self.spellBook[key].copy() 
            if mana >= nextSpell.cost:
                if spell == "LFG":
                    player_id += 1 
                self.move(player_hp, mana, boss_hp, updated_effects, key, params, total_mana_cost, player_id, output.copy())    

    def take_a_dump(self, player_id: int, log: list[str]): 
        path = Path(Path(__file__).parent, f"dump_{player_id}.txt").resolve()
        with open(path, 'w') as f:
            for line in log: 
                f.write(line + '\n')
            f.close()

def part1(): 
    game = Game()
    path = Path(Path(__file__).parent, "output.txt").resolve()
    with open(path, 'w') as f:
        with redirect_stdout(f):
            print("Part 1")   

            player_hp = 50
            mana = 500 
            file_name = "input.txt"
            params = RunParams.load(player_hp, mana, file_name)
            #print(params)
            part1Result, log = game.play(player_hp=player_hp, mana=mana, file_name=file_name); 
            for line in log: 
                print(line)
            print(f"Part 1 result: {part1Result}")


def part2(): 
    game = Game()
    path = Path(Path(__file__).parent, "output.txt").resolve()
    with open(path, 'w') as f:
        with redirect_stdout(f):
            print("Part 2")   

            player_hp = 50
            mana = 500 
            file_name = "input.txt"
            params = RunParams.load(player_hp, mana, file_name)
            #print(params)
            part2Result, log = game.play(player_hp=player_hp, mana=mana, file_name=file_name, hardMode=True); 
            for line in log: 
                print(line)
            print(f"Part 2 result: {part2Result}")


@pytest.mark.parametrize("name, player_hp, mana, file_name, expected", [
    ("test1", 10, 250, "sample1.txt", 226),
    ("test2", 10, 250, "sample2.txt", 641)
])
def test_wiz_part1(name: str, player_hp: int, mana: int, file_name: str, expected: int):
    print(f"*** TEST {name}***")
    game = Game()
    result, output = game.play(player_hp=player_hp, mana=mana, file_name=file_name); 
    for line in output: 
        print(line)
    assert result == expected

if __name__ == "__main__":
    pytest.main([__file__])
    #part1()
    part2()