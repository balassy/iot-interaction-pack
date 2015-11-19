using System.IO;
using Windows.Devices.Gpio;

namespace Wicip
{
	public abstract class GpioDeviceBase
	{
		public static bool IsAvailable
		{
			get
			{
				try
				{
					return GpioController.GetDefault() != null;
				}
				catch( FileNotFoundException )
				{
					return false;
				}
			}
		}

	}
}
