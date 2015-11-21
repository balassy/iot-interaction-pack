using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

using Windows.Devices.Gpio;


namespace Wicip
{
	public sealed class UltrasonicSensor : GpioDeviceBase, IDisposable
	{
		private GpioPin triggerPin;
		private GpioPin echoPin;

		public UltrasonicSensor( int triggerPinNumber, int echoPinNumber )
		{
			GpioController controller = GpioController.GetDefault();

			// Initialize the Echo pin.
			this.echoPin = controller.OpenPin( echoPinNumber );
			this.echoPin.SetDriveMode( GpioPinDriveMode.Input );

			// Initialize the Trigger pin.
			this.triggerPin = controller.OpenPin( triggerPinNumber );
			this.triggerPin.SetDriveMode( GpioPinDriveMode.Output );

			// Ensure that the Trigger is initialized with a Low value.
			this.triggerPin.Write( GpioPinValue.Low );

			// Wait for the sensor to initialize.
			using( ManualResetEventSlim initTimer = new ManualResetEventSlim( false ) )
			{
				initTimer.Wait( TimeSpan.FromMilliseconds( 0.01 ) );
			}
		}

		public void Dispose()
		{
			if( this.triggerPin != null )
			{
				this.triggerPin.Dispose();
			}

			if( this.echoPin != null )
			{
				this.echoPin.Dispose();
			}
		}


		/// <summary>
		/// Returns the distance of the object.
		/// </summary>
		/// <returns>The distance of the object in centimeter, or <c>null</c> if the sensor returned no data.</returns>
		[SuppressMessage( "Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Contains complex logic." )]
		public double? GetDistance()
		{
			using( ManualResetEventSlim triggerTimer = new ManualResetEventSlim( false ) )
			{
				TimeSpan triggerPulseWidth = TimeSpan.FromMilliseconds( 0.01 ); // 10µs

				// Send the trigger pulse to start the measurement.
				this.triggerPin.Write( GpioPinValue.High );
				triggerTimer.Wait( triggerPulseWidth );
				this.triggerPin.Write( GpioPinValue.Low );

				// Measure the length of the echo pulse.
				double? echoPulseLengthInSeconds = UltrasonicSensor.PulseIn( this.echoPin, GpioPinValue.High );

				// Convert the length of the echo pulse to distance.
				// The speed of sound is 340 m/s = 34000 cm/s. Must be divided by 2, because the pulse makes a roundtrip.
				double? distanceInCm = echoPulseLengthInSeconds * 17000;

				return distanceInCm;
			}
		}


		/// <summary>
		/// Returns the duration of a pulse in seconds, or <c>null</c> if a timeout occurred.
		/// </summary>
		/// <param name="pin">The pin on which you want to read the pulse.</param>
		/// <param name="value">The type of the pulse to read.</param>
		/// <param name="timeoutInSeconds">The number of seconds to wait before timeout.</param>
		/// <returns>The duration of the pulse in seconds or <c>null</c> if no pulse is completed before the timeout.</returns>
		/// <remarks>
		/// This method is similar to Arduino's pulseIn() function, except that it returns <c>null</c> in case of timeout, not zero.
		/// </remarks>
		private static double? PulseIn( GpioPin pin, GpioPinValue value, int timeoutInSeconds = 1 )
		{
			Stopwatch pulseStopwatch = new Stopwatch();

			Stopwatch timeoutStopwatch = new Stopwatch();
			timeoutStopwatch.Start();

			// Wait for pulse start.
			while( pin.Read() != value )
			{
				if( timeoutStopwatch.Elapsed.TotalSeconds > timeoutInSeconds )
				{
					timeoutStopwatch.Stop();
					return null;
				}
			}
			pulseStopwatch.Start();

			// Wait for pulse end.
			while( pin.Read() == value )
			{
			}
			pulseStopwatch.Stop();

			return pulseStopwatch.Elapsed.TotalSeconds;
		}


	}
}
