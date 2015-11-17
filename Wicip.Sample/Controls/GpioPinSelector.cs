using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace Wicip.Sample.Controls
{
	public class GpioPinSelector : ComboBox
	{
		public GpioPinSelector()
		{
			this.DisplayMemberPath = "Key";
			this.SelectedValuePath = "Value";
			this.Width = 250;

			this.ItemsSource = new List<KeyValuePair<string, int>>
			{
				new KeyValuePair<string, int>("GPIO 02 - pin 03 (SDA1, I2C)", 2),
				new KeyValuePair<string, int>("GPIO 03 - pin 05 (SCL1, I2C)", 3),
				new KeyValuePair<string, int>("GPIO 04 - pin 07 (GPIO_GCLK)", 4),
				new KeyValuePair<string, int>("GPIO 05 - pin 29", 5),
				new KeyValuePair<string, int>("GPIO 06 - pin 30", 6),
				new KeyValuePair<string, int>("GPIO 07 - pin 26 (SPI_CE1_N)", 7),
				new KeyValuePair<string, int>("GPIO 08 - pin 24 (SPI_CE0_N)", 8),
				new KeyValuePair<string, int>("GPIO 09 - pin 21 (SPI_MISO)", 9),
				new KeyValuePair<string, int>("GPIO 10 - pin 19 (SPI_MOSI)", 10),
				new KeyValuePair<string, int>("GPIO 11 - pin 23 (SPI_CLK)", 11),
				new KeyValuePair<string, int>("GPIO 12 - pin 32", 12),
				new KeyValuePair<string, int>("GPIO 13 - pin 33", 13),
				new KeyValuePair<string, int>("GPIO 14 - pin 08 (TXD0)", 14),
				new KeyValuePair<string, int>("GPIO 15 - pin 10 (RXD0)", 15),
				new KeyValuePair<string, int>("GPIO 16 - pin 36 (RXD0)", 16),
				new KeyValuePair<string, int>("GPIO 17 - pin 11 (GPIO_GEN0)", 17),
				new KeyValuePair<string, int>("GPIO 18 - pin 12 (GPIO_GEN1)", 18),
				new KeyValuePair<string, int>("GPIO 19 - pin 35", 19),
				new KeyValuePair<string, int>("GPIO 20 - pin 38", 20),
				new KeyValuePair<string, int>("GPIO 21 - pin 40", 21),
				new KeyValuePair<string, int>("GPIO 22 - pin 15 (GPIO_GEN3)", 22),
				new KeyValuePair<string, int>("GPIO 23 - pin 16 (GPIO_GEN4)", 23),
				new KeyValuePair<string, int>("GPIO 24 - pin 18 (GPIO_GEN5)", 24),
				new KeyValuePair<string, int>("GPIO 25 - pin 22 (GPIO_GEN6)", 25),
				new KeyValuePair<string, int>("GPIO 26 - pin 37", 26),
				new KeyValuePair<string, int>("GPIO 27 - pin 13 (GPIO_GEN2)", 27)
			};
    }
	}
}
