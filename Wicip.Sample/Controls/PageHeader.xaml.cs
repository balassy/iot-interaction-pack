using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace Wicip.Sample.Controls
{
	public sealed partial class PageHeader : UserControl
	{
		public string Text
		{
			get { return this.header.Text; }
			set { this.header.Text = value; }
		}


		public Frame Frame
		{
			get { return this.header.Frame; }
			set { this.header.Frame = value; }
		}


		public PageHeader()
		{
			this.InitializeComponent();

			Binding contentBinding = new Binding
			{
				Path = new PropertyPath( "Frame" ),
				Mode = BindingMode.OneWay
			};
			BindingOperations.SetBinding( this.header, Template10.Controls.PageHeader.FrameProperty, contentBinding );
		}

	}
}
