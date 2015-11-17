using System;
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


		protected override void OnNavigatingFrom( NavigatingCancelEventArgs e )
		{
			base.OnNavigatingFrom( e );

			this.Dispose();
		}


		private void OnButtonPushed( object sender, EventArgs e )
		{
			this.viewModel.IsOn = true;
		}


		private void OnButtonReleased( object sender, EventArgs e )
		{
			this.viewModel.IsOn = false;
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
