using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Wicip.Sample.Views
{
	public sealed partial class UltrasonicSensorPage : Page, IDisposable
	{
		private UltrasonicSensor sensor;

		private readonly DispatcherTimer measureTimer = new DispatcherTimer();

		public UltrasonicSensorPage()
		{
			this.InitializeComponent();
		}


		public void Dispose()
		{
			if( this.sensor != null )
			{
				this.sensor.Dispose();
			}
		}


		protected override void OnNavigatedTo( NavigationEventArgs e )
		{
			base.OnNavigatedTo( e );
			this.viewModel.IsAvailable = UltrasonicSensor.IsAvailable;
		}


		protected override void OnNavigatingFrom( NavigatingCancelEventArgs e )
		{
			base.OnNavigatingFrom( e );
			this.Dispose();
		}


		private void btnStartControl_Click( object sender, RoutedEventArgs e )
		{
			this.sensor = new UltrasonicSensor( this.viewModel.TriggerPinNumber, this.viewModel.EchoPinNumber );

			// Measure and display distance every second.
			this.measureTimer.Tick += ( s, args ) =>
			{
				this.viewModel.Distance = sensor.GetDistance();
			};

			this.measureTimer.Interval = TimeSpan.FromSeconds( 0.5 );
			this.measureTimer.Start();

			this.tblDistancePrompt.Visibility = Visibility.Visible;
			this.tblDistance.Visibility = Visibility.Visible;
			this.pbDistance.Visibility = Visibility.Visible;
		}

	}
}
