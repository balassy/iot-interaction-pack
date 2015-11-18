using System;
using Windows.Devices.Gpio;

namespace Wicip
{
	public class Led
	{
		GpioPin pin;

		public Led( int pinId )
		{
			GpioController controller = GpioController.GetDefault();
			this.pin = controller.OpenPin( pinId );
			this.pin.Write( GpioPinValue.High );
			this.pin.SetDriveMode( GpioPinDriveMode.Output );
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
