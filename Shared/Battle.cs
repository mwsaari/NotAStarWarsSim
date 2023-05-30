namespace NotAStarWarsSim.Shared
{
	public static class Battle
	{
		public static Tuple<Fleet, Fleet> GetResults(Tuple<Fleet, Fleet> combattants)
		{
			while (combattants.Item1.Strenght != 0 && combattants.Item2.Strenght != 0)
			{
				Tick(combattants);
			}
			return combattants;
		}

		private static void Tick(Tuple<Fleet, Fleet> combattants)
		{
			var attacker = combattants.Item1;
			var defender = combattants.Item2;
			foreach (Fleet.Classifications classification in Enum.GetValues(typeof(Fleet.Classifications)))
			{
				if (attacker.Forces[classification] != 0 && defender.Forces[classification] != 0)
				{
					attacker.Forces[classification] -= 1;
					defender.Forces[classification] -= 1;
					continue;
				}
				if (attacker.Forces[classification] != 0)
				{
					AttackWithShip(classification, attacker, defender);
				}
				if (defender.Forces[classification] != 0)
				{
					AttackWithShip(classification, defender, attacker);
				}
			}
		}

		private static void AttackWithShip(Fleet.Classifications classification, Fleet offense, Fleet defense)
		{
			if (offense.Forces[classification] == 0)
			{
				return;
			}
			if (classification == Fleet.Classifications.Bomber)
			{
				for (Fleet.Classifications i = Fleet.Classifications.Dreadnaught; i >= Fleet.Classifications.Corvette; i--)
				{
					if (defense.Forces[i] != 0)
					{
						defense.Forces[i] -= 1;
						continue;
					}
				}
			}

			var multiplier = 1;
			for (Fleet.Classifications i = classification - 1; i >= 0; i--)
			{
				var defenses = defense.Forces[i];
				if (defenses == 0)
				{
					multiplier *= 2;
					continue;
				}
				defense.Forces[i] = defenses > multiplier ? defenses - multiplier : 0;
			}
		}
	}
}
