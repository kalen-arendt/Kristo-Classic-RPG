using UnityEngine;

[System.Serializable]
public class CharacterStats
{
	[SerializeField] string characterName;
	[SerializeField] int level;
	[SerializeField] int maxHealth;
	[SerializeField] int maxEnergy;
	[SerializeField] int baseDamage;
	[SerializeField] int defence;


	public int Level { get => level; set => level = value; }
	public int MaxHealth { get => maxHealth; set => maxHealth = value; }
	public int MaxEnergy { get => maxEnergy; set => maxEnergy = value; }
	public int BaseDamage { get => baseDamage; set => baseDamage = value; }
	public int Defence { get => defence; set => defence = value; }

	public int CurrentHealth { get; set; }
	public int CurrentEnergy { get; set; }

	public void FullHealth()
	{
		CurrentHealth = maxHealth;
	}

	public void FullEnergy()
	{
		CurrentHealth = MaxEnergy;
	}
}