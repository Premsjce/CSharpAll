using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsExplorer
{
    public class DiretoryItem
    {
        
        public DirectoryItemType Type { get; set; }

        public string FullPath { get; set; }

        public string Name
        {
            get
            {
                if (this.Type == DirectoryItemType.DRIVE)
                    return this.FullPath;
                else
                    return DirectoryStructure.GetFileFolderName(this.FullPath);
            }
        }
    }
}
