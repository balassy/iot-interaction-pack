namespace Wicip.Sample.ViewModels
{
	internal class RfidPageViewModel : Template10.Mvvm.ViewModelBase
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


		private int pinNumber = 13;

		public int PinNumber
		{
			get { return this.pinNumber; }
			set
			{
				this.pinNumber = value;
				base.RaisePropertyChanged();
			}
		}
	}
}
