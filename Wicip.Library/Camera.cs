using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
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
			//await this.SetResolutionAsync( 640, 480 );
			this.isInitialized = true;
		}


		[SuppressMessage( "Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Contains asynchronous operation." )]
		public async Task<DeviceInformation> GetCameraInformationAsync()
		{
			DeviceInformationCollection cameraDevices = await DeviceInformation.FindAllAsync( DeviceClass.VideoCapture );
			return cameraDevices.First();
		}


		[SuppressMessage( "Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Contains complex logic." )]
		public VideoEncodingProperties GetMaxResolution()
		{
			this.AssertInitialized();

			IReadOnlyList<IMediaEncodingProperties> resolutions = this.captureManager.VideoDeviceController.GetAvailableMediaStreamProperties( MediaStreamType.VideoPreview );
			uint maxWidth = 0;
			int indexMaxResolution = 0;

			if( resolutions.Count >= 1 )
			{
				for( int i = 0; i < resolutions.Count; i++ )
				{
					VideoEncodingProperties vp = (VideoEncodingProperties) resolutions[ i ];

					if( vp.Width > maxWidth )
					{
						indexMaxResolution = i;
						maxWidth = vp.Width;
					}
				}

				return (VideoEncodingProperties) resolutions[ indexMaxResolution ];
			}
			else
			{
				return null;
			}
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
