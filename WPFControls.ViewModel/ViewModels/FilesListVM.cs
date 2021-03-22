using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using WPFControls.Model;
using WPFControls.ViewModel.IServices;

namespace WPFControls.ViewModel.ViewModels
{
    /// <inheritdoc cref="IFilesListVM"/>
    public class FilesListVM :  ViewModelBase, IFilesListVM
    {
	    /// <summary>
        /// Хранит объект модели
        /// </summary>
	    private FilesListModel _model;

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
        private RelayCommand<File> _removeCommand;

	    /// <inheritdoc cref="FilesList"/>
        public ObservableCollection<File> FilesList { get; set; }

	    /// <summary>
        /// Создает объект модели представления списка файлов
        /// </summary>
        public FilesListVM(IFilesWindowService filesWindowService)
        {
            _model = new FilesListModel();
            _filesWindowService = filesWindowService;

            FilesList = _model.FilesList;
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
						       _model.FilesList.Add(new File(_filesWindowService.FileName));
                               FilesList = _model.FilesList;
                               RaisePropertyChanged(nameof(FilesList));
					       }
				       }));
			}
		}

        /// <summary>
        /// Устанавливает и возвращает команду удаления имени файла
        /// </summary>
        public RelayCommand<File> RemoveCommand
        {
	        get
	        {
		        return _removeCommand ??
		               (_removeCommand = new RelayCommand<File>(
			               (obj) =>
			               {
				               _model.FilesList.Remove(obj);
				               FilesList = _model.FilesList;
			               }));
	        }

        }
    }
}
