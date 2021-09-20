using System.Collections.Generic;

namespace Folder.Hierarchy.Inspector
    {
    public interface IItem
        {
        string Name { get; }
        bool IsDirectory { get; }
        IEnumerable<IItem> Children { get; }
        long FolderCount { get; }
        long FileCount { get; }
        }
    }
