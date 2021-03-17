using System;
using System.Windows.Input;

namespace WPFControls.ViewModel
{
	/// <inheritdoc/>
	public class RelayCommand : ICommand
	{
		/// <summary>
		/// Выполняет команду
		/// </summary>
		private Action<object> _execute;

		/// <summary>
		/// Проверяет возможность выполнения команды
		/// </summary>
		private Func<object, bool> _canExecute;

		/// <inheritdoc/>
		public event EventHandler CanExecuteChanged
		{
			add => CommandManager.RequerySuggested += value;
			remove => CommandManager.RequerySuggested -= value;
		}
		
		/// <summary>
		/// Создает экземпляр команды
		/// </summary>
		/// <param name="execute"></param>
		/// <param name="canExecute"></param>
		public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
		{
			_execute = execute;
			_canExecute = canExecute;
		}

		/// <inheritdoc/>
		public bool CanExecute(object parameter)
		{
			return _canExecute == null || _canExecute(parameter);
		}

		/// <inheritdoc/>
		public void Execute(object parameter)
		{
			_execute(parameter);
		}
	}
	
}