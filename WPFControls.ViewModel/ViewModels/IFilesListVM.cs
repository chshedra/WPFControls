using System.Collections.ObjectModel;
using WPFControls.Model;

namespace WPFControls.ViewModel
{
	/// <summary>
	/// Модель представления списка файлов
	/// </summary>
	public interface IFilesListVM
	{
		/// <summary>
		/// Хранит список отображаемых имен файлов
		/// </summary>
		ObservableCollection<File> FilesList { get; set; }
	}
}