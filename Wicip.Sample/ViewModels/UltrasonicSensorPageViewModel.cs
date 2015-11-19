namespace Wicip.Sample.ViewModels
{
	internal class UltrasonicSensorPageViewModel : Template10.Mvvm.ViewModelBase
	{
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
