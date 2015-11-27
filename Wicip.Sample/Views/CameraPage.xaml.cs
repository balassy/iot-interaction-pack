using System;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


namespace Wicip.Sample.Views
{
	public sealed partial class CameraPage : Page
	{
		private Camera camera;


		public CameraPage()
		{
			this.InitializeComponent();
		}


		protected override async void OnNavigatedTo( NavigationEventArgs e )
		{
			base.OnNavigatedTo( e );

			this.camera = new Camera();
			await this.camera.InitializeAsync();

			this.viewModel.CameraName = ( await this.camera.GetCameraInformationAsync() ).Name;
			this.viewModel.MaxResolution = this.camera.MaxResolution;
			this.viewModel.Resolutions = this.camera.Resolutions;
			this.cboResolutions.SelectedIndex = 0;
		}


		private async void btnTakePhoto_Click( object sender, RoutedEventArgs e )
		{
			Shell.SetBusyVisibility( Visibility.Visible, "Saving photo..." );

			await this.camera.SetResolutionAsync( this.viewModel.SelectedResolution );
			StorageFile photoFile = await this.camera.CapturePhotoToFileAsync();
			this.viewModel.PhotoFile = photoFile;

			Shell.SetBusyVisibility( Visibility.Collapsed );
		}

		private async void btnStartPreview_Click( object sender, RoutedEventArgs e )
		{
			this.previewElement.Source = this.camera.CaptureManager;
			await this.camera.CaptureManager.StartPreviewAsync();
		}
	}
}
