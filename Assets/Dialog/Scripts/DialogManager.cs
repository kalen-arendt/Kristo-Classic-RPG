using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEditor;

namespace DialogSystem
{
	public class DialogManager: MonoBehaviour, ISingleton<DialogManager>
	{
		[Header("Dialog")]
		[SerializeField] GameObject dialogPanel;
		[SerializeField] TextMeshProUGUI dialogText;

		[Header("Speaker")]
		[SerializeField] GameObject speakerPanel;
		[SerializeField] TextMeshProUGUI speakerText;

		IDialogContainer currentDialog = null;
		IMessage overrideMessage = null;

		[Min(0)] int msgIndex = 0;
		[Min(0)] int lineIndex = 0;

		public bool IsInputActive { get; private set; } = false;
		public bool IsOpen { get; private set; } = false;
		public DialogManager Singleton => Instance;

		public static DialogManager Instance { get; private set; }



		#region Unity Messages: Awake, OnDestroy

		void Awake()
		{
			Instance = this;
			dialogPanel.SetActive(false);
		}

		void OnDestroy() // this will only get called if the entire UI is destroyed
		{
			Instance = null;
		}

		#endregion

		void OnSubmit(InputValue value)
		{
			if( IsInputActive )
			{
				if( !IsOpen )
				{
					Open();
				}
				else
				{
					Next();
				}
			}
		}


		#region public Methods

		public void SetDialog(IDialogContainer dialog)
		{
			IsInputActive = true;
			ClearIndices();

			currentDialog = dialog;
			overrideMessage = null;
		}

		public void SetMessage(IMessage message)
		{
			IsInputActive = true;
			ClearIndices();

			currentDialog = null;
			overrideMessage = message;
		}

		public void Open()
		{
			if( IsInputActive || !IsOpen )
			{
				IsOpen = true;
				dialogPanel.SetActive(true);
				DisplayCurrent();
			}
		}

		public void Deactivate()
		{
			IsInputActive = false;			
			Close();
		}

		#endregion


		#region Next, Close

		void Next()
		{
			if( !MoveToNextLine() )
			{
				if( !MoveNextMessage() )
				{
					Close();
				}
			}
		}

		void Close()
		{
			ClearIndices();
			IsOpen = false;
			dialogPanel.SetActive(false);
		}

		void ClearIndices()
		{
			msgIndex = 0;
			lineIndex = 0;
		}

		#endregion


		#region Private Message Display Methods
		bool MoveNextMessage()
		{
			msgIndex++;
			lineIndex = 0;
			return DisplayCurrent();
		}

		bool MoveToNextLine()
		{
			lineIndex++;
			return DisplayCurrentLine();
		}

		bool DisplayCurrent()
		{
			DisplayCurrentSpeakerName();
			return DisplayCurrentLine();
		}

		void DisplayCurrentSpeakerName()
		{
			if( GetCurrentMessage() is IDialogMessage msg && !string.IsNullOrEmpty(msg.SpeakerName) )
			{
				speakerPanel.SetActive(true);
				speakerText.text = msg.SpeakerName;
			}
			else
			{
				speakerText.text = "";
				speakerPanel.SetActive(false);
			}
		}

		bool DisplayCurrentLine()
		{
			string line = GetCurrentLine();
			if( line != null )
			{
				dialogText.text = line;
				return true;
			}
			else
			{
				dialogText.text = "";
				return false;
			}
		}

		string GetCurrentLine()
		{
			var msg = GetCurrentMessage();
			return (msg != null && lineIndex < msg.Length)
			 ? msg[lineIndex]
			 : null;
		}

		IMessage GetCurrentMessage()
		{
			return overrideMessage ?? (
				(currentDialog != null && msgIndex < currentDialog.Length)
					? currentDialog[msgIndex]
					: null
			);
		}

		#endregion
	}
}
