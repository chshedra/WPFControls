using System.Windows;
using WPFControls.Services;
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
			//TODO: В ListView написано вот так Path=ActualHeight-40 - что это? О_О
			this.DataContext = new FilesListVM(new FilesWindowService());
		}
	}
}
