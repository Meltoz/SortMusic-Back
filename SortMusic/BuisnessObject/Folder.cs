using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessObject
{
    public class Folder : Content
    {
        public string FolderPath { get; set; }

       
        public string FolderName { get; set; }

        public List<Content> Contents { get; set; }
    }
}
