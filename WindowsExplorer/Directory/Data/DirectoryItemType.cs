using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsExplorer
{
    /// <summary>
    /// Type of the Directory item
    /// </summary>
    public enum DirectoryItemType
    {
        /// <summary>
        /// Logical ldrive
        /// </summary>
        DRIVE,
        /// <summary>
        /// Folder item
        /// </summary>
        FOLDER,
        /// <summary>
        /// File item
        /// </summary>
        FILE
    }
}
