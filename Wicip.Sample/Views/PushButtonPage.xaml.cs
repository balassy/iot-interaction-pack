using System;
using System.Diagnostics.CodeAnalysis;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Wicip.Sample.Views
{
	public sealed partial class PushButtonPage : Page, IDisposable
	{
		PushButton button;

		public PushButtonPage()
		{
			this.InitializeComponent();
		}


		public void Dispose()
		{
			if( this.button != null )
			{
				this.button.Dispose();
			}
		}


		protected override void OnNavigatedTo( NavigationEventArgs e )
		{
			base.OnNavigatedTo( e );
			this.viewModel.IsAvailable = PushButton.IsAvailable;
		}


		protected override void OnNavigatingFrom( NavigatingCancelEventArgs e )
		{
			base.OnNavigatingFrom( e );
			this.Dispose();
		}


		[SuppressMessage( "Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "task", Justification = "Simpler code." )]
		private void OnButtonPushed( object sender, EventArgs e )
		{
			var task = this.Dispatcher.RunAsync( CoreDispatcherPriority.Normal, () =>
			 {
				 this.viewModel.IsOn = true;
			 } );
		}


		[SuppressMessage( "Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "task", Justification = "Simpler code." )]
		private void OnButtonReleased( object sender, EventArgs e )
		{
			var task = this.Dispatcher.RunAsync( CoreDispatcherPriority.Normal, () =>
			{
				this.viewModel.IsOn = false;
			} );
		}


		private void btnStartMonitor_Click( object sender, RoutedEventArgs e )
		{
			if( this.button != null )
			{
				this.button.Pushed -= this.OnButtonPushed;
				this.button.Released -= this.OnButtonReleased;
				this.button.Dispose();
			}

			this.button = new PushButton( this.viewModel.PinNumber );
			this.button.Pushed += this.OnButtonPushed;
			this.button.Released += this.OnButtonReleased;

			this.tsIsOn.Visibility = Visibility.Visible;
		}

	}
}
