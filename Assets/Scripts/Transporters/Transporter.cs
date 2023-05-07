using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(BoxCollider2D))]
public class Transporter: MonoBehaviour
{
	[Header("Transporter")]
	[SerializeField] [Range(0, 31)] int myTransporterID = 31;

	[Header("Entrance")]
	[SerializeField] Transform entrance = null; //= new Vector2(0, 0);

	[Header("Transporter Exit")]
	[SerializeField] string loadLevelName = "levelName";
	[SerializeField] [Range(0, 31)] int loadTransporterID = 31;

	static int EntranceTransporterID { get; set; } = UNSET;
	const int UNSET = -1;

	const float TRIGGER_ACTIVATION_DELAY = .1f;

	public event UnityAction OnEnter;
	public event UnityAction OnExit;


	void Reset()
	{
		entrance = new GameObject("Entrance").transform;
		entrance.SetParent(transform);
		entrance.localPosition = Vector3.zero;
	}

	protected virtual void Awake()
	{
		if( EntranceTransporterID == myTransporterID )
		{
			Enter();
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if( other.CompareTag(Tags.PLAYER) && Time.timeSinceLevelLoad > TRIGGER_ACTIVATION_DELAY )
		{
			Exit();
		}
	}

	void Enter()
	{
		OnEnter?.Invoke();

		SetPlayerPosition();
		EntranceTransporterID = UNSET;
	}

	void Exit()
	{
		OnExit?.Invoke();

		EntranceTransporterID = loadTransporterID;
		LoadTargetLevel();
	}

	protected virtual void SetPlayerPosition()
	{
		if( PlayerController.Instance != null )
		{
			PlayerController.Instance.transform.position = entrance.position;
		}
	}

	protected virtual void LoadTargetLevel()
	{
		if (LevelFader.Instance)
		{
			LevelFader.Instance.FadeAndLoadLevel(loadLevelName);
		}
		else
		{
			SceneManager.LoadScene(loadLevelName);
		}
	}
}