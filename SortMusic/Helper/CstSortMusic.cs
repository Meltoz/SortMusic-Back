using System;
using System.Collections.Generic;
using System.Text;

namespace Helper
{
    public class CstSortMusic
    {
        public readonly string Folder;
        public List<string> Styles;
        public readonly string PathConfigurationFile;

        private static CstSortMusic _instance;

        private CstSortMusic()
        {
            Folder = @"D:\Test\";
            Styles = new List<string>();
            PathConfigurationFile = @"D:\Programmation\C#\Repo\SortMusic-Back\SortMusic\SortMusic\App_Data\style.txt";
        }

        public static CstSortMusic Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CstSortMusic();
                }
                return _instance;
            }
        }
    }
}
