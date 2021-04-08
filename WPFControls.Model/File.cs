namespace WPFControls.Model
{
	/// <summary>
	/// Информация о файле
	/// </summary>
	public class File 
	{
		/// <summary>
		/// Имя файла
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Создает экземпляр класса по заданному имени
		/// </summary>
		/// <param name="name">Имя файла</param>
		public File(string name)
		{
			Name = name;
		}
	}
}