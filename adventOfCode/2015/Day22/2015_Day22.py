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
"""
- Magic Missile costs 53 mana. It instantly does 4 damage.
- Drain costs 73 mana. It instantly does 2 damage and heals you for 2 hit points.
- Shield costs 113 mana. It starts an effect that lasts for 6 turns. While it is active, your armor is increased by 7.
- Poison costs 173 mana. It starts an effect that lasts for 6 turns. At the start of each turn while it is active, it deals the boss 3 damage.
- Recharge costs 229 mana. It starts an effect that lasts for 5 turns. At the start of each turn while it is active, it gives you 101 new mana.
"""
def move(player_hp: int, player_mana: int, boss_hp: int, effects: dict[Effect], spell: str, params: RunParams, total_mana_cost: int):

    armor_bonus = 0
    global min_cost
    
    # apply effects: 
    for key, item in effects: 
        match key: 
            case "Shield": 
                armor_bonus += 7
            case "Poison":
                boss_hp -= 3
            case "Recharge": 
                player_mana += 101
        item.duration -= 1
        if item.duration < 1: 
            del effects[key]
    #apply spell: 
    cost = 0
    match spell: 
        case "Magic Missile": 
            cost = 53
            boss_hp -= 4
        case "Drain": 
            cost = 73
            player_hp += 2
            boss_hp -= 2
        case "Shield": 
            cost = 113
            armor_bonus += 7
            effects[spell] = Effect(spell, 7, 0, 0, 5)
        case "Poison": 
            cost = 173
            effects[spell] = Effect(spell, 0, 3, 0, 6)
        case "Recharge": 
            cost = 229
            effects[spell] = Effect(spell, 0, 0, 101, 5)
    total_mana_cost += cost
    player_mana -= cost

    # boss attacks 
    player_hp -= max(params.boss_damage - armor_bonus, 1)

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
        if player_mana >= 53: 
            move(player_hp, player_mana, boss_hp, effects, "Magic Missile", params, total_mana_cost)
        if player_mana >= 73: 
            move(player_hp, player_mana, boss_hp, effects, "Drain", params, total_mana_cost)
        if player_mana >= 113 and not "Shield" in effects: 
            move(player_hp, player_mana, boss_hp, effects, "Shield", params, total_mana_cost)
        if player_mana >= 173 and not "Poison" in effects: 
            move(player_hp, player_mana, boss_hp, effects, "Poison", params, total_mana_cost)
        if player_mana >= 229 and not "Recharge" in effects: 
            move(player_hp, player_mana, boss_hp, effects, "Recharge", params, total_mana_cost)    


def main(): 
    print("Part 1")
    player_hp = 50
    mana = 500 
    params = RunParams.load(player_hp, mana, "input.txt")
    print(params)
    play_game(params)


main()