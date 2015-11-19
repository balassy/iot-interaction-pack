using System;
using System.Diagnostics.CodeAnalysis;
using Windows.ApplicationModel;


namespace Wicip.Sample.ViewModels
{
	internal class SettingsPageViewModel : Template10.Mvvm.ViewModelBase
	{
		public AboutPartViewModel AboutPartViewModel { get; } = new AboutPartViewModel();
	}


	internal class AboutPartViewModel : Template10.Mvvm.ViewModelBase
	{
		[SuppressMessage( "Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "View model" )]
		public Uri Logo => Package.Current.Logo;

		[SuppressMessage( "Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "View model" )]
		public string DisplayName => Package.Current.DisplayName;

		[SuppressMessage( "Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "View model" )]
		public string Publisher => Package.Current.PublisherDisplayName;

		[SuppressMessage( "Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "View model" )]
		public string Version
		{
			get
			{
				PackageVersion ver = Package.Current.Id.Version;
				return FormattableString.Invariant( $"{ver.Major}.{ver.Minor}.{ver.Build}.{ver.Revision}");
			}
		}

		[SuppressMessage( "Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "View model" )]
		public string Homepage => @"https://github.com/balassy/iot-interaction-pack";
	}

}
