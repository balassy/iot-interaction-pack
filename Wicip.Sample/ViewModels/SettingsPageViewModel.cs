using System;
using Windows.ApplicationModel;


namespace Wicip.Sample.ViewModels
{
	public class SettingsPageViewModel : Template10.Mvvm.ViewModelBase
	{
		public AboutPartViewModel AboutPartViewModel { get; } = new AboutPartViewModel();
}



	public class AboutPartViewModel : Template10.Mvvm.ViewModelBase
	{
		public Uri Logo => Package.Current.Logo;

		public string DisplayName => Package.Current.DisplayName;

		public string Publisher => Package.Current.PublisherDisplayName;

		public string Version
		{
			get
			{
				PackageVersion ver = Package.Current.Id.Version;
				return $"{ver.Major}.{ver.Minor}.{ver.Build}.{ver.Revision}";
			}
		}

		public string HomePage => @"https://github.com/balassy/wicip";
	}

}
