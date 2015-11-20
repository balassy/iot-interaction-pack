using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Wicip.Sample.Views
{
	internal sealed partial class LedPage : Page, IDisposable	
	{
		private Led led;


		public LedPage()
		{
			this.InitializeComponent();
		}


		public void Dispose()
		{
			if( this.led != null )
			{
				this.led.Dispose();
			}
		}


		protected override void OnNavigatedTo( NavigationEventArgs e )
		{
			base.OnNavigatedTo( e );
			this.viewModel.IsAvailable = Led.IsAvailable;
		}


		protected override void OnNavigatingFrom( NavigatingCancelEventArgs e )
		{
			this.Dispose();
			base.OnNavigatingFrom( e );
		}


		private void btnStartControl_Click( object sender, RoutedEventArgs e )
		{
			this.led = new Led( this.viewModel.PinNumber );

			this.txbIsOnPrompt.Visibility = Visibility.Visible;
			this.tsIsOn.Visibility = Visibility.Visible;
		}

		private void tsIsOn_Toggled( object sender, RoutedEventArgs e )
		{
			if( this.viewModel.IsOn )
			{
				this.led.TurnOn();
			}
			else
			{
				this.led.TurnOff();
			}
		}

	}
}
