using System.ComponentModel;

namespace WPFControls.Model
{ 
	/// <summary>
	/// Уведомитель об изменениях в свойствах
	/// </summary>
	public class Notifier : INotifyPropertyChanged
	{
		/// <inheritdoc/>
		public event PropertyChangedEventHandler
			PropertyChanged = delegate { };

		/// <summary>
		/// Уведомляет об изменении свойства
		/// </summary>
		/// <param name="propertyName">Название измененного свойства </param>
		protected void NotifyPropertyChanged(string propertyName)
		{
			PropertyChanged(this,
				new PropertyChangedEventArgs(
					propertyName));
		}
	}
	
}