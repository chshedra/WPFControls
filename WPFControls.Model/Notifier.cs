using System.ComponentModel;

namespace WPFControls.Model
{ 
	/// <summary>
	/// Уведомитель об изменениях в свойствах
	/// </summary>
	public class Notifier : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler
			PropertyChanged = delegate { };

		protected void NotifyPropertyChanged(string propertyName)
		{
			PropertyChanged(this,
				new PropertyChangedEventArgs(
					propertyName));
		}
	}
	
}