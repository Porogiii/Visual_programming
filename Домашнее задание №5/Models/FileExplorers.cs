using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Linq;


namespace Домашнее_задание__5.Class
{
    public interface IExplorer
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string IconPath { get; set; }
        public Bitmap? IconBitmap
        {
            get => new(AssetLoader.Open(new Uri(IconPath)));
        }
    }


    public class Directoryies : IExplorer
    {
        public Directoryies()
        {
            Name = string.Empty;
            IconPath = "avares://Домашнее задание №5/Assets/folder.png";
            Path = string.Empty;
        }

        public Directoryies(string path, string name)
        {
            Name = name;
            Path = path;
            IconPath = "avares://Домашнее задание №5/Assets/folder.png";
        }

        public string Name { get; set; }
        public string Path { get; set; }

        public string IconPath { get; set; }

        public Bitmap? IconBitmap
        {
            get => new(AssetLoader.Open(new Uri(IconPath)));
        }
    }
    public class File : IExplorer
    {
        public File()
        {
            Name = string.Empty;
            IconPath = "avares://Домашнее задание №5/Assets/file.png";
            Path = string.Empty;
        }

        public File(string path, string name)
        {
            Name = name;
            Path = path;
            IconPath = "avares://Домашнее задание №5/Assets/file.png";
        }

        public string Name { get; set; }
        public string Path { get; set; }

        public string IconPath { get; set; }

        public Bitmap? IconBitmap
        {
            get => new(AssetLoader.Open(new Uri(IconPath)));
        }
    }

    public class Drive : Directoryies
    {
        public Drive()
        {
            Name = string.Empty;
            Path = string.Empty;
            IconPath = "avares://Домашнее задание №5/Assets/hard.png";
        }

        public Drive(string path, string name)
        {
            Name = name;
            Path = path;
            IconPath = "avares://Домашнее задание №5/Assets/hard.png";
        }

    }

    public class FileImage: File
    {
        public static bool IsImage(string name)
        {
            string extension = System.IO.Path.GetExtension(name)?.ToLowerInvariant();

            string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };

            return imageExtensions.Contains(extension);
        }

        public FileImage(string filePath, string name) : base(filePath, name) { }
       
    }
}

