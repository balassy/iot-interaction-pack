using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Windows.Media.MediaProperties;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Wicip.Sample.Converters
{
	internal class CameraResolutionListItemConverter : IValueConverter
	{
		[SuppressMessage( "Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object,System.Object)", Justification = "Locale-specific formatting is okay here." )]
		public object Convert( object value, Type targetType, object parameter, string language )
		{
			IEnumerable<VideoEncodingProperties> resolutions = value as IEnumerable<VideoEncodingProperties>;
			return value == null
				? DependencyProperty.UnsetValue
				: resolutions.Select( r => new KeyValuePair<string, VideoEncodingProperties>( $"{r.Width} × {r.Height}", r ) );
		}

		public object ConvertBack( object value, Type targetType, object parameter, string language )
		{
			throw new NotImplementedException();
		}
	}
}
