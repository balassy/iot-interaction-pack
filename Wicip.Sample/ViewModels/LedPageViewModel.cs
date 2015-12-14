namespace Wicip.Sample.ViewModels
{
	internal class LedPageViewModel : Template10.Mvvm.ViewModelBase
	{
		private bool isAvailable;

		public bool IsAvailable
		{
			get { return this.isAvailable; }
			set
			{
				this.isAvailable = value;
				base.RaisePropertyChanged();
			}
		}


		private int pinNumber = 6;

		public int PinNumber
		{
			get { return this.pinNumber; }
			set
			{
				this.pinNumber = value;
				base.RaisePropertyChanged();
			}
		}
		

		private bool isOn;

		public bool IsOn
		{
			get { return this.isOn; }
			set
			{
				this.isOn = value;
				base.RaisePropertyChanged();
			}
		}

	}
}
