namespace Wicip.Sample.ViewModels
{
	public class PushButtonPageViewModel : Template10.Mvvm.ViewModelBase
	{
		private int pinNumber = 5;

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
