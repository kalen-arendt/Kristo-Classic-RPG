using UnityEngine;


namespace DialogSystem
{
	[CreateAssetMenu(menuName = "DialogSO", fileName = "DialogSO")]
	public class MessageSO: ScriptableObject, IMessage
	{
		[SerializeField] Message message;

		public string this[int msgIndex] => Message[msgIndex];

		public IMessage Message => message;
		public int Length => Message.Length;
		public string[] GetMessages() => Message.GetMessages();
	}
}
