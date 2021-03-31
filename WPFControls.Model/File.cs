using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WPFControls.Model
{
	//TODO:+ Это уже не просто File, а файл VM, поэтому есть смысл или создать отдельный fileVM ...
	//... или выкосить нотифаер и подключить уже тут MVVMLight, что тоже не очень хорошо, в общем - примите какое-то решение и давайте обсудим уже очно
	/// <summary>
	/// Информация о файле
	/// </summary>
	public class File : IDataErrorInfo
	{
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
			//TODO: +Лучше в отдельный метод, в котором будут перечислены списком расширения и также формировать ...
			//... с помощью этого списка результирующее сообщение об ошибке
			columnName == nameof(Name) 
				?CheckFileExtension()
				:string.Empty;

		//TODO: +Писал уже в NoteApp - сомнительная практика кидать тут исключение.
		/// <inheritdoc/>
		public string Error => string.Empty;

		/// <summary>
		/// Проверяет расширения файлов на корректность
		/// </summary>
		/// <returns>Сообщение об ошибке</returns>
		private string CheckFileExtension()
		{
			var isCorrectExtension = false;

			var extensions = new List<string>()
			{
				".exe",
				".dll"
			};

			foreach (var extension in extensions)
			{
				if (Name.Substring(Name.Length - 4) == extension)
				{
					isCorrectExtension = true;
				}
			}

			return isCorrectExtension
				? string.Empty
				: CreateErrorMessage(extensions);
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