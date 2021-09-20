using System;
using System.IO;
using System.Linq;

namespace Folder.Inspector.Tool
    {
    class Program
        {
        static void Main(string[] args)
            {
            Console.WriteLine("Folder.Inspector.Tool v0.1");

            if (!args.Any())
                {
                Console.WriteLine(@"Usage:
  Folder.Inspector.Tool.exe <folder path>");
                return;
                }

            var path = args[0];
            if (!Directory.Exists(path))
                {
                Console.WriteLine(@$"Directory '{path}' does not exist");
                return;
                }

            var tool = new InspectorTool(path);
            tool.Run();
            }
        }
    }
