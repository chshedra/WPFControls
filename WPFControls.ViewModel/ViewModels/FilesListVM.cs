using System.Collections.ObjectModel;
using System.Collections.Specialized;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using WPFControls.Model;
using WPFControls.ViewModel.IServices;

namespace WPFControls.ViewModel.ViewModels
{
    /// <summary>
    /// Модель представления списка файлов
    /// </summary>
    public class FilesListVM :  ViewModelBase
    {
	    /// <summary>
        /// Хранит объект модели
        /// </summary>
	    private readonly FilesListModel _model;

        /// <summary>
        /// Хранит сервис открытия окна файлов
        /// </summary>
	    private readonly IFilesWindowService _filesWindowService;

        /// <summary>
        /// Хранит команду добавления имени файла
        /// </summary>
	    private RelayCommand _addCommand;

        /// <summary>
        /// Хранит команду удаления имени файла
        /// </summary>
        private RelayCommand<IFileVM> _removeCommand;

	    /// <summary>
        /// Возвращает и устанавливает список файлов
        /// </summary>
        public ObservableCollection<IFileVM> FilesList { get; set; } = 
		    new ObservableCollection<IFileVM>();

	    /// <summary>
        /// Создает объект модели представления списка файлов
        /// </summary>
        public FilesListVM(IFilesWindowService filesWindowService)
        {
            _model = new FilesListModel();
            _filesWindowService = filesWindowService;
            FilesList.CollectionChanged += FileList_CollectionChanged;
        }

        /// <summary>
        /// Устанавливает и возвращает команду добавления имени файла
        /// </summary>
        public RelayCommand AddCommand
        {
			get
			{
				return _addCommand ??
				       (_addCommand = new RelayCommand(() =>
				       {
					       if (_filesWindowService.OpenFileDialog())
					       {
                               foreach (string file in _filesWindowService.FileNames)
                               {
                                 FilesList.Add(new FileVM(file));
                               }
                               RaisePropertyChanged(nameof(FilesList));
                               _filesWindowService.FileNames.Clear();
					       }
				       }));
			}
		}

        /// <summary>
        /// Устанавливает и возвращает команду удаления имени файла
        /// </summary>
        public RelayCommand<IFileVM> RemoveCommand
        {
	        get
	        {
		        return _removeCommand ??
		               (_removeCommand = new RelayCommand<IFileVM>(
			               (obj) =>
			               {
				               FilesList.Remove(obj);

				               RaisePropertyChanged(nameof(FilesList));
			               }));
	        }

        }

        /// <summary>
        /// Обработчик события изменения коллекции моделей представления файлов
        /// </summary>
        private void FileList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
	        switch (e.Action)
	        {
		        case NotifyCollectionChangedAction.Add:
		        {
			        foreach (var file in e.NewItems)
			        {
                        _model.FilesList.Add(file as File);
			        }
			        break;
		        }
		        case NotifyCollectionChangedAction.Remove:
		        {
			        foreach (var file in e.OldItems)
			        {
				        _model.FilesList.Remove(file as File);
			        }
                    break;
		        }
	        }
        }
    }
}
