using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Wicip.Sample.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Wicip.Sample.Views
{
	public sealed partial class UltrasonicSensorPage : Page
	{
		private UltrasonicSensor sensor;

		private UltrasonicSensorPageViewModel viewModel;

		private readonly DispatcherTimer measureTimer = new DispatcherTimer();

		public UltrasonicSensorPage()
		{
			this.InitializeComponent();

			this.viewModel = new UltrasonicSensorPageViewModel();
			this.DataContext = this.viewModel;

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
