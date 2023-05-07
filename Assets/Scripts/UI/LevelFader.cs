using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFader: ScreenFader, ISingleton<LevelFader>
{
	[Header("Timing")]
	[SerializeField] float fadeSpeed = 1;


	public static LevelFader Instance { get; private set; } = null;
	public LevelFader Singleton => Instance;



	protected override void Awake()
	{
		if( Instance != null )
		{
			DestroyImmediate(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);
		base.Awake();
	}


	public void FadeIn()
	{
		FadeIn(fadeSpeed);
	}

	public void FadeOut()
	{
		FadeOut(fadeSpeed);
	}

	public void FadeAndLoadLevel(string levelName)
	{
		StartCoroutine(FadeAndLoadLevelRoutine(levelName));
	}

	protected IEnumerator FadeAndLoadLevelRoutine(string levelName)
	{
		if(SceneManager.GetSceneByName(levelName) == null)
		{
			Debug.LogWarning($"'{levelName}' is not a valid scene name.");
			yield break;
			//throw new ArgumentException($"{nameof(levelName)}:{levelName}");
		}

		yield return FadeOutAsync(fadeSpeed);
		SceneManager.LoadScene(levelName);
		//yield return new WaitForEndOfFrame();
		yield return FadeInAsync(fadeSpeed);
	}
}
