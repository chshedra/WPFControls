using System.Collections.ObjectModel;

namespace WPFControls.Model
{
    /// <summary>
    /// Модель списка файлов
    /// </summary>
    public class FilesListModel
    {
	    /// <summary>
	    /// Хранит список названий файлов
	    /// </summary>
	    public ObservableCollection<File> FilesList { get; set; } = new ObservableCollection<File>();
    }
}
