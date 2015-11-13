using System;
using System.Linq;
using Windows.Foundation;
using Windows.Media.SpeechSynthesis;

namespace Wicip
{
	public class Speaker : IDisposable
	{
		private SpeechSynthesizer synthesizer;


		public Speaker()
		{
			this.synthesizer = new SpeechSynthesizer();
		}


		public void SetVoice( VoiceGender gender )
		{
			this.synthesizer.Voice = SpeechSynthesizer.AllVoices.First( v => v.Gender == gender );
		}


		public IAsyncOperation<SpeechSynthesisStream> SynthesizeText( string text )
		{
			return this.synthesizer.SynthesizeTextToStreamAsync( text );
		}


		public IAsyncOperation<SpeechSynthesisStream> SynthesizeMarkup( string ssml )
		{
			return this.synthesizer.SynthesizeSsmlToStreamAsync( ssml );
		}


		public void Dispose()
		{
			if( this.synthesizer != null )
			{
				this.synthesizer.Dispose();
			}
		}

	}
}
