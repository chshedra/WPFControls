namespace WPFControls.ViewModel
{
	/// <summary>
	/// Сервис вызова окна файлов
	/// </summary>
	public interface IFilesWindowService
	{
		/// <summary>
		/// Название выбранного файла
		/// </summary>
		string FileName { get; set;}

		/// <summary>
		/// Открывает диалоговое окно для выбора файла
		/// </summary>
		/// <returns>Возращает true, если файл выбран</returns>
		bool OpenFileDialog();

	}
}