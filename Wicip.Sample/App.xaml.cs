using System.Threading.Tasks;
using Template10.Services.NavigationService;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

using Wicip.Sample.Views;

namespace Wicip.Sample
{
	sealed partial class App : Template10.Common.BootStrapper
	{
		public App()
		{
			this.InitializeComponent();
		}

		public override async Task OnStartAsync( StartKind startKind, IActivatedEventArgs args )
		{
			NavigationService.Navigate( typeof( MainPage ) );
			await Task.Yield();
		}


		public override Task OnInitializeAsync( IActivatedEventArgs args )
		{
			// Setup the hamburger shell.
			NavigationService navigationService = NavigationServiceFactory( BackButton.Attach, ExistingContent.Include );
			Window.Current.Content = new Shell( navigationService );
			return Task.FromResult<object>( null );
		}
	}
}

