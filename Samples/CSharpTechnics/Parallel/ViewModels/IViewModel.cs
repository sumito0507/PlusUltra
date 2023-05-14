using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Parallel.ViewModels
{
    internal interface IViewModel
    {
        List<T> Execute<T>(T[] array, int parallelMax = 2);
    }
}
