using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollApp.Extensions
{
    public interface IRandomFileName
    {
        string GetRandomName(string fileName);
    }
}
