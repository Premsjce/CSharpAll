using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsExplorer
{
    public static class DirectoryStructure
    {
        /// <summary>
        /// Gets all the logical drives.
        /// </summary>
        /// <returns></returns>
        public static List<DiretoryItem> GetLogicalDrives()
        {
            string[] dir = Directory.GetLogicalDrives();

            List<DiretoryItem> dirItemList = new List<DiretoryItem>();
            foreach (var item in dir)
            {
                var temp = new DiretoryItem()
                {
                    FullPath = item,
                    Type = DirectoryItemType.DRIVE
                };

                dirItemList.Add(temp);
            }

            return dirItemList;

            //return Directory.GetLogicalDrives().Select(drive => new DiretoryItem() { FullPath = drive, Type = DirectoryItemType.DRIVE }).ToList();
        }

        /// <summary>
        /// Gets the directory Top Level contents.
        /// </summary>
        /// <param name="fullPath">The full path.</param>
        /// <returns></returns>
        public static List<DiretoryItem> GetDirectoryContents(string fullPath)
        {
            var directories = new List<DiretoryItem>();

            #region Get Directories

            //Try and get Directories from folder ignoring any issues
            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                    directories.AddRange(dirs.Select(folder => new DiretoryItem() { FullPath = folder, Type = DirectoryItemType.FOLDER }));
            }
            catch
            {

            }

            #endregion

            #region GetFiles
            //Try and get Files from folder ignoring any issues
            try
            {
                var files = Directory.GetFiles(fullPath);
                if (files.Length > 0)
                    directories.AddRange(files.Select(file => new DiretoryItem() { FullPath = file, Type = DirectoryItemType.FILE }));
            }
            catch
            {

            }
            #endregion

            return directories;
        }

        #region Helper
        //Find the file or folder Name from Full Path   
        public static string GetFileFolderName(string directorypath)
        {
            if (string.IsNullOrEmpty(directorypath))
                return string.Empty;

            var stringarray = directorypath.Split('\\');
            return stringarray[stringarray.Length - 1];

        }
        #endregion
    }
}
