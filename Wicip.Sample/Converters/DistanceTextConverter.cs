using System;
using Windows.UI.Xaml.Data;

namespace Wicip.Sample.Converters
{
	class DistanceTextConverter : IValueConverter
	{
		public object Convert( object value, Type targetType, object parameter, string language )
		{
			double? distance = (double?) value;
			int maxDistance = Int32.Parse( (string) parameter );
			return distance.HasValue
						? distance.Value < maxDistance
							?	$"{distance.Value} centimeters"
							: "(out of range)"
						: "(not available)";
		}

		public object ConvertBack( object value, Type targetType, object parameter, string language )
		{
			throw new NotImplementedException();
		}
	}
}
