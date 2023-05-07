using UnityEngine;


[CreateAssetMenu(menuName = "InstancingSO", fileName = "NewInstancingSO")]
public class InstancingSO : ScriptableObject
{
	[SerializeField] PlayerController player;
	[SerializeField] LevelFader uiCanvas;
	[SerializeField] GameManager gameManager;

	public ISingleton<PlayerController> PlayerController
		=> player as ISingleton<PlayerController>
		?? throw new System.Exception($"{nameof(player)}={player}");

	public ISingleton<LevelFader> UICanvas
		=> uiCanvas as ISingleton<LevelFader>
		?? throw new System.Exception($"{nameof(UICanvas)}={UICanvas}");

	public ISingleton<GameManager> GameManager
		=> gameManager as ISingleton<GameManager>
		?? throw new System.Exception($"{nameof(gameManager)}={gameManager}");
}
