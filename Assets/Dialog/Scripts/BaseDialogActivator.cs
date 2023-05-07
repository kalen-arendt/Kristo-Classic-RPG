using UnityEngine;

namespace DialogSystem
{
	[RequireComponent(typeof(Collider2D))]
	public abstract class BaseDialogActivator: MonoBehaviour
	{
		[Header("Interaction")]
		[SerializeField] protected bool autoActivate = true;
		[SerializeField] protected GameObject actionIcon;



		void Start()
		{
			SetIconActive(false);
		}

		protected abstract void ActivateDialog();

		void OnTriggerEnter2D(Collider2D other)
		{
			if( other.CompareTag(Tags.PLAYER) )
			{
				SetIconActive(true);
				ActivateDialog();

				if( autoActivate )
				{
					DialogManager.Instance.Open();
				}
			}
		}

		void OnTriggerExit2D(Collider2D other)
		{
			if( other.CompareTag(Tags.PLAYER) )
			{
				SetIconActive(false);
				DialogManager.Instance.Deactivate();
			}
		}

		protected void SetIconActive(bool active)
		{
			if( actionIcon != null )
			{
				actionIcon.SetActive(active);
			}
		}
	}
}