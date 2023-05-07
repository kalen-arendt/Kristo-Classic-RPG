using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class ScreenFader: MonoBehaviour
{
	[SerializeField] protected Image fadePanel = null;

	protected Coroutine currentFadeRoutine = null;



	protected virtual void Awake()
	{
		fadePanel.gameObject.SetActive(false);
	}


	public void FadeIn(float duration)
	{
		if( currentFadeRoutine != null )
			StopCoroutine(currentFadeRoutine);

		currentFadeRoutine = StartCoroutine(FadeAsync(duration, Color.black, Color.clear, false));
	}

	public void FadeOut(float duration, bool setActiveAfter = true)
	{
		if( currentFadeRoutine != null )
			StopCoroutine(currentFadeRoutine);

		currentFadeRoutine = StartCoroutine(FadeAsync(duration, Color.clear, Color.black, setActiveAfter));
	}

	public IEnumerator FadeInAsync(float duration)
	{
		FadeIn(duration);
		yield return currentFadeRoutine;
	}

	public IEnumerator FadeOutAsync(float duration, bool setActiveAfter = true)
	{
		FadeOut(duration, setActiveAfter);
		yield return currentFadeRoutine;
	}

	protected IEnumerator FadeAsync(float duration, Color startColor, Color endColor, bool setActiveAfter)
	{
		fadePanel.gameObject.SetActive(true);
		fadePanel.color = startColor;

		float t = 0;
		while( t < duration )
		{
			fadePanel.color = Color.Lerp(startColor, endColor, t / duration);
			t += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}

		fadePanel.gameObject.SetActive(setActiveAfter);
		currentFadeRoutine = null;
	}

	public IEnumerator FadeInOut(float fadeInDuration, float waitTime, float fadeOutDuration)
	{
		yield return FadeInAsync(fadeInDuration);
		yield return new WaitForSeconds(waitTime);
		yield return FadeOutAsync(fadeOutDuration);
	}
}