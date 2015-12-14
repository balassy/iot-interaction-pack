using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Wicip.Sample.Views
{
	public sealed partial class VoiceRecognitionPage : Page, IDisposable
	{
		private Microphone microphone;


		public VoiceRecognitionPage()
		{
			this.InitializeComponent();			
		}


		public void Dispose()
		{
			if( this.microphone != null )
			{
				this.microphone.Dispose();
			}
		}


		protected override async void OnNavigatedTo( NavigationEventArgs e )
		{
			base.OnNavigatedTo( e );

			this.microphone = new Microphone();
			await this.microphone.InitializeAsync();
		}


		protected override void OnNavigatingFrom( NavigatingCancelEventArgs e )
		{
			this.Dispose();
			base.OnNavigatingFrom( e );
		}


		private async void btnListen_Click( object sender, RoutedEventArgs e )
		{
			Shell.SetBusyVisibility( Visibility.Visible, "I'm listening..." );

			string recognizedText = await this.microphone.ListenAsync();
			this.tblRecognizedText.Text = recognizedText;

			Shell.SetBusyVisibility( Visibility.Collapsed );
		}
	}
}
