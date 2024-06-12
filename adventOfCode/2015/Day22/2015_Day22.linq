<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	//RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
	Part1();
	Part2();
}

const int PlayerWins = -1;
const int BossWins = 1;

public class Spell
{
	/*
	Magic Missile costs 53 mana. It instantly does 4 damage.
	Drain costs 73 mana. It instantly does 2 damage and heals you for 2 hit points.
	Shield costs 113 mana. It starts an effect that lasts for 6 turns. While it is active, your armor is increased by 7.
	Poison costs 173 mana. It starts an effect that lasts for 6 turns. At the start of each turn while it is active, it deals the boss 3 damage.
	Recharge costs 229 mana. It starts an effect that lasts for 5 turns. At the start of each turn while it is active, it gives you 101 new mana.
	*/

	public static List<Spell> InitSpells()
	{
		List<Spell> spells = new List<Spell>();

		spells.Add(new Spell("Magic Missile", 53, 4, 0, 0, 1));
		spells.Add(new Spell("Drain", 73, 2, 2, 0, 1));
		spells.Add(new Spell("Shield", 113, 0, 7, 0, 6));
		spells.Add(new Spell("Poison", 173, 3, 0, 0, 6));
		spells.Add(new Spell("Recharge", 101, 0, 0, 0, 5));

		return spells;
	}

	public Spell(string name, int manaCost, int damagePerTurn, int healPerTurn, int regenPerTurn, int turnCount)
	{
		Name = name;
		ManaCost = manaCost;
		DamagePerTurn = damagePerTurn;
		HealPerTurn = healPerTurn;
		RegenPerTurn = regenPerTurn;
		TurnCount = turnCount;
	}

	public string Name { get; init; }
	public int ManaCost { get; init; }
	public int DamagePerTurn { get; init; }
	public int HealPerTurn { get; init; }
	public int RegenPerTurn { get; init; }
	public int TurnCount { get; set; }

	public static Spell Cast(List<Spell> spells, string name)
	{
		Spell spell = spells.FirstOrDefault(s => s.Name == name);
		if (spell == null) throw new ArgumentException($"Invalid spell, Merlin!: {name}");
		return spell.MemberwiseClone() as Spell;
	}
}

public abstract class Player
{
	public int HitPoints { get; set; }
	public bool IsAlive
	{
		get
		{
			return HitPoints > 0;
		}
	}

	public abstract void Attack(Player player);
	public int AttackStrength { get; set; }
	public int Defense {get; set;}
	
}

public class Boss : Player 
{
	public override void Attack(Player player)
	{
		Assert.True(player is Wizard); 	
		Wizard wiz = player as Wizard;
		int damage = AttackStrength; 
		damage -= wiz.Defense;
		damage = Math.Max(1, damage);
		wiz.HitPoints -= damage;
		Console.WriteLine($"Boss attacks Wizard for {damage} hitpoints. Wizard has {wiz.HitPoints} hitpoints left."); 
	}
}


public class Wizard : Player
{
	public int UsedMana { get; set; }
	public List<Spell> ActiveSpells { get; private set; } = new List<Spell>();
	private List<Spell> AvailableSpells {get; set;}

	public Wizard() 
	{
		AvailableSpells = Spell.InitSpells(); 
	}

	public void Cast(string name) 
	{
		Spell spell = Spell.Cast(AvailableSpells, name); 
		ActiveSpells.Add(spell); 
	}

	public override void Attack(Player player)
	{
		Assert.True(player is Boss);
		Boss boss = player as Boss;

		for(int i = ActiveSpells) 
		{
			
		}
	}

	// < 0: left wins
	// > 0: right wins
	public static int Fight(Warrior player, Warrior boss)
	{
		while (player.IsAlive && boss.IsAlive)
		{
			player.Attack(boss);
			if (!boss.IsAlive) break;

			boss.Attack(player);
		}
		if (!boss.IsAlive)
		{
			//Console.WriteLine($"Player wins, cost: {player.Cost}"); 
			return PlayerWins;
		}
		return BossWins;
	}

	public void Attack(Warrior opponent)
	{
		int damage = Weapon.Damage;
		if (RightRing != null) damage += RightRing.Damage;
		if (LeftRing != null) damage += LeftRing.Damage;

		if (opponent.Armor != null) damage -= opponent.Armor.Defense;
		if (opponent.RightRing != null) damage -= opponent.RightRing.Defense;
		if (opponent.LeftRing != null) damage -= opponent.LeftRing.Defense;

		damage = Math.Max(damage, 1);
		opponent.HitPoints -= damage;
	}

}

Boss InitBoss()
{
	/*
	Hit Points: 51
	Damage: 9
	*/
	return new Warrior { HitPoints = 100, Weapon = new Weapon("Spiky Dildo", 3, 8, 0), Armor = new Armor("Cheesecloth Hat", 2, 0, 2) };
}

Warrior InitPlayer()
{
	// You start with 50 hit points and 500 mana points.
	return new Warrior { HitPoints = 100 };
}

/*
Weapons:    Cost  Damage  Armor
Dagger        8     4       0
Shortsword   10     5       0
Warhammer    25     6       0
Longsword    40     7       0
Greataxe     74     8       0
*/
List<Weapon> LoadWeapons()
{
	List<Weapon> weapons = new List<Weapon>()
	{
		new Weapon("Dagger", 8, 4, 0),
		new Weapon("Shortsword", 10, 5, 0),
		new Weapon("Warhammer", 25, 6, 0),
		new Weapon("Longsword", 40, 7, 0),
		new Weapon("Greataxe", 74, 8, 0)
	};

	return weapons;
}

/*
Armor:      Cost  Damage  Armor
Leather      13     0       1
Chainmail    31     0       2
Splintmail   53     0       3
Bandedmail   75     0       4
Platemail   102     0       5
*/
List<Armor> LoadArmors()
{
	return new List<Armor>
	{
		new Armor("Leather", 13, 0, 1),
		new Armor("Chainmail", 31, 0, 2),
		new Armor("Splintmail", 53, 0, 3),
		new Armor("Bandedmail", 75, 0, 4),
		new Armor("Platemail", 102, 0, 5),
	};
}


/*
Rings:      Cost  Damage  Armor
Damage +1    25     1       0
Damage +2    50     2       0
Damage +3   100     3       0
Defense +1   20     0       1
Defense +2   40     0       2
Defense +3   80     0       3
*/
List<Ring> LoadRings()
{
	return new List<Ring>
	{
		new Ring("Damage +1", 25, 1, 0),
		new Ring("Damage +2", 50, 2, 0),
		new Ring("Damage +3", 100, 3, 0),
		new Ring("Defense +1", 20, 0, 1),
		new Ring("Defense +2", 40, 0, 2),
		new Ring("Defense +3", 80, 0, 3)
	};
}

void Part1()
{
	int minCostVictory = 100000;
	List<Weapon> weapons = LoadWeapons();
	List<Armor> armors = LoadArmors();
	List<Ring> rings = LoadRings();
	Warrior boss;
	Warrior player;
	foreach (Weapon weapon in weapons)
	{
		boss = InitBoss();
		player = InitPlayer();
		player.Weapon = weapon;
		// weapons, no armor, no rings
		if (Warrior.Fight(player, boss) == PlayerWins)
		{
			minCostVictory = Math.Min(minCostVictory, player.Cost);
		}

		// weapons, no armor, one ring
		foreach (Ring ring in rings)
		{
			boss = InitBoss();
			player = InitPlayer();
			player.Weapon = weapon;
			player.LeftRing = ring;
			if (Warrior.Fight(player, boss) == PlayerWins)
			{
				minCostVictory = Math.Min(minCostVictory, player.Cost);
			}
		}

		// weapons, no armor, two rings
		for (int i = 0; i < rings.Count - 1; i++)
		{
			for (int j = i + 1; j < rings.Count; j++)
			{
				boss = InitBoss();
				player = InitPlayer();
				player.Weapon = weapon;
				player.LeftRing = rings[i];
				player.RightRing = rings[j];
				if (Warrior.Fight(player, boss) == PlayerWins)
				{
					minCostVictory = Math.Min(minCostVictory, player.Cost);
				}

			}

		}

		foreach (Armor armor in armors)
		{
			// weapon, armor, no rings
			boss = InitBoss();
			player = InitPlayer();
			player.Weapon = weapon;
			player.Armor = armor;
			if (Warrior.Fight(player, boss) == PlayerWins)
			{
				minCostVictory = Math.Min(minCostVictory, player.Cost);
			}

			// weapons, armor, one ring
			foreach (Ring ring in rings)
			{
				boss = InitBoss();
				player = InitPlayer();
				player.Weapon = weapon;
				player.Armor = armor;
				player.LeftRing = ring;
				if (Warrior.Fight(player, boss) == PlayerWins)
				{
					minCostVictory = Math.Min(minCostVictory, player.Cost);
				}
			}

			// weapons, armor, two rings
			for (int i = 0; i < rings.Count - 1; i++)
			{
				for (int j = i + 1; j < rings.Count; j++)
				{
					boss = InitBoss();
					player = InitPlayer();
					player.Weapon = weapon;
					player.Armor = armor;
					player.LeftRing = rings[i];
					player.RightRing = rings[j];
					if (Warrior.Fight(player, boss) == PlayerWins)
					{
						minCostVictory = Math.Min(minCostVictory, player.Cost);
					}
				}

			}

		}
	}

	Console.WriteLine($"Part1 Min cost victory: {minCostVictory}");
	/*
	Hit Points: 100
	Damage: 8
	Armor: 2
	*/

}


void Part2()
{
	int maxCostLoss = 0;
	List<Weapon> weapons = LoadWeapons();
	List<Armor> armors = LoadArmors();
	List<Ring> rings = LoadRings();
	Warrior boss;
	Warrior player;
	foreach (Weapon weapon in weapons)
	{
		boss = InitBoss();
		player = InitPlayer();
		player.Weapon = weapon;
		// weapons, no armor, no rings
		if (Warrior.Fight(player, boss) == BossWins)
		{
			maxCostLoss = Math.Max(maxCostLoss, player.Cost);
		}

		// weapons, no armor, one ring
		foreach (Ring ring in rings)
		{
			boss = InitBoss();
			player = InitPlayer();
			player.Weapon = weapon;
			player.LeftRing = ring;
			if (Warrior.Fight(player, boss) == BossWins)
			{
				maxCostLoss = Math.Max(maxCostLoss, player.Cost);
			}
		}

		// weapons, no armor, two rings
		for (int i = 0; i < rings.Count - 1; i++)
		{
			for (int j = i + 1; j < rings.Count; j++)
			{
				boss = InitBoss();
				player = InitPlayer();
				player.Weapon = weapon;
				player.LeftRing = rings[i];
				player.RightRing = rings[j];
				if (Warrior.Fight(player, boss) == BossWins)
				{
					maxCostLoss = Math.Max(maxCostLoss, player.Cost);
				}

			}

		}

		foreach (Armor armor in armors)
		{
			// weapon, armor, no rings
			boss = InitBoss();
			player = InitPlayer();
			player.Weapon = weapon;
			player.Armor = armor;
			if (Warrior.Fight(player, boss) == BossWins)
			{
				maxCostLoss = Math.Max(maxCostLoss, player.Cost);
			}

			// weapons, armor, one ring
			foreach (Ring ring in rings)
			{
				boss = InitBoss();
				player = InitPlayer();
				player.Weapon = weapon;
				player.Armor = armor;
				player.LeftRing = ring;
				if (Warrior.Fight(player, boss) == BossWins)
				{
					maxCostLoss = Math.Max(maxCostLoss, player.Cost);
				}
			}

			// weapons, armor, two rings
			for (int i = 0; i < rings.Count - 1; i++)
			{
				for (int j = i + 1; j < rings.Count; j++)
				{
					boss = InitBoss();
					player = InitPlayer();
					player.Weapon = weapon;
					player.Armor = armor;
					player.LeftRing = rings[i];
					player.RightRing = rings[j];
					if (Warrior.Fight(player, boss) == BossWins)
					{
						maxCostLoss = Math.Max(maxCostLoss, player.Cost);
					}
				}

			}

		}
	}

	Console.WriteLine($"Part2 Max cost loss: {maxCostLoss}");
	/*
	Hit Points: 100
	Damage: 8
	Armor: 2
	*/

}



#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

#endregion