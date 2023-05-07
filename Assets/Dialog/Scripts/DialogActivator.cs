using DialogSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DialogSystem
{
	public class DialogActivator: BaseDialogActivator
	{
		[Header("Dialog")]
		[SerializeField] DialogSO dialogSO;


		private void Awake()
		{
			if( dialogSO == null )
			{
				Debug.LogWarning($"{nameof(dialogSO)} is unassigned on {name}", this);
			}
		}

		protected override void ActivateDialog()
		{
			DialogManager.Instance.SetDialog(dialogSO);
		}
	}
}