using System;
using Windows.Devices.Gpio;

namespace Wicip
{
	public sealed class RfidReader : GpioDeviceBase, IDisposable
	{
		GpioPin pin;

		public RfidReader( int pinNumber )
		{
			GpioController controller = GpioController.GetDefault();
			this.pin = controller.OpenPin( pinNumber );
			this.pin.SetDriveMode( GpioPinDriveMode.InputPullDown );
		}


		public void Dispose()
		{
			if( this.pin != null )
			{
				this.pin.Dispose();
			}
		}

	}
}
