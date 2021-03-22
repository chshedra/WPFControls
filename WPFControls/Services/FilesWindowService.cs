using Microsoft.Win32;
using WPFControls.ViewModel;
using WPFControls.ViewModel.IServices;

namespace WPFControls.Services
{
	/// <inheritdoc/>
	public class FilesWindowService : IFilesWindowService
	{
		/// <inheritdoc/>
		public string FileName { get; set; }

		/// <inheritdoc/>
		public bool OpenFileDialog()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "All files (*.*)|*.*";
			if (openFileDialog.ShowDialog() == true)
			{
				FileName = openFileDialog.SafeFileName;
				return true;
			}
			return false;
		}
	}
}