namespace DialogSystem
{
	public interface IDialogContainer
	{
		int Length { get; }
		IDialogMessage this[int dialogIndex] { get; }
		IDialogMessage[] GetDialog();
	}
}
