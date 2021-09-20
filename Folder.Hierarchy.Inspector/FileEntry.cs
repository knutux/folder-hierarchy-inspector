using System;
using System.Collections.Generic;

namespace Folder.Hierarchy.Inspector
    {
    internal class FileEntry : IItem
        {

        public FileEntry(string name)
            {
            Name = name;
            }

        public string Name { get; }

        public bool IsDirectory => false;

        public IEnumerable<IItem> Children => Array.Empty<IItem>();

        public long FolderCount => 0;
        public long FileCount => 0;
        }
    }
