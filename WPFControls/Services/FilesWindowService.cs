﻿using System.Collections.ObjectModel;
using System.IO;
using Microsoft.Win32;
using WPFControls.ViewModel.IServices;

namespace WPFControls.Services
{
	/// <inheritdoc/>
	public class FilesWindowService : IFilesWindowService
	{
		/// <inheritdoc/>
		public ObservableCollection<string> FileNames { get; set; } = 
			new ObservableCollection<string>();

		/// <inheritdoc/>
		public bool OpenFileDialog()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Multiselect = true,
				Filter = "All files (*.*)|*.*"
			};

			if (openFileDialog.ShowDialog() == true)
			{
				foreach (string file in openFileDialog.FileNames)
				{
					FileNames.Add(Path.GetFileName(file));
				}

				return true;
			}
			return false;
		}
	}
}