using System;
using System.Diagnostics.CodeAnalysis;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Template10.Common;
using Template10.Services.NavigationService;

namespace Wicip.Sample.Views
{
	public sealed partial class Shell : Page
	{
		public static Shell Instance { get; set; }


		public Shell( NavigationService navigationService )
		{
			Shell.Instance = this;
			this.InitializeComponent();
			this.menu.NavigationService = navigationService;
			VisualStateManager.GoToState( this, this.NormalVisualState.Name, useTransitions: true );
		}


		[SuppressMessage( "Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "We love default values." )]
		public static void SetBusyVisibility( Visibility visible, string text = null )
		{
			WindowWrapper.Current().Dispatcher.Dispatch( () =>
			{
				switch( visible )
				{
					case Visibility.Visible:
						Shell.Instance.FindName( nameof( busyScreen ) );
						Shell.Instance.tblBusy.Text = text ?? String.Empty;
						if( VisualStateManager.GoToState( Shell.Instance, Shell.Instance.BusyVisualState.Name, useTransitions: true ) )
						{
							SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
						}
						break;

					case Visibility.Collapsed:
						if( VisualStateManager.GoToState( Shell.Instance, Shell.Instance.NormalVisualState.Name, useTransitions: true ) )
						{
							BootStrapper.Current.UpdateShellBackButton();
						}
						break;
				}
			} );
		}

	}
}
