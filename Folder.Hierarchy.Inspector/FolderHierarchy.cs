
using System;
using System.Collections.Generic;
using System.Linq;

namespace Folder.Hierarchy.Inspector
    {
    public class FolderHierarchy : IItem
        {
        private List<IItem> m_items = new List<IItem>();

        public string Name { get; }

        public bool IsDirectory => true;

        public IEnumerable<IItem> Children => m_items;

        public long FolderCount => m_items.Count(f => f.IsDirectory) + m_items.Sum(c => c.FolderCount);

        public long FileCount => m_items.Count(f => !f.IsDirectory) + m_items.Sum(c => c.FileCount);

        public FolderHierarchy(string name) => Name = name;

        internal void Add(IItem child)
            {
            m_items.Add(child);
            }
        }
    }
