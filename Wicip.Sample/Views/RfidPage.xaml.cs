using System;
using System.Diagnostics.CodeAnalysis;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Wicip.Sample.Views
{
	public sealed partial class RfidPage : Page, IDisposable
	{
		private RfidReader reader;


		public RfidPage()
		{
			this.InitializeComponent();
		}


		public void Dispose()
		{
			if( this.reader != null )
			{
				this.reader.Dispose();
			}
		}


		protected override void OnNavigatedTo( NavigationEventArgs e )
		{
			base.OnNavigatedTo( e );
			this.viewModel.IsAvailable = RfidReader.IsAvailable;
		}


		protected override void OnNavigatingFrom( NavigatingCancelEventArgs e )
		{
			this.Dispose();
			base.OnNavigatingFrom( e );
		}


		private async void btnStartMonitor_Click( object sender, RoutedEventArgs e )
		{
			this.reader = new RfidReader( this.viewModel.PinNumber );
			this.reader.CardScanned += this.OnCardScanned;
			await this.reader.InitializeAsync();

			this.txbCardContentPrompt.Visibility = Visibility.Visible;
			this.txbCardContent.Visibility = Visibility.Visible;
		}


		[SuppressMessage( "Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "task", Justification = "Simpler code." )]
		private void OnCardScanned( object sender, RfidCardScannedEventArgs e )
		{
			var task = this.Dispatcher.RunAsync( CoreDispatcherPriority.Normal, () =>
			{
				this.viewModel.CardContent = e.CardContent;
			} );
		}
	}
}
