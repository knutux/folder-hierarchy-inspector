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
  Q - quit");
                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.Q || key.Key == ConsoleKey.Escape)
                    break;

                }

            Console.Write("");
            }

        private void PrintHierarchyPreview(FolderHierarchy hierarchy)
            {
            foreach (var child in hierarchy.Children)
                {
                var type = child.IsDirectory ? "+" : " ";
                var size = child.IsDirectory ? $"({child.DescendantCount} children)" : "";
                Console.WriteLine($" {type} {child.Name} {size}");
                }

            Console.WriteLine($"Total items: {hierarchy.DescendantCount}");
            }
        }
    }
