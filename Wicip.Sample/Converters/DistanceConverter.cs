using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Wicip.Sample.Converters
{
	class DistanceConverter : IValueConverter
	{
		public object Convert( object value, Type targetType, object parameter, string language )
		{
			double? distance = (double?) value;
			int maxValue = Int32.Parse((string) parameter);
			return !distance.HasValue
						? DependencyProperty.UnsetValue
						: distance.Value > maxValue
							? maxValue
							: distance.Value;
		}

		public object ConvertBack( object value, Type targetType, object parameter, string language )
		{
			throw new NotImplementedException();
		}
	}
}
