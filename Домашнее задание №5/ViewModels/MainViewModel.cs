using System;
using System.Collections.ObjectModel;
using System.IO;
using System.ComponentModel;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using Домашнее_задание__5.Class;

namespace Домашнее_задание__5.ViewModels
{
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ObservableCollection<IExplorer> _explorerItems = new ObservableCollection<IExplorer>();

        public ObservableCollection<IExplorer> ExplorerItems => _explorerItems;

        private string _currentDirectoryPath;

        private Bitmap? _selectedImageBitmap;

        public Bitmap? SelectedImageBitmap
        {
            get { return _selectedImageBitmap; }
            set
            {
                if (_selectedImageBitmap != value)
                {
                    _selectedImageBitmap = value;
                    OnPropertyChanged(nameof(SelectedImageBitmap));
                }
            }
        }

        private FileSystemWatcher _fileSystemWatcher;

        public MainViewModel()
        {
            _currentDirectoryPath = Directory.GetCurrentDirectory();
            InitializeFileSystemWatcher();
            LoadItemsAsync();
        }

        private void InitializeFileSystemWatcher()
        {
            _fileSystemWatcher = new FileSystemWatcher();
            _fileSystemWatcher.Path = _currentDirectoryPath; 
            _fileSystemWatcher.IncludeSubdirectories = true;
            _fileSystemWatcher.Created += FileSystemWatcher_Changed;
            _fileSystemWatcher.Deleted += FileSystemWatcher_Changed;
            _fileSystemWatcher.Renamed += FileSystemWatcher_Changed;
            _fileSystemWatcher.EnableRaisingEvents = true;
        }

        private async Task LoadItemsAsync()
        {   
            _fileSystemWatcher.Path = _currentDirectoryPath;
            ExplorerItems.Clear();

            string parentDirectory = Path.GetDirectoryName(_currentDirectoryPath);
            if (parentDirectory != null)
            {
                ExplorerItems.Add(new Directoryies(parentDirectory, ".."));
            }
            else
            {
                ExplorerItems.Add(new Directoryies("Drives", ".."));
            }

            await LoadDirectoriesAsync(_currentDirectoryPath);
            await LoadFilesAsync(_currentDirectoryPath);
        }

        private async Task LoadDirectoriesAsync(string path)
        {
            try
            {
                string[] directoryPaths = await Task.Run(() => Directory.GetDirectories(path));
                foreach (var directoryPath in directoryPaths)
                {
                    string name = Path.GetFileName(directoryPath);
                    ExplorerItems.Add(new Directoryies(directoryPath, name));
                }
            }
            catch (Exception ex) {}
        }

        private async Task LoadFilesAsync(string path)
        {
            try
            {
                string[] filePaths = await Task.Run(() => Directory.GetFiles(path));
                foreach (var filePath in filePaths)
                {
                    string name = Path.GetFileName(filePath);
                    if (FileImage.IsImage(name))
                    {
                        ExplorerItems.Add(new FileImage(filePath, name));
                    }
                    else
                    {
                        ExplorerItems.Add(new Class.File(filePath, name));
                    }
                }
            }
            catch (Exception ex) {}
        }

        public void LoadDrives()
        {
            ExplorerItems.Clear();

            foreach (var driveInfo in DriveInfo.GetDrives())
            {
                ExplorerItems.Add(new Drive(driveInfo.RootDirectory.FullName, driveInfo.Name));
            }
        }

        public void HandleItemClick(IExplorer item)
        {
            _currentDirectoryPath = item.Path;
            if (item.Path == "Drives")
            {
                LoadDrives();
            }
            else
            {
                LoadItemsAsync();
            }
        }

        public void HandleImageClick(IExplorer item)
        {
            if (item is FileImage)
            {
                SelectedImageBitmap = new Bitmap(item.Path);
            }
        }

        private async void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            await LoadItemsAsync();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
