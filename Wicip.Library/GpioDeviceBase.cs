using Windows.Devices.Gpio;

namespace Wicip
{
	public abstract class GpioDeviceBase
	{
		public static bool IsAvailable
		{
			get
			{
				return GpioController.GetDefault() != null;
			}
		}

	}
}
