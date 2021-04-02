using System.Collections.ObjectModel;

namespace WPFControls.ViewModel.IServices
{
	/// <summary>
	/// Сервис вызова окна файлов
	/// </summary>
	public interface IFilesWindowService
	{
		/// <summary>
		/// Название выбранного файла
		/// </summary>
		ObservableCollection<string> FileNames { get; set;}

		/// <summary>
		/// Открывает диалоговое окно для выбора файла
		/// </summary>
		/// <returns>Возращает true, если файл выбран</returns>
		bool OpenFileDialog();
	}
}