using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollApp.Extensions
{
    public class ImageExtensions : IRandomFileName
    {
        public string GetRandomName(string fileFormat)
        {
            return $"{Path.GetRandomFileName()}_{DateTime.Now.ToString("dd_MM_yyyy_hh_mm")}.{fileFormat}";
        }
    }
}
