using System;
using System.IO;

namespace IntWeb.Framework.Managers
{
    public class DirectoryManager
    {
        public Application Application { get; private set; }

        public DirectoryManager(Application application)
        {
            Application = application;
        }

        public string GetApplicationDirectory()
        {
            return Path.Combine(Environment.CurrentDirectory, Application.Name);
        }

        public void InitializeApplicationDirectory()
        {
            var applicationDirectory = GetApplicationDirectory();
            CreateDirectoryIfNotExists(applicationDirectory);
        }

        public bool IsDirectoryExists(string path)
        {
            var fullPath = Path.Combine(GetApplicationDirectory(), path);
            return Directory.Exists(fullPath);
        }

        public void CreateDirectory(string path)
        {
            var fullPath = Path.Combine(GetApplicationDirectory(), path);
            CreateDirectoryIfNotExists(fullPath);
        }

        private void CreateDirectoryIfNotExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
