using System;
using System.ComponentModel;

namespace WPFControls.Model
{
	/// <summary>
	/// Информация о файле
	/// </summary>
	public class File : Notifier, IDataErrorInfo
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
			NotifyPropertyChanged(nameof(Name));
		}

		/// <inheritdoc/>
		public string this[string columnName]
		{
			get
			{
				string error = String.Empty;
				switch (columnName)
				{
					case nameof(Name):
						if (Name.Substring(Name.Length - 4) != ".dll" &&
						    Name.Substring(Name.Length - 4) != ".exe")
						{
							return "Файл должен быть расширения .exe или .dll";
						}
						break;
				}
				return error;
			}
		}

		/// <inheritdoc/>
		public string Error => throw new NotImplementedException();
	}
}