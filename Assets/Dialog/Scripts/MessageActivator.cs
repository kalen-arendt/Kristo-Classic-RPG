using UnityEngine;

namespace DialogSystem
{
	public class MessageActivator: BaseDialogActivator
	{
		[Header("Message")]
		[SerializeField] Message message;

		void Awake()
		{
			if( message == null )
			{
				Debug.LogWarning($"{nameof(message)} is unassigned on {name}", this);
			}
		}

		protected override void ActivateDialog()
		{
			DialogManager.Instance.SetMessage(message);
		}
	}
}