from pathlib import Path
from contextlib import redirect_stdout
import pytest


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
        self.spellBook = self.load_spells(); 

    def play(self, player_hp: int, mana: int, file_name: str) -> tuple[int, list[str]]:
        self.min_cost = float("inf")
        self.min_cost_log = []
        params = RunParams.load(player_hp, mana, file_name) 
        self.move(player_hp=params.player_hp, mana=params.mana, boss_hp=params.boss_hp, effects={}, spell="LFG", params=params, total_mana_cost=0, player_id=0, output=[])
        #print(f"Lowest mana cost: {self.min_cost}")
        return (self.min_cost, self.min_cost_log)


    def __add_effect__(self, spell: str, effects: dict[str, Spell]): 
        if spell in ["Shield", "Poison", "Recharge"]:
            copySpell  = self.spellBook[spell] 
            effects[spell] = Spell(cost=copySpell.cost, name=copySpell.name, armor=copySpell.armor, damage=copySpell.damage, mana=copySpell.mana, heal=copySpell.heal, duration=copySpell.duration, description=copySpell.description)
    """
    -- Player turn --

    - Player has 10 hit points, 0 armor, 250 mana
    - Boss has 14 hit points
    Player casts Recharge.

    -- Boss turn --

    - Player has 10 hit points, 0 armor, 21 mana
    - Boss has 14 hit points
    Recharge provides 101 mana; its timer is now 4.
    Boss attacks for 8 damage!
    """
    def move(self, player_hp: int, mana: int, boss_hp: int, effects: dict[str, Spell], spell: str, params: RunParams, total_mana_cost: int, player_id: int, output: list[str]):
        armor = 0
        updated_effects = effects.copy()
        if spell != "LFG": 
            # first turn skip attacks, we just start iterating through possible move combinations

            output.append("-- Player turn --")
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
            castSpell : Spell = self.spellBook[spell]
            output.append(castSpell.description)
            if spell not in ["Shield", "Poison", "Recharge"]: 
                # This spell has instant effect, the others are over time and start next turn
                player_hp += castSpell.heal
                mana += castSpell.mana
                boss_hp -= castSpell.damage
            total_mana_cost += castSpell.cost
            mana -= castSpell.cost
            self.__add_effect__(spell, effects=updated_effects)
            

            """
            Recharge provides 101 mana; its timer is now 3.
            Player casts Shield, increasing armor by 7.
            """

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
            self.take_a_dump(player_id, output)
        elif total_mana_cost > self.min_cost: 
            output.append(f"We've already exceeded the optimum cost of {self.min_cost}, pruning {player_id}!!")
            self.take_a_dump(player_id, output)
        elif mana < 53: 
            output.append(f"No more mana, you lose, dickface {player_id}")
            self.take_a_dump(player_id, output)
        else: 
            # make some moves: 
            key = "Magic Missile"
            nextSpell = self.spellBook[key]
            if mana >= nextSpell.cost: 
                if spell == "LFG":
                    player_id += 1 
                self.move(player_hp, mana, boss_hp, updated_effects, key, params, total_mana_cost, player_id, output.copy())
            
            key = "Drain"
            nextSpell = self.spellBook[key]
            if mana >= nextSpell.cost: 
                if spell == "LFG":
                    player_id += 1
                self.move(player_hp, mana, boss_hp, updated_effects, key, params, total_mana_cost, player_id, output.copy())

            key = "Shield"
            nextSpell = self.spellBook[key]    
            if mana >= nextSpell.cost:
                if spell == "LFG":
                    player_id += 1 
                self.move(player_hp, mana, boss_hp, updated_effects, key, params, total_mana_cost, player_id, output.copy())

            key = "Poison"
            nextSpell = self.spellBook[key] 
            if mana >= nextSpell.cost:
                if spell == "LFG":
                    player_id += 1 
                self.move(player_hp, mana, boss_hp, updated_effects, key, params, total_mana_cost, player_id, output.copy())
            
            key = "Recharge"
            nextSpell = self.spellBook[key] 
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
"""


Now, suppose the same initial conditions, except that the boss has 14 hit points instead:

```
-- Player turn --

- Player has 10 hit points, 0 armor, 250 mana
- Boss has 14 hit points
  Player casts Recharge.

-- Boss turn --

- Player has 10 hit points, 0 armor, 21 mana
- Boss has 14 hit points
  Recharge provides 101 mana; its timer is now 4.
  Boss attacks for 8 damage!

-- Player turn --

- Player has 2 hit points, 0 armor, 122 mana
- Boss has 14 hit points
  Recharge provides 101 mana; its timer is now 3.
  Player casts Shield, increasing armor by 7.

-- Boss turn --

- Player has 2 hit points, 7 armor, 110 mana
- Boss has 14 hit points
  Shield's timer is now 5.
  Recharge provides 101 mana; its timer is now 2.
  Boss attacks for 8 - 7 = 1 damage!

-- Player turn --

- Player has 1 hit point, 7 armor, 211 mana
- Boss has 14 hit points
  Shield's timer is now 4.
  Recharge provides 101 mana; its timer is now 1.
  Player casts Drain, dealing 2 damage, and healing 2 hit points.

-- Boss turn --

- Player has 3 hit points, 7 armor, 239 mana
- Boss has 12 hit points
  Shield's timer is now 3.
  Recharge provides 101 mana; its timer is now 0.
  Recharge wears off.
  Boss attacks for 8 - 7 = 1 damage!

-- Player turn --

- Player has 2 hit points, 7 armor, 340 mana
- Boss has 12 hit points
  Shield's timer is now 2.
  Player casts Poison.

-- Boss turn --

- Player has 2 hit points, 7 armor, 167 mana
- Boss has 12 hit points
  Shield's timer is now 1.
  Poison deals 3 damage; its timer is now 5.
  Boss attacks for 8 - 7 = 1 damage!

-- Player turn --

- Player has 1 hit point, 7 armor, 167 mana
- Boss has 9 hit points
  Shield's timer is now 0.
  Shield wears off, decreasing armor by 7.
  Poison deals 3 damage; its timer is now 4.
  Player casts Magic Missile, dealing 4 damage.

-- Boss turn --

- Player has 1 hit point, 0 armor, 114 mana
- Boss has 2 hit points
  Poison deals 3 damage. This kills the boss, and the player wins.
```

"""



def main(): 
    game = Game()
    path = Path(Path(__file__).parent, "output.txt").resolve()
    with open(path, 'w') as f:
        with redirect_stdout(f):
            """
            print("Part 1 Test 1")
            player_hp = 10
            mana = 250
            file_name = "sample1.txt"
            expected = 226
            result = game.play(player_hp=player_hp, mana=mana, file_name=file_name); 
            print(f"Test 1, {expected} expected")

            if result != expected: 
                print(f"FAIL!! expected: {expected}, result: {result}")
            else: 
                print("Test 1 PASS")

            print("Part 1 Test 2")
            player_hp = 10
            mana = 250
            file_name = "sample2.txt"
            expected = 229 + 113 + 73 + 173 + 53

            result = game.play(player_hp=player_hp, mana=mana, file_name=file_name); 
            print(f"Test 2, {expected} expected")

            if result != expected: 
                print(f"FAIL!! expected: {expected}, result: {result}")
            else: 
                print("Test 2 PASS")
            """
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

    """
    -- Player turn --

    - Player has 10 hit points, 0 armor, 250 mana
    - Boss has 13 hit points
    Player casts Poison. 
    (173)

    -- Boss turn --

    - Player has 10 hit points, 0 armor, 77 mana
    - Boss has 13 hit points
    Poison deals 3 damage; its timer is now 5.
    Boss attacks for 8 damage.

    -- Player turn --

    - Player has 2 hit points, 0 armor, 77 mana
    - Boss has 10 hit points
    Poison deals 3 damage; its timer is now 4.
    Player casts Magic Missile, dealing 4 damage.
    (53)

    -- Boss turn --

    - Player has 2 hit points, 0 armor, 24 mana
    - Boss has 3 hit points
    Poison deals 3 damage. This kills the boss, and the player wins.
    ```"""

"""
 print("Part 1 Test 1")
            player_hp = 10
            mana = 250
            file_name = "sample1.txt"
            expected = 226
            result = game.play(player_hp=player_hp, mana=mana, file_name=file_name); 
            print(f"Test 1, {expected} expected")
"""


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
    main()