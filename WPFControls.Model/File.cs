using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace WPFControls.Model
{
	/// <summary>
	/// Информация о файле
	/// </summary>
	public class File : IDataErrorInfo
	{
		//TODO: private set
		/// <summary>
		/// Имя файла
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Создает экземпляр класса по заданному имени
		/// </summary>
		/// <param name="name">Имя файла</param>
		public File(string name)
		{
			Name = name;
		}

		/// <inheritdoc/>
		public string this[string columnName] =>
			columnName == nameof(Name) 
				?CheckFileExtension()
				:string.Empty;

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
		public override string ToString() => Name;
	}
}