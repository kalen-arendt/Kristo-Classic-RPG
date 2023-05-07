using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;

public class PlayerStats: MonoBehaviour
{
	[SerializeField] CharacterStats stats;

	int currentXP = 0;
	const int XP_TO_LEVELUP = 100;
	const int MAX_LEVEL = 100;


	private void Awake()
	{
		stats.FullEnergy();
		stats.FullHealth();
	}


	public void AddXP (int xp)
	{
		if (stats.Level < MAX_LEVEL)
		{
			currentXP += xp;

			if( currentXP >= XP_TO_LEVELUP )
			{
				LevelUp();
			}
		}
		else
		{
			currentXP = 0;
		}
	}

	void LevelUp()
	{
		currentXP -= XP_TO_LEVELUP;
		stats.Level++;


		if (stats.Level % 2 == 0)
		{
			stats.BaseDamage += 2;
		}
		else
		{
			stats.Defence += 1;
		}

		stats.MaxHealth = Mathf.FloorToInt(stats.MaxHealth * 1.05f);
		stats.MaxEnergy += 1;

		stats.FullEnergy();
		stats.FullHealth();
	}
}
