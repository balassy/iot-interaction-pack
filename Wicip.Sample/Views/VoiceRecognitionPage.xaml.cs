using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace Wicip.Sample.Views
{
	public sealed partial class VoiceRecognitionPage : Page
	{
		private Microphone microphone;

		public VoiceRecognitionPage()
		{
			this.InitializeComponent();
			
		}


		protected override async void OnNavigatedTo( NavigationEventArgs e )
		{
			base.OnNavigatedTo( e );

			this.microphone = new Microphone();
			await this.microphone.InitializeAsync();
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
