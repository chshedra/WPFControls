namespace WPFControls.ViewModel
{
	public interface IFilesWindowService
	{
		string FileName { get; set;}

		/// <summary>
		/// Открывает диалоговое окно для выбора файла
		/// </summary>
		/// <returns>Возращает true, если файл выбран</returns>
		bool OpenFileDialog();

	}
}