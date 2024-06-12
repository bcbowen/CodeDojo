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

public abstract class Gear 
{
	public Gear(string name, int cost, int damage, int defense) 
	{
		Name = name; 
		Cost = cost; 
		Damage = damage; 
		Defense = defense; 
	}
	
	public string Name {get; init;}
	public int Cost {get; init;}
	public int Damage {get; init;}
	public int Defense {get; init;}
}

public class Weapon : Gear
{
	public Weapon(string name, int cost, int damage, int defense) : base(name, cost, damage, defense) {}
} 

public class Armor : Gear 
{
	public Armor(string name, int cost, int damage, int defense) : base(name, cost, damage, defense) {}
}

public class Ring : Gear 
{
	public Ring(string name, int cost, int damage, int defense) : base(name, cost, damage, defense) {}
}

public class Warrior 
{
	public bool IsAlive
	{
		get 
		{
			return HitPoints > 0; 
		}
	}

	public int Cost
	{
		get 
		{
			int cost = 0; 
			if (Weapon != null) cost += Weapon.Cost; 
			if (Armor != null) cost += Armor.Cost; 
			if (RightRing != null) cost += RightRing.Cost; 
			if (LeftRing != null) cost += LeftRing.Cost; 
			return cost; 
		}
	}
	
	public int HitPoints { get; set; }
	//public int Damage { get; set; }
	//public int Defense {get; set;}

	public Weapon Weapon { get; set; }
	public Armor Armor { get; set; }
	public Ring RightRing { get; set; }
	public Ring LeftRing { get; set; }

	// < 0: left wins
	// > 0: right wins
	public static int Fight(Warrior player, Warrior boss)
	{
		while(player.IsAlive && boss.IsAlive) 
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

Warrior InitBoss() 
{
	return new Warrior { HitPoints = 100, Weapon = new Weapon("Spiky Dildo", 3, 8, 0), Armor = new Armor("Cheesecloth Hat", 2, 0, 2)}; 
}

Warrior InitPlayer() 
{
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
	foreach(Weapon weapon in weapons) 
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
			for(int j = i + 1; j < rings.Count; j++) 
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
		
		foreach(Armor armor in armors) 
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