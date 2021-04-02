using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using GalaSoft.MvvmLight;
using File = WPFControls.Model.File;

namespace WPFControls.ViewModel.ViewModels
{
	/// <inheritdoc cref="IFileVM"/>
	public class FileVM : ViewModelBase, IFileVM, IDataErrorInfo
	{
		/// <inheritdoc/>
		public string Name { get; private set; }

		/// <summary>
		/// Создает объект модели представления по имени файла
		/// </summary>
		/// <param name="name"></param>
		public FileVM(string name)
		{
			Name = name;
		}

		/// <inheritdoc/>
		public string this[string columnName] =>
			columnName == nameof(Name)
				? CheckFileExtension()
				: string.Empty;

		/// <inheritdoc/>
		public string Error => string.Empty;

		/// <summary>
		/// Проверяет расширения файлов на корректность
		/// </summary>
		/// <returns>Сообщение об ошибке</returns>
		private string CheckFileExtension()
		{
			var extensions = new List<string>()
			{
				".exe",
				".dll"
			};

			foreach (var extension in extensions)
			{
				FileInfo tmpFile = new FileInfo(Name);
				if (tmpFile.Extension == extension)
				{
					return string.Empty;
				}
			}

			return CreateErrorMessage(extensions);
		}

		/// <summary>
		/// Создает сообщение о неверном расширении файла
		/// </summary>
		/// <param name="extensions"></param>
		/// <returns>Сообщение об ошибке</returns>
		private string CreateErrorMessage(List<string> extensions)
		{
			var errorMessage = "Файл должен иметь одно из следующих расширений: ";

			foreach (var extension in extensions)
			{
				errorMessage += extension + ", ";
			}

			return errorMessage;
		}

		/// <inheritdoc/>
		public File ConvertToFile()
		{
			return new File(this.Name);
		}

		/// <inheritdoc/>
		public override string ToString() => Name;
	}
}