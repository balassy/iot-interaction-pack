using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wicip.Sample.ViewModels
{
	public class UltrasonicSensorPageViewModel : Template10.Mvvm.ViewModelBase
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
