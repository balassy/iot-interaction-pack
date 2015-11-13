using System;
using System.Collections.Generic;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Wicip.Sample.Views
{
	public sealed partial class SpeechSynthesisPage : Page, IDisposable
	{
		private Speaker speaker;


		public SpeechSynthesisPage()
		{
			this.InitializeComponent();
		}


		public void Dispose()
		{
			if( this.speaker != null )
			{
				this.speaker.Dispose();
			}
		}


		protected override void OnNavigatedTo( NavigationEventArgs e )
		{
			base.OnNavigatedTo( e );

			this.speaker = new Speaker();

			this.cboGender.ItemsSource = new List<KeyValuePair<string, VoiceGender>>
			{
				new KeyValuePair<string, VoiceGender>( "Female", VoiceGender.Female ),
				new KeyValuePair<string, VoiceGender>( "Male", VoiceGender.Male )
			};
			this.cboGender.SelectedIndex = 0;
		}


		protected override void OnNavigatingFrom( NavigatingCancelEventArgs e )
		{
			base.OnNavigatingFrom( e );

			this.Dispose();
		}


		private async void btnSay_Click( object sender, RoutedEventArgs e )
		{
			this.speaker.SetVoice( (VoiceGender) this.cboGender.SelectedValue );

			SpeechSynthesisStream stream = await this.speaker.SynthesizeText( this.txtMessage.Text );
			this.mediaElement.SetSource( stream, stream.ContentType );
			this.mediaElement.Play();
		}

	}
}
