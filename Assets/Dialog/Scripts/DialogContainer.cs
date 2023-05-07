using System.Collections.Generic;
using UnityEngine;


namespace DialogSystem
{
	[System.Serializable]
	public class DialogContainer: IDialogContainer
	{
		[SerializeField] List<DialogMessage> dialog;

		public int Length => dialog.Count;
		public IDialogMessage this[int dialogIndex] => dialog[dialogIndex];
		public IDialogMessage[] GetDialog() => dialog.ToArray();
	}
}
