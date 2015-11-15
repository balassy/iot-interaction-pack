using System;


namespace Wicip
{
	public class MicrophonePrivacyException : Exception
	{
		public MicrophonePrivacyException() : base()
		{
		}


		public MicrophonePrivacyException( string message ) : base( message )
		{
		}


		public MicrophonePrivacyException( string message, Exception innerException ) : base( message, innerException )
		{
		}

	}
}
