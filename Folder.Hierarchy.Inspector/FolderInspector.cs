using System.IO;

namespace Folder.Hierarchy.Inspector
    {
    public class FolderInspector
        {
        public string FolderPath { get; }

        public FolderInspector(string path)
            {
            FolderPath = path;
            }

        public FolderHierarchy CreateSnapshot()
            {
            var hierarchy = new FolderHierarchy(Path.GetFileName(FolderPath));

            Enumerate(hierarchy, FolderPath);

            return hierarchy;
            }

        private FolderHierarchy Enumerate(FolderHierarchy hierarchy, string folderPath)
            {
            DirectoryInfo di = new DirectoryInfo(folderPath);

            foreach (var item in di.EnumerateFileSystemInfos())
                {
                bool isDirectory = 0 != (item.Attributes & FileAttributes.Directory);

                if (isDirectory)
                    {
                    var child = new FolderHierarchy(Path.GetFileName(item.Name));
                    hierarchy.Add(Enumerate(child, item.FullName));
                    }
                else
                    hierarchy.Add(new FileEntry(Path.GetFileName(item.Name)));
                }

            return hierarchy;
            }
        }
    }
