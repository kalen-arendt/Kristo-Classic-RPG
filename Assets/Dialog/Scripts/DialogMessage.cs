using UnityEngine;

namespace DialogSystem
{
	/// <summary>
	/// <see cref="Message"/> Decorator - has a speakerName
	/// </summary>
	[System.Serializable]
	public class DialogMessage: IDialogMessage, IMessage
	{
		[SerializeField] string speakerName;
		[SerializeField] Message message;

		public string SpeakerName => speakerName;


		public string this[int i] => message[i];
		public int Length => message.Length;
		public string[] GetMessages() => message.GetMessages();
	}
}

