using System.Windows;
using WPFControls.Services;
using WPFControls.ViewModel;
using WPFControls.ViewModel.ViewModels;

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
	}
}
