using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;

namespace Wicip
{
	public sealed class Camera : IDisposable
	{
		private MediaCapture captureManager;

		private bool isInitialized;


		public Camera()
		{
			this.captureManager = new MediaCapture();
			this.isInitialized = false;
		}


		public void Dispose()
		{
			if( this.captureManager != null )
			{
				this.captureManager.Dispose();
			}
		}


		public async Task InitializeAsync()
		{
			await this.captureManager.InitializeAsync();
			this.isInitialized = true;
		}


		[SuppressMessage( "Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Contains asynchronous operation." )]
		public async Task<DeviceInformation> GetCameraInformationAsync()
		{
			DeviceInformationCollection cameraDevices = await DeviceInformation.FindAllAsync( DeviceClass.VideoCapture );
			return cameraDevices.First();
		}


		public IEnumerable<VideoEncodingProperties> Resolutions
		{
			get
			{
				this.AssertInitialized();
				return this.captureManager.VideoDeviceController.GetAvailableMediaStreamProperties( MediaStreamType.VideoPreview )
					.Cast<VideoEncodingProperties>();
			}
		}

		public VideoEncodingProperties MaxResolution
		{
			get
			{
				this.AssertInitialized();

				return this.Resolutions
					.OrderByDescending( v => v.Width )
					.FirstOrDefault();
			}
		}


		public VideoEncodingProperties MinResolution
		{
			get
			{
				this.AssertInitialized();

				return this.Resolutions
					.OrderBy( v => v.Width )
					.FirstOrDefault();
			}
		}


		public async Task SetResolutionAsync(VideoEncodingProperties resolution)
		{
			this.AssertInitialized();

			await this.captureManager.VideoDeviceController.SetMediaStreamPropertiesAsync( MediaStreamType.VideoPreview, resolution );
		}


		[SuppressMessage( "Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed" )]
		public async Task<StorageFile> CapturePhotoToFileAsync( string fileName = "myphoto.jpg" )
		{
			this.AssertInitialized();

			StorageFile file = await ApplicationData.Current.TemporaryFolder.CreateFileAsync( fileName, CreationCollisionOption.ReplaceExisting );
			await this.captureManager.CapturePhotoToStorageFileAsync( ImageEncodingProperties.CreateJpeg(), file );
			return file;
		}


		[SuppressMessage( "Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)", Justification = "Using the current culture is perfect here." )]
		private void AssertInitialized( [CallerMemberName] string callerMethodName = "" )
		{
			if( !this.isInitialized )
			{
				throw new InvalidOperationException( $"The Camera instance must be initialized before calling the {callerMethodName} method." );
			}
		}
	}


}
