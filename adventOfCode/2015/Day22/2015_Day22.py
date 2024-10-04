from pathlib import Path
from contextlib import redirect_stdout



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
    #min_cost = float("inf")

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
        self.spellBook = self.load_spells(); 

    def play(self, player_hp: int, mana: int, file_name: str) -> int:
        global min_cost
        min_cost = float("inf")
        params = RunParams.load(player_hp, mana, file_name) 
        self.move(params.player_hp, params.mana, params.boss_hp, {}, "LFG", params, 0)
        print(f"Lowest mana cost: {min_cost}")
        return min_cost


    def __add_effect__(self, spell: str, effects: dict[str, Spell]): 
        if spell in ["Shield", "Poison", "Recharge"]: 
            effects[spell] = self.spellBook[spell]
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
    def move(self, player_hp: int, mana: int, boss_hp: int, effects: dict[str, Spell], spell: str, params: RunParams, total_mana_cost: int):
        global min_cost
        armor = 0
        if spell != "LFG": 
            # first turn skip attacks, we just start iterating through possible move combinations
            print("-- Player turn --")
            print()
            print(f"- Player has {player_hp} hit points, {armor} armor, {mana} mana")
            print(f"- Boss has {boss_hp} hit points"); 
            key = "Shield"
            if key in effects: 
                armor += effects[key].armor
                effects[key].duration -= 1
                print(f"{key} provides {effects[key].armor} armor, raising armor to {armor}; its timer is now {effects[key].duration}")
                if effects[key].duration == 0: 
                    del effects[key]
            key = "Poison"
            if key in effects: 
                boss_hp -= effects[key].damage
                effects[key].duration -= 1
                print(f"{key} deals {effects[key].damage}; its timer is now {effects[key].duration}")
                if effects[key].duration == 0: 
                    del effects[key]
            key = "Recharge"
            if key in effects: 
                mana += effects[key].mana
                effects[key].duration -= 1
                print(f"Recharge provides {effects[key].mana} mana; its timer is now {effects[key].duration}."); 
                if effects[key].duration == 0: 
                    del effects[key]
            castSpell : Spell = self.spellBook[spell]
            print(castSpell.description)
            player_hp += castSpell.heal
            mana += castSpell.mana
            boss_hp -= castSpell.damage
            total_mana_cost += castSpell.cost
            mana -= castSpell.cost
            self.__add_effect__(spell, effects=effects)
            

            """
            Recharge provides 101 mana; its timer is now 3.
            Player casts Shield, increasing armor by 7.
            """

            print()
            print("-- Boss turn --")
            print()
            print(f"- Player has {player_hp} hit points, {armor} armor, {mana} mana")
            print(f"- Boss has {boss_hp} hit points")
            key = "Shield"
            if key in effects: 
                armor += effects[key].armor
                effects[key].duration -= 1
                print(f"{key}'s timer is now {effects[key].duration}")
                if effects[key].duration == 0: 
                    del effects[key]
            key = "Poison"
            if key in effects: 
                boss_hp -= effects[key].damage
                effects[key].duration -= 1
                print(f"{key} deals {effects[key].damage}; its timer is now {effects[key].duration}")
                if effects[key].duration == 0: 
                    del effects[key]
            key = "Recharge"
            if key in effects: 
                mana += effects[key].mana
                effects[key].duration -= 1
                print(f"Recharge provides {effects[key].mana} mana; its timer is now {effects[key].duration}."); 
                if effects[key].duration == 0: 
                    del effects[key]
            damage = max(params.boss_damage - armor, 1)
            print(f"Boss attacks for {damage} damage!")

        if boss_hp <= 0: 
            print("Player wins: boss is dead!!")
            min_cost = min(total_mana_cost, min_cost)
        elif player_hp <= 0: 
            print("Player dies")
        elif total_mana_cost > min_cost: 
            print("We've already exceeded the optimum cost, pruning!!")
        elif mana < 53: 
            print("No more mana, you lose, dickface")
        else: 
            # make some moves: 
            key = "Magic Missile"
            nextSpell = self.spellBook[key]
            if mana >= nextSpell.cost: 
                self.move(player_hp, mana, boss_hp, effects, key, params, total_mana_cost)
            
            key = "Drain"
            nextSpell = self.spellBook[key]
            if mana >= nextSpell.cost: 
                self.move(player_hp, mana, boss_hp, effects, key, params, total_mana_cost)

            key = "Shield"
            nextSpell = self.spellBook[key]    
            if mana >= nextSpell.cost: 
                self.move(player_hp, mana, boss_hp, effects, key, params, total_mana_cost)

            key = "Poison"
            nextSpell = self.spellBook[key] 
            if mana >= nextSpell.cost: 
                self.move(player_hp, mana, boss_hp, effects, key, params, total_mana_cost)
            
            key = "Recharge"
            nextSpell = self.spellBook[key] 
            if mana >= nextSpell.cost: 
                self.move(player_hp, mana, boss_hp, effects, key, params, total_mana_cost)    

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
    
    with open('output.txt', 'w') as f:
        with redirect_stdout(f):
    
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

            print("Part 1")   

            player_hp = 50
            mana = 500 

            params = RunParams.load(player_hp, mana, "input.txt")
            print(params)
            part1Result = game.play(player_hp=player_hp, mana=mana, file_name=file_name); 
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







main()