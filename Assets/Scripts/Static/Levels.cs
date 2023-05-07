using UnityEngine.SceneManagement;
using UnityEngine;

public static class Levels 
{
	//TEMP
	private static int previousSceneIndex = 5;

	public static void LoadPreviousLevel ()
	{
		//previousSceneIndex.Print("loading previousSceneIndex");
		LoadLevel(previousSceneIndex);
	}

	public static void LoadNextLevel ()
	{
		SetPreviousScene();
		LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public static void LoadLevel (string name)
	{
		try
		{
			SetPreviousScene();
			SceneManager.LoadScene(name);
		}
		catch
		{
			Debug.LogWarning("Scene doesn't exist with the name: " + name);
		}
	}
	public static void LoadLevel (int sceneBuildIndex)
	{
		try
		{
			SetPreviousScene();
			SceneManager.LoadScene(sceneBuildIndex);
		}
		catch
		{
			Debug.LogWarning("Scene doesn't exist with an index of: " + sceneBuildIndex);
		}
	}

	private static void SetPreviousScene () //HMM think about having the previous scene as a parameter
	{
		previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
	}
}

