using System;
using Windows.Devices.Gpio;

namespace Wicip
{
	public sealed class Led : GpioDeviceBase, IDisposable
	{
		GpioPin pin;

		public Led( int pinId )
		{
			GpioController controller = GpioController.GetDefault();
			this.pin = controller.OpenPin( pinId );
			this.pin.Write( GpioPinValue.High );
			this.pin.SetDriveMode( GpioPinDriveMode.Output );
		}

		public void Dispose()
		{
			if( this.pin != null )
			{
				this.pin.Dispose();
			}
		}


		public void TurnOn()
		{
			this.pin.Write( GpioPinValue.Low );
		}


		public void TurnOff()
		{
			this.pin.Write( GpioPinValue.High );
		}

	}
}
