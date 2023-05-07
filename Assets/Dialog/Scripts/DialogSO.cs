using System.Collections;
using UnityEngine;


namespace DialogSystem
{
	[CreateAssetMenu(menuName = "DialogSO", fileName = "DialogSO")]
	public class DialogSO: ScriptableObject, IDialogContainer
	{
		[SerializeField] DialogContainer dialog;

		public int Length => Dialog.Length;
		public IDialogMessage this[int dialogIndex] => Dialog[dialogIndex];
		public IDialogMessage[] GetDialog() => Dialog.GetDialog();

		IDialogContainer Dialog => dialog;
	}
}
