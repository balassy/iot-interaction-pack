using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
	public sealed partial class RfidPage : Page, IDisposable
	{
		private RfidReader reader;


		public RfidPage()
		{
			this.InitializeComponent();
		}


		public void Dispose()
		{
			if( this.reader != null )
			{
				this.reader.Dispose();
			}
		}


		protected override void OnNavigatedTo( NavigationEventArgs e )
		{
			base.OnNavigatedTo( e );
			this.viewModel.IsAvailable = RfidReader.IsAvailable;
		}


		protected override void OnNavigatingFrom( NavigatingCancelEventArgs e )
		{
			this.Dispose();
			base.OnNavigatingFrom( e );
		}


		private void btnStartMonitor_Click( object sender, RoutedEventArgs e )
		{
			this.reader = new RfidReader( this.viewModel.PinNumber );
		}
	}
}
