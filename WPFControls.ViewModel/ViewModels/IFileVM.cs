using WPFControls.Model;

namespace WPFControls.ViewModel.ViewModels
{
	/// <summary>
	/// Модель представления файла
	/// </summary>
	public interface IFileVM
	{
		/// <summary>
		/// Возвращает имя файла
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Конвертирует модель представления файла в файл
		/// </summary>
		/// <returns>Файл, соответствующий модели представления</returns>
		File ConvertToFile();
	}
}