using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFControls.Services;
using WPFControls.ViewModel;

namespace WPFControls
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			this.DataContext = new FilesListVM(new FilesWindowService());
		}

		private void FilesListView_OnSizeChanged(object sender, SizeChangedEventArgs e)
		{
			var windowHeader = 50;
			if (FilesListView.ActualHeight >= Window.ActualHeight - AddButton.ActualHeight - windowHeader &&
			    FilesListView.MaxHeight >= FilesListView.ActualHeight)
			{
				FilesListView.MaxHeight = FilesListView.ActualHeight;
			}
		}

		private void MainWindow_OnSizeChanged(object sender, SizeChangedEventArgs e)
		{
			var windowHeader = 50;
			FilesListView.MaxHeight = Window.ActualHeight - AddButton.Height - windowHeader;
		}
	}
}
