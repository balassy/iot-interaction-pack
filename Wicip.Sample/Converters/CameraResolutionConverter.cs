using System;
using System.Diagnostics.CodeAnalysis;
using Windows.Media.MediaProperties;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Wicip.Sample.Converters
{
	internal class CameraResolutionConverter : IValueConverter
	{
		[SuppressMessage( "Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object,System.Object)", Justification = "Locale-specific formatting is okay here." )]
		public object Convert( object value, Type targetType, object parameter, string language )
		{
			VideoEncodingProperties resolution = (VideoEncodingProperties) value;
			return resolution == null
				? DependencyProperty.UnsetValue
				: $"{resolution.Width} × {resolution.Height}";
		}

		public object ConvertBack( object value, Type targetType, object parameter, string language )
		{
			throw new NotImplementedException();
		}
	}
}
