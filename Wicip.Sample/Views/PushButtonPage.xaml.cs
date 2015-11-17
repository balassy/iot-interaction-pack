﻿using System;
using Windows.UI.Xaml.Controls;

namespace Wicip.Sample.Views
{
	public sealed partial class PushButtonPage : Page
	{
		PushButton button;

		public PushButtonPage()
		{
			this.InitializeComponent();
		}

		private void OnButtonPushed( object sender, EventArgs e )
		{
			this.viewModel.IsOn = true;
		}

		private void OnButtonReleased( object sender, EventArgs e )
		{
			this.viewModel.IsOn = false;
		}

		private void btnStartMonitor_Click( object sender, Windows.UI.Xaml.RoutedEventArgs e )
		{
			if( this.button != null )
			{
				this.button.Pushed -= this.OnButtonPushed;
				this.button.Released -= this.OnButtonReleased;
				this.button.Dispose();
			}

			this.button = new PushButton( this.viewModel.PinNumber );
			this.button.Pushed += this.OnButtonPushed;
			this.button.Released += this.OnButtonReleased;
		}

	}
}
