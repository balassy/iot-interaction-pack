using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace Wicip.Sample.Converters
{
	class DistanceTextConverter : IValueConverter
	{
		[SuppressMessage( "Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)", Justification = "The localy of the current user is perfect here." )]
		public object Convert( object value, Type targetType, object parameter, string language )
		{
			double? distance = (double?) value;
			int maxDistance = Int32.Parse( (string) parameter, CultureInfo.InvariantCulture );
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
