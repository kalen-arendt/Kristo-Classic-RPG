using UnityEngine;

public class InstancingManager: MonoBehaviour
{
	[SerializeField] InstancingSO instancingSO;

	void Awake()
	{
		if (instancingSO == null)
		{
			throw new System.Exception($"{nameof(instancingSO)}={instancingSO}");
		}

		CheckInstance(instancingSO.PlayerController);
		CheckInstance(instancingSO.UICanvas);
		CheckInstance(instancingSO.GameManager);
	}

	void CheckInstance<T>(ISingleton<T> obj)
		where T : ISingleton<T>
	{
		if( obj != null && obj.Singleton== null )
		{
			Instantiate(obj.gameObject);
		}
	}
}
