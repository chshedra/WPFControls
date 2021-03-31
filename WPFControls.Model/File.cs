using System;
using System.ComponentModel;

namespace WPFControls.Model
{
	//TODO: Это уже не просто File, а файл VM, поэтому есть смысл или создать отдельный fileVM ...
	//... или выкосить нотифаер и подключить уже тут MVVMLight, что тоже не очень хорошо, в общем - примите какое-то решение и давайте обсудим уже очно
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
						//TODO: Лучше в отдельный метод, в котором будут перечислены списком расширения и также формировать ...
						//... с помощью этого списка результирующее сообщение об ошибке
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

		//TODO: Писал уже в NoteApp - сомнительная практика кидать тут исключение.
		/// <inheritdoc/>
		public string Error => throw new NotImplementedException();

		/// <inheritdoc/>
		public override string ToString() => Name;
	}
}