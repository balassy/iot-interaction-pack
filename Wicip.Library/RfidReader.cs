using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.Gpio;
using Windows.Devices.I2c;

namespace Wicip
{
	public sealed class RfidReader : GpioDeviceBase, IDisposable
	{
		private const int ARDUINO_ADDRESS = 0x42;

		private byte[] GET_CARD_CONTENT_COMMAND = new byte[] { 0x03, 0x00, 0x00 };

		public event EventHandler<RfidCardScannedEventArgs> CardScanned;

		private GpioPin pin;

		private I2cDevice arduino;


		public RfidReader( int pinNumber )
		{
			this.InitPin( pinNumber );
		}


		public void Dispose()
		{
			if( this.pin != null )
			{
				this.pin.Dispose();
			}

			if( this.arduino != null )
			{
				this.arduino.Dispose();
			}
		}


		public async Task InitializeAsync()
		{
			string selector = I2cDevice.GetDeviceSelector();
			IReadOnlyList<DeviceInformation> i2cDevices = await DeviceInformation.FindAllAsync( selector );

			I2cConnectionSettings connectionSettings = new I2cConnectionSettings( ARDUINO_ADDRESS );
			this.arduino = await I2cDevice.FromIdAsync( i2cDevices[ 0 ].Id, connectionSettings );

			if( this.arduino == null )
			{
				throw new InvalidOperationException( $"The I2C device on address {ARDUINO_ADDRESS} cannot be found or is currently in use by another application." );
			}
		}


		private void InitPin( int pinNumber )
		{
			GpioController controller = GpioController.GetDefault();
			this.pin = controller.OpenPin( pinNumber );
			this.pin.SetDriveMode( GpioPinDriveMode.Input );
			this.pin.ValueChanged += this.OnPinValueChanged;
		}


		private void OnPinValueChanged( GpioPin sender, GpioPinValueChangedEventArgs args )
		{
			if( args.Edge == GpioPinEdge.RisingEdge )
			{
				// Do anything only if there is at least one subscriber.
				if( this.CardScanned != null )
				{
					// NOTE: We don't use I2cDevice.WriteRead as Arduino does not work with it.
					this.arduino.Write( GET_CARD_CONTENT_COMMAND );

					byte[] rawCardContent = new byte[ 4 ];
					I2cTransferResult transferResult = this.arduino.ReadPartial( rawCardContent );
					if( transferResult.Status == I2cTransferStatus.FullTransfer )
					{
						string cardContent = BitConverter.ToString( rawCardContent );
						this.CardScanned( this, new RfidCardScannedEventArgs { CardContent = cardContent } );
					}
				}
			}
		}

	}
}
