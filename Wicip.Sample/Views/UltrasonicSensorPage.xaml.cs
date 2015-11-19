using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Wicip.Sample.Views
{
	public sealed partial class UltrasonicSensorPage : Page
	{
		private UltrasonicSensor sensor;

		private readonly DispatcherTimer measureTimer = new DispatcherTimer();

		public UltrasonicSensorPage()
		{
			this.InitializeComponent();

			const int TRIGGER_PIN = 5; // Sensor's Trigger pin connected to GPIO5.
			const int ECHO_PIN = 6;    // Sensor's Echo pin connected to GPIO6.

			this.sensor = new UltrasonicSensor( TRIGGER_PIN, ECHO_PIN );
		}

		protected override void OnNavigatedTo( NavigationEventArgs e )
		{
			base.OnNavigatedTo( e );
			
			// Measure and display distance every second.
			this.measureTimer.Tick += ( sender, args ) =>
			{
				this.viewModel.Distance = sensor.GetDistance();
			};

			this.measureTimer.Interval = TimeSpan.FromSeconds( 0.5 );
			this.measureTimer.Start();
		}

	}
}
