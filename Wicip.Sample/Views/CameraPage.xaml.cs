using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Wicip.Sample.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


namespace Wicip.Sample.Views
{
	public sealed partial class CameraPage : Page
	{
		private Camera camera;

		private CameraPageViewModel viewModel;


		public CameraPage()
		{
			this.InitializeComponent();

			this.viewModel = new CameraPageViewModel();
			this.DataContext = this.viewModel;
		}


		protected override async void OnNavigatedTo( NavigationEventArgs e )
		{
			base.OnNavigatedTo( e );

			this.camera = new Camera();
			await this.camera.InitializeAsync();

			this.viewModel.CameraName = ( await this.camera.GetCameraInformationAsync() ).Name;
			this.viewModel.MaxResolution = this.camera.GetMaxResolution();
		}


		private async void btnTakePhoto_Click( object sender, RoutedEventArgs e )
		{
			StorageFile photoFile = await this.camera.CapturePhotoToFileAsync();
			this.viewModel.PhotoFile = photoFile;

			//this.txtStatus.Text = $"Photo successfully captured to {photoFile.Path}";

			// NOTE: We could use this.imgPreview.Source = new BitmapImage(new Uri(photoFile.Path)) here, however images are cached when loaded from Uri.
			//       To make sure the image is always updated on the UI, we use this more complex code.            
			//BitmapImage image = new BitmapImage();
			//using( IRandomAccessStream stream = await photoFile.OpenReadAsync() )
			//{
			//	await image.SetSourceAsync( stream );
			//}
			//this.viewModel.PhotoImage = image;
		}

	}
}
