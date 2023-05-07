using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour, ISingleton<GameManager>
{
	public static GameManager Instance { get; private set; } = null;
	public GameManager Singleton => Instance;

	void Awake()
	{
		if( Instance != null )
		{
			DestroyImmediate(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);
	}
}
