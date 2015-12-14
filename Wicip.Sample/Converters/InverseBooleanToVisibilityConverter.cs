using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Wicip.Sample.Converters
{
	/// <summary>
	/// Value converter that converts <c>true</c> to <see cref="Visibility.Visible"/> and <c>false</c> to <see cref="Visibility.Collapsed"/>.
	/// </summary>
	public sealed class InverseBooleanToVisibilityConverter : IValueConverter
	{
		public object Convert( object value, Type targetType, object parameter, string language )
		{
			return value is bool && (bool) value
				? Visibility.Collapsed 
				: Visibility.Visible;
		}


		public object ConvertBack( object value, Type targetType, object parameter, string language )
		{
			return value is Visibility && (Visibility) value == Visibility.Visible;
		}
	}
}
