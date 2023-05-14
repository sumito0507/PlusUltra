using Parallel.Models;
using Parallel.ViewModels;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel
{
    internal class Program
    {
        const int ITEM_NUMBER = 1000;

        static void Main(string[] args)
        {

            Stopwatch stopWatch = new Stopwatch();

            //var array = Enumerable.Range(0, ITEM_NUMBER).ToArray();
            //DataArrayModel array = new DataArrayModel();
            List<SampleData> array = new List<SampleData>();
            for (int i = 0; i < ITEM_NUMBER; i++) 
            {
                var data = new SampleData()
                {
                    FirstName = i.ToString(),
                    LastName = i.ToString(),
                    Age = i
                };
                array.Add(data);
            }

            Console.WriteLine($"{GC.GetTotalMemory(false):#,0}"); // Low memory
            {
                Console.WriteLine("LinqFor 開始");
                stopWatch.Start();
                var list = new LinqForeachViewModel().Execute(array.ToArray());
                stopWatch.Stop();
                if (list.Count != ITEM_NUMBER) Console.WriteLine($"Error!! {list.Count}");
                Console.WriteLine($"LinqFor 終了 （{stopWatch.Elapsed.TotalSeconds}秒）");
            }
            //GC.Collect();
            Console.WriteLine($"{GC.GetTotalMemory(false):#,0}"); // Low memory
            {
                Console.WriteLine("for 開始");
                stopWatch.Start();
                var list = new ForViewModel().Execute(array.ToArray());
                if (list.Count != ITEM_NUMBER) Console.WriteLine($"Error!! {list.Count}");
                stopWatch.Stop();
                Console.WriteLine($"for 終了 （{stopWatch.Elapsed.TotalSeconds}秒）");
            }
            //GC.Collect();
            Console.WriteLine($"{GC.GetTotalMemory(false):#,0}"); // Low memory
            {
                Console.WriteLine("foreach 開始");
                stopWatch.Start();
                var list = new ForeachViewModel().Execute(array.ToArray());
                stopWatch.Stop();
                if (list.Count != ITEM_NUMBER) Console.WriteLine($"Error!! {list.Count}");
                Console.WriteLine($"foreach 終了 （{stopWatch.Elapsed.TotalSeconds}秒）");
            }
            //GC.Collect();
            Console.WriteLine($"{GC.GetTotalMemory(false):#,0}"); // Low memory
            {
                Console.WriteLine("parallel.for 開始");
                stopWatch.Start();
                var list = new ParallelForViewModel().Execute(array.ToArray());
                stopWatch.Stop();
                if (list.Count != ITEM_NUMBER) Console.WriteLine($"Error!! {list.Count}");
                Console.WriteLine($"parallel.for 終了 （{stopWatch.Elapsed.TotalSeconds}秒）");
            }
            //GC.Collect();
            Console.WriteLine($"{GC.GetTotalMemory(false):#,0}"); // Low memory
            {
                Console.WriteLine("parallel.forEach 開始");
                stopWatch.Start();
                var list = new ParallelForEachViewModel().Execute(array.ToArray());
                stopWatch.Stop();
                if (list.Count != ITEM_NUMBER) Console.WriteLine($"Error!! {list.Count}");
                Console.WriteLine($"parallel.forEach 終了 （{stopWatch.Elapsed.TotalSeconds}秒）");
            }
            //GC.Collect();
            Console.WriteLine($"{GC.GetTotalMemory(false):#,0}"); // Low memory

            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.Write((i == 0 ? "" : ",") + list[i]);
            //}
            Console.ReadKey();
        }
    }
}
