using Microsoft.Win32;

namespace WPFControls.ViewModel
{
	public class FilesWindowService : IFilesWindowService
	{
		public string FileName { get; set; }

		
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