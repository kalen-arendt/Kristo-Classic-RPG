using System.Collections;
using UnityEngine;
using UnityEngine.UI;



public class SplashScreenFader: ScreenFader
{
	[Header("Behaviour")]
	[SerializeField] FadeInBehaviour fadeIn = FadeInBehaviour.Default;
	[SerializeField] FadeOutBehaviour fadeOut = FadeOutBehaviour.Default;

	[Header("Timing")]
	[SerializeField] float fadeInDuration = 1;
	[SerializeField] float waitDuration = 0;
	[SerializeField] float fadeOutDuration = 1;


	private enum FadeInBehaviour	
	{
		Default,
		None
	}

	private enum FadeOutBehaviour
	{
		Default,
		FadeThenLoadNextScene,
		None
	}



	void Start()
	{
		StartCoroutine(FadeInOutLoad());
	}


	IEnumerator FadeInOutLoad()
	{
		switch( fadeIn )
		{
			case FadeInBehaviour.Default:
				yield return FadeInAsync(fadeInDuration);
				break;
			case FadeInBehaviour.None:
				break;
		}

		yield return new WaitForSeconds(waitDuration);

		switch( fadeOut )
		{
			case FadeOutBehaviour.Default:
				yield return FadeOutAsync(fadeOutDuration);
				break;
			case FadeOutBehaviour.FadeThenLoadNextScene:
				yield return FadeOutAsync(fadeOutDuration);
				Levels.LoadNextLevel();
				break;
			case FadeOutBehaviour.None:
				break;
		}
	}
}