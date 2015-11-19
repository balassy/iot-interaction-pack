using System;
using Windows.Devices.Gpio;

namespace Wicip
{
	public sealed class PushButton : GpioDeviceBase, IDisposable
	{
		private GpioPin pin;

		public event EventHandler Pushed;

		public event EventHandler Released;


		public PushButton( int gpioPinNumber )
		{
			GpioController controller = GpioController.GetDefault();
			this.pin = controller.OpenPin( gpioPinNumber );
			this.pin.SetDriveMode( GpioPinDriveMode.InputPullUp );
			this.pin.DebounceTimeout = TimeSpan.FromMilliseconds( 50 );
			this.pin.ValueChanged += this.OnValueChanged;
		}

		private void OnValueChanged( GpioPin sender, GpioPinValueChangedEventArgs args )
		{
			EventHandler eventToFire = args.Edge == GpioPinEdge.FallingEdge
				? this.Pushed
				: this.Released;

			if( eventToFire != null )
			{
				eventToFire( this, new EventArgs() );
			}
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
