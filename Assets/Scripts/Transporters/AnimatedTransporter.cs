using System;
using System.Collections;
using UnityEngine;



public class AnimatedTransporter: Transporter
{
	[Header("Override Animations")]
	[SerializeField] AnimatorOverrideController animatorOverride = null;
	[SerializeField] protected AnimationClip idleClip = null;
	[SerializeField] protected AnimationClip activationClip = null;

	Animator animator;

	const string DEFAULT_IDLE = "TRANSPORT_DEFUALT_IDLE";
	const string DEFAULT_ACTIVE = "TRANSPORT_DEFUALT_ACTIVE";
	const string ANIM_TRIGGER_ACTIVE = "active";

	float ActivationClipDuration => activationClip ? activationClip.length : DefaultLoadDelay;
	float DefaultLoadDelay => 1f;




	protected override void Awake()
	{
		animator = GetComponent<Animator>();
		animator.runtimeAnimatorController = animatorOverride;
		InitAnimatorOverride();

		base.Awake();
	}

	private void OnEnable()
	{
		OnEnter += SetAnimTrigger_Active;
		OnExit += SetAnimTrigger_Active;
	}

	void InitAnimatorOverride()
	{
		if( idleClip == null )
		{
			Debug.LogWarning($"{nameof(idleClip)}: must not be null.");
			throw new ArgumentException($"{nameof(idleClip)}: must not be null.");
		}

		if( activationClip == null )
		{
			Debug.LogWarning($"{nameof(idleClip)}: must not be null.");
			throw new ArgumentException($"{nameof(activationClip)}: must not be null.");
		}

		animatorOverride[DEFAULT_IDLE] = idleClip;
		animatorOverride[DEFAULT_ACTIVE] = activationClip;
	}

	protected override void LoadTargetLevel()
	{
		StartCoroutine(LoadNextLevelAfterDelay(ActivationClipDuration + 0.1f));
	}

	IEnumerator LoadNextLevelAfterDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		base.LoadTargetLevel();
	}


	void SetAnimTrigger_Active()
	{
		animator.SetTrigger(ANIM_TRIGGER_ACTIVE);
	}
}