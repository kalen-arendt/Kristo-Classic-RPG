using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelConfiner: MonoBehaviour
{
	[SerializeField] BoxCollider2D confiner;

	public static Vector2 MinBounds { get; private set; }
	public static Vector2 MaxBounds { get; private set; }


	void Awake()
	{
		if (confiner != null)
		{
			confiner.isTrigger = true;
			MinBounds = confiner.bounds.min;
			MaxBounds = confiner.bounds.max;
		}
	}
}
