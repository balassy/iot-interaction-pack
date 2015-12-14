using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.Media.SpeechRecognition;

namespace Wicip
{
	public sealed class Microphone : IDisposable
	{
		private SpeechRecognizer recognizer;

		private bool isInitialized;


		public Microphone()
		{
			this.recognizer = new SpeechRecognizer();
			this.isInitialized = false;
		}


		public void Dispose()
		{
			if( this.recognizer != null )
			{
				this.recognizer.Dispose();
			}
		}


		public async Task InitializeAsync()
		{
			this.recognizer.Timeouts.EndSilenceTimeout = TimeSpan.FromSeconds( 1.1 );
			this.recognizer.Timeouts.InitialSilenceTimeout = TimeSpan.FromSeconds( 2.0 );

			// Compile the default dictation grammar.
			await this.recognizer.CompileConstraintsAsync();

			this.isInitialized = true;
		}


		public async Task<string> ListenAsync()
		{
			this.AssertInitialized();

			try
			{
				// Start recognition.
				SpeechRecognitionResult result = await this.recognizer.RecognizeAsync();
				return result.Text;
			}
			catch( Exception exception )
			{
				// Handle the speech privacy policy error.
				if( (uint) exception.HResult == 0x80045509 )
				{
					throw new MicrophonePrivacyException("The application could not access your microphone, please check your Privacy in the Settings app.", exception);
				}
				else
				{
					throw;
				}
			}
		}



		[SuppressMessage( "Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)", Justification = "Using the current culture is perfect here." )]
		private void AssertInitialized( [CallerMemberName] string callerMethodName = "" )
		{
			if( !this.isInitialized )
			{
				throw new InvalidOperationException( $"The Microphone instance must be initialized before calling the {callerMethodName} method." );
			}
		}

	}
}
