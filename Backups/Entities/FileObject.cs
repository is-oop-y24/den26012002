﻿using System.IO;
using Backups.Tools;

namespace Backups.Entities
{
    public class FileObject : IJobObject
    {
        public FileObject(string directoryPath, string fileName, string fileExtension)
        {
            if (!IsValidFilePathName(directoryPath))
            {
                throw new BackupsException($"Error: incorrect path to file (\"{fileName}\" was entered)");
            }

            DirectoryPath = directoryPath;
            Name = fileName;
            Extension = fileExtension;
        }

        public string DirectoryPath { get; }
        public string Name { get; }
        public string Extension { get; }
        public byte[] GetRepresentation()
        {
            FileStream ifstream = File.OpenRead(DirectoryPath + "\\" + Name + Extension);
            byte[] byteRepresentation = new byte[ifstream.Length];
            ifstream.Read(byteRepresentation);
            ifstream.Close();
            return byteRepresentation;
        }

        private bool IsValidFilePathName(string path)
        {
            return path.IndexOfAny(Path.GetInvalidPathChars()) == -1;
        }
    }
}
