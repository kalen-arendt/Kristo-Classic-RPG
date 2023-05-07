using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerController: MonoBehaviour, ISingleton<PlayerController>
{
	[SerializeField] float moveSpeed = 2;

	Animator myAnim;
	Rigidbody2D myRB;

	Vector2 moveValue;

	public static bool CanMove { get; set; } = true;

	#region Constants
	public const string ANIM_MOVE_X = "moveX";
	public const string ANIM_MOVE_Y = "moveY";
	public const string ANIM_LAST_MOVE_X = "lastMoveX";
	public const string ANIM_LAST_MOVE_Y = "lastMoveY";
	#endregion


	public static PlayerController Instance { get; private set; } = null;
	public PlayerController Singleton => Instance;


	void Awake()
	{
		if (Instance != null)
		{
			DestroyImmediate(gameObject);
			return;
		}
		else
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);

			myAnim = GetComponent<Animator>();
			myRB = GetComponentInChildren<Rigidbody2D>();
		}
	}

	void Update()
	{
		Vector2 move = CanMove ? moveValue : Vector2.zero;

		myAnim.SetFloat(ANIM_MOVE_X, move.x);
		myAnim.SetFloat(ANIM_MOVE_Y, move.y);

		myRB.velocity = moveSpeed * move;

		if ( move.x == 1 || move.x == -1
			|| move.y == 1 || move.y == -1) {	
			myAnim.SetFloat(ANIM_LAST_MOVE_X, move.x);
			myAnim.SetFloat(ANIM_LAST_MOVE_Y, move.y);
		}
	}


	void OnMove(InputValue value)
	{
		moveValue = value.Get<Vector2>();
	}
}
