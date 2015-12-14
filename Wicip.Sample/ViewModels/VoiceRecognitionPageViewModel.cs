using System;

namespace Wicip.Sample.ViewModels
{
	public class VoiceRecognitionPageViewModel : Template10.Mvvm.ViewModelBase
	{
		private bool isContinuous;

		public bool IsContinuous
		{
			get { return this.isContinuous; }
			set
			{
				this.isContinuous = value;
				base.RaisePropertyChanged();
			}
		}


		private string recognizedText = String.Empty;

		public string RecognizedText
		{
			get { return this.recognizedText; }
			set
			{
				this.recognizedText = value;
				base.RaisePropertyChanged();
			}
		}


		private string previousRecognizedText = String.Empty;

		public string PreviousRecognizedText
		{
			get { return this.recognizedText; }
			set
			{
				this.previousRecognizedText = value;
				base.RaisePropertyChanged();
			}
		}

	}
}
