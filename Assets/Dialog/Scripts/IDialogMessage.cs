namespace DialogSystem
{
	public interface IDialogMessage: IMessage
	{
		public string SpeakerName { get; }
	}
}

