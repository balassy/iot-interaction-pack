using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace Wicip.Sample.ViewModels
{
	internal class CameraPageViewModel : Template10.Mvvm.ViewModelBase
	{
		private string cameraName;

		public string CameraName
		{
			get { return this.cameraName; }
			set
			{
				this.cameraName = value;
				base.RaisePropertyChanged();
			}
		}


		private IEnumerable<VideoEncodingProperties> resolutions;

		public IEnumerable<VideoEncodingProperties> Resolutions
		{
			get { return this.resolutions; }
			set
			{
				this.resolutions = value;
				base.RaisePropertyChanged();
			}
		}


		private VideoEncodingProperties maxResolution;

		public VideoEncodingProperties MaxResolution
		{
			get { return this.maxResolution; }
			set
			{
				this.maxResolution = value;
				base.RaisePropertyChanged();
			}
		}


		private VideoEncodingProperties selectedResolution;

		public VideoEncodingProperties SelectedResolution
		{
			get { return this.selectedResolution; }
			set
			{
				this.selectedResolution = value;
				base.RaisePropertyChanged();
			}
		}


		private StorageFile photoFile;

		public StorageFile PhotoFile
		{
			get { return this.photoFile; }
			set
			{
				this.photoFile = value;
				base.RaisePropertyChanged();

				this.PhotoImage = NotifyTaskCompletion.Create<BitmapImage>( LoadImageFromFile( this.photoFile ) );
			}
		}


		private INotifyTaskCompletion<BitmapImage> photoImage;

		public INotifyTaskCompletion<BitmapImage> PhotoImage
		{
			get { return this.photoImage; }
			set
			{
				this.photoImage = value;
				base.RaisePropertyChanged();
			}
		}



		private static async Task<BitmapImage> LoadImageFromFile( StorageFile file )
		{
			BitmapImage image = new BitmapImage();
			using( IRandomAccessStream stream = await file.OpenReadAsync() )
			{
				await image.SetSourceAsync( stream );
			}
			return image;
		}

	}
}
