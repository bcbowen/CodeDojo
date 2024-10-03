from pathlib import Path

min_cost = float("inf")

def get_data_path() -> str: 
    path = str(Path(__file__).parent)
    data_path = path.replace("CodeDojo\\adventOfCode", "adventOfCodePrivateFiles")
    return data_path


class Effect: 
    def __init__(self, name: str, armor: int, damage: int, mana: int, duration: int):
        self.name = name
        self.armor = armor
        self.damage = damage
        self.mana = mana
        self.duration = duration


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

def play_game(params: RunParams) -> int: 
    move(params.player_hp, params.mana, params.boss_hp, {}, "LFG", params, 0)
    print(f"Lowest mana cost: {min_cost}")
    return min_cost
"""
- Magic Missile costs 53 mana. It instantly does 4 damage.
- Drain costs 73 mana. It instantly does 2 damage and heals you for 2 hit points.
- Shield costs 113 mana. It starts an effect that lasts for 6 turns. While it is active, your armor is increased by 7.
- Poison costs 173 mana. It starts an effect that lasts for 6 turns. At the start of each turn while it is active, it deals the boss 3 damage.
- Recharge costs 229 mana. It starts an effect that lasts for 5 turns. At the start of each turn while it is active, it gives you 101 new mana.
"""
def move(player_hp: int, player_mana: int, boss_hp: int, effects: dict[Effect], spell: str, params: RunParams, total_mana_cost: int):

    missile_cost = 53
    drain_cost = 73
    shield_cost = 113
    poison_cost = 173
    recharge_cost = 229

    armor_bonus = 0
    global min_cost
    print(f"move: player {player_hp} hp, {player_mana} mana; boss: {boss_hp} hp; casting {spell}")
    # apply effects: 
    depleted = [] 
    for key, item in effects.items(): 
        match key: 
            case "Shield": 
                armor_bonus += 7
            case "Poison":
                boss_hp -= 3
            case "Recharge": 
                player_mana += 101
        item.duration -= 1
        if item.duration < 1: 
            depleted.append(key)
    # remove depleted effects 
    for key in depleted: 
        del effects[key]
    #apply spell: 
    cost = 0
    match spell: 
        case "Magic Missile": 
            cost = missile_cost
            boss_hp -= 4
        case "Drain": 
            cost = drain_cost
            player_hp += 2
            boss_hp -= 2
        case "Shield": 
            cost = shield_cost
            armor_bonus += 7
            effects[spell] = Effect(spell, 7, 0, 0, 5)
        case "Poison": 
            cost = poison_cost
            effects[spell] = Effect(spell, 0, 3, 0, 6)
        case "Recharge": 
            cost = recharge_cost
            effects[spell] = Effect(spell, 0, 0, 101, 5)
    total_mana_cost += cost
    player_mana -= cost

    # boss attacks 
    if spell != "LFG": 
        # boss doesn't attack on the first turn
        damage = max(params.boss_damage - armor_bonus, 1)
        player_hp -= damage
        print(f"Boss hits for {damage} hp"); 

    if boss_hp <= 0: 
        print("Player wins: boss is dead!!")
        min_cost = min(total_mana_cost, min_cost)
    elif player_hp <= 0: 
        print("Player dies")
    elif total_mana_cost > min_cost: 
        print("We've already exceeded the optimum cost, pruning!!")
    elif player_mana < 53: 
        print("No more mana, you lose, dickface")
    else: 
        # make some moves: 
        if player_mana >= missile_cost: 
            move(player_hp, player_mana, boss_hp, effects, "Magic Missile", params, total_mana_cost)
        if player_mana >= drain_cost: 
            move(player_hp, player_mana, boss_hp, effects, "Drain", params, total_mana_cost)
        if player_mana >= shield_cost and not "Shield" in effects: 
            move(player_hp, player_mana, boss_hp, effects, "Shield", params, total_mana_cost)
        if player_mana >= poison_cost and not "Poison" in effects: 
            move(player_hp, player_mana, boss_hp, effects, "Poison", params, total_mana_cost)
        if player_mana >= recharge_cost and not "Recharge" in effects: 
            move(player_hp, player_mana, boss_hp, effects, "Recharge", params, total_mana_cost)    

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
    print("Part 1")
    player_hp = 50
    mana = 500 
    params = RunParams.load(player_hp, mana, "input.txt")
    print(params)
    part1Result = play_game(params)

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


    test1Params = RunParams(player_hp = 10, mana = 250, boss_hp = 13, boss_damage = 8)
    expected = 226
    print("Test 1, 226 expected")
    result = play_game(test1Params)
    if result != expected: 
        print(f"FAIL!! Expected {expected}, result: {result}")
    else: 
        print("Test 1 PASS")




main()