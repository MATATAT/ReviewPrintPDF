using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;

namespace ReviewPrintPDF.Interface.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
        	SelectedIndex = -1;

        	Close = new RelayCommand(Application.Current.MainWindow.Close);
			OpenFiles = new RelayCommand(RetrieveFiles);
			Print = new RelayCommand(() =>
			                         	{
			                         		var files = new string[Filenames.Count];
											Filenames.CopyTo(files, 0);
			                         		new PDFCreator(files);
			                         	});
			ClearFiles = new RelayCommand(() => Filenames.Clear());
			MoveUp = new RelayCommand(() => SwapValues(SelectedIndex, SelectedIndex - 1));
			MoveDown = new RelayCommand(() => SwapValues(SelectedIndex, SelectedIndex + 1));
			Delete = new RelayCommand(() => Filenames.Remove(Filenames[SelectedIndex]));
        }

		private void SwapValues(int from, int to)
		{
			// Make sure the position is valid
			if (to > Filenames.Count - 1 || to < 0)
				return;

			var temp = Filenames[from];
			Filenames[from] = Filenames[to];
			Filenames[to] = temp;

			// Might want to move this
			SelectedIndex = to;
		}

		private void RetrieveFiles()
		{
			_files.ShowDialog();
			foreach (string t in _files.FileNames)
			{
				Filenames.Add(t);
			}
		}

    	public RelayCommand Close { get; private set; }
		public RelayCommand OpenFiles { get; private set; }
		public RelayCommand Print { get; private set; }
		public RelayCommand ClearFiles { get; private set; }
		public RelayCommand MoveUp { get; private set; }
		public RelayCommand MoveDown { get; private set; }
		public RelayCommand Delete { get; private set; }

		private readonly OpenFileDialog _files = new OpenFileDialog() { Multiselect = true };

		private ObservableCollection<string> _filenames = new ObservableCollection<string>();
		public ObservableCollection<string> Filenames
		{
			get { return _filenames; }
			set { _filenames = value; RaisePropertyChanged("Filenames"); }
		}

    	private int _selectedIndex;
    	public int SelectedIndex
    	{
			get { return _selectedIndex; }
			set { _selectedIndex = value; RaisePropertyChanged("SelectedIndex"); }
    	}
    }
}