namespace Wicip.Sample.ViewModels
{
	internal class UltrasonicSensorPageViewModel : Template10.Mvvm.ViewModelBase
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


		private int triggerPinNumber = 13;

		public int TriggerPinNumber
		{
			get { return this.triggerPinNumber; }
			set
			{
				this.triggerPinNumber = value;
				base.RaisePropertyChanged();
			}
		}


		private int echoPinNumber = 26;

		public int EchoPinNumber
		{
			get { return this.echoPinNumber; }
			set
			{
				this.echoPinNumber = value;
				base.RaisePropertyChanged();
			}
		}


		private double? distance;

		public double? Distance
		{
			get
			{
				return this.distance;
			}
			set
			{
				this.distance = value;
				base.RaisePropertyChanged();
			}
		}
	}
}
