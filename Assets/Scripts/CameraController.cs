using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] Transform target;
	[SerializeField] Vector2 extraPadding = new Vector2(.25f, .25f);

	Vector2 minBounds, maxBounds;


	void Start()
	{
		InitBounds();
		InitTarget();
	}

	void LateUpdate()
	{
		FollowTarget();
	}

	void InitTarget()
	{
		if( target == null && PlayerController.Instance != null )
		{
			target = PlayerController.Instance.transform;
		}
	}

	void InitBounds()
	{
		Camera cam = Camera.main;

		Vector2 padding = extraPadding + new Vector2(
			cam.orthographicSize * cam.aspect,
			cam.orthographicSize
		);

		minBounds = LevelConfiner.MinBounds + padding;
		maxBounds = LevelConfiner.MaxBounds - padding;

		//Debug.Log($"{nameof(minBounds)}: {minBounds}");
		//Debug.Log($"{nameof(maxBounds)}: {maxBounds}");
	}

	void FollowTarget()
	{
		if (target != null)
		{
			var newPos = new Vector3(
				Mathf.Clamp(target.position.x, minBounds.x, maxBounds.x),
				Mathf.Clamp(target.position.y, minBounds.y, maxBounds.y),
				transform.position.z
			);

			//Debug.Log($"{nameof(newPos)}: {newPos}");


			transform.position = new Vector3(
				Mathf.Clamp(target.position.x, minBounds.x, maxBounds.x),
				Mathf.Clamp(target.position.y, minBounds.y, maxBounds.y),
				transform.position.z
			);
		}
		else
		{
			InitTarget();
		}
	}
}
