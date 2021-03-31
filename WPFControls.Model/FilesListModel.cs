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
        public ObservableCollection<File> FilesList { get; set; }
        
        //TODO: Зачем конструктор по-умолчанию, если можно сразу присвоить свойству?
        /// <summary>
        /// Создает объект модели
        /// </summary>
        public FilesListModel()
        {
            FilesList = new ObservableCollection<File>();
        }
    }
}
