using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSCources.Models
{
    public enum FileDirectory { Avatar = 1, TextImage = 2 }

    /// <summary>
    /// Предназначение: информация о сохранненых файлах и картинках
    /// </summary>
    public class File
    {
        public int Id { get; set; }

        public string Extension { get; set; }

        public string Description { get; set; }

        public FileDirectory Directory { get; set; }

        public string Name
        {
            get
            {
                return $"{Id}.{Extension}";
            }
        } 

        public string FileVirtualPath
        {
            get
            {
                return $"Images/{Directory}s/{Name}";
            }
        }


    }
}