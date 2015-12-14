using System;


namespace Wicip
{
	public class RfidCardScannedEventArgs : EventArgs
	{
		public string CardContent { get; set; }
	}
}
