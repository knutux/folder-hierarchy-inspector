using Folder.Hierarchy.Inspector;
using System;

namespace Folder.Inspector.Tool
    {
    internal class InspectorTool
        {
        public InspectorTool(string path)
            {
            Inspector = new FolderInspector(path);
            }

        public FolderInspector Inspector { get; }

        internal void Run()
            {
            FolderHierarchy hierarchy = Inspector.CreateSnapshot();
            PrintHierarchyPreview(hierarchy);

            while (true)
                {
                Console.Write(@"Select an action:
  E - re-enumerate
  Q - quit
");
                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.Q || key.Key == ConsoleKey.Escape)
                    break;

                if (key.Key == ConsoleKey.E)
                    {
                    Console.Write($"Enumerating the {Inspector.FolderPath}");
                    FolderHierarchy newHierarchy = Inspector.CreateSnapshot();
                    PrintHierarchyPreview(newHierarchy, hierarchy);
                    hierarchy = newHierarchy;
                    continue;
                    }
                }

            Console.Write("");
            }

        private void PrintHierarchyPreview(FolderHierarchy hierarchy, FolderHierarchy? benchmark = null)
            {
            foreach (var child in hierarchy.Children)
                {
                var type = child.IsDirectory ? "+" : " ";
                var size = child.IsDirectory ? $"({child.FolderCount} folders, {child.FileCount} files)" : "";
                Console.WriteLine($" {type} {child.Name} {size}");
                }

            var oldFolderCount = benchmark?.FolderCount;
            var oldFileCount = benchmark?.FileCount;
            var folderCount = hierarchy.FolderCount;
            var fileCount = hierarchy.FileCount;
            var diffFolders = !oldFolderCount.HasValue ? "" : (oldFolderCount == folderCount ? " (no changes)" : (oldFolderCount > folderCount ? $"-{oldFolderCount - folderCount}" : $"+{folderCount - oldFolderCount}"));
            var diffFiles = !oldFileCount.HasValue ? "" : (oldFileCount == fileCount ? " (no changes)" : (oldFileCount > fileCount ? $" (-{oldFileCount - fileCount})" : $" (+{fileCount - oldFileCount})"));
            Console.WriteLine($"Total: {folderCount} folders{diffFolders}, {fileCount} files{diffFiles}");
            }
        }
    }
