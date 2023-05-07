using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu: MonoBehaviour
{
	[SerializeField] GameObject menuTab;


	public static GameMenu Instance { get; private set; } = null;
	public GameMenu Singleton => Instance;



	void Awake()
	{
		if( Instance != null )
		{
			DestroyImmediate(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);
		menuTab.SetActive(false);
	}


	void OnOpenMenu()
	{
		menuTab.SetActive(true);
	}

	void OnCloseMenu()
	{
		menuTab.SetActive(false);
	}
}
