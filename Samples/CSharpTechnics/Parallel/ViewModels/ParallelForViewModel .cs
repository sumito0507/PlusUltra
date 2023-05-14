using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Parallel.ViewModels
{
    internal class ParallelForViewModel : IViewModel
    {
        private static object lockTest = new object(); //ロック処理用オブジェクト

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="parallelMax">同時実行タスクの最大数</param>
        /// <returns></returns>
        public List<T> Execute<T>(T[] array, int parallelMax = 2)
        {
            var result = new List<T>();
            System.Threading.Tasks.Parallel.For(
                0,
                array.Length,
                //new ParallelOptions { MaxDegreeOfParallelism = parallelMax },
                i =>
                {
                    lock (lockTest)
                    {
                        result.Add(array[i]);
                }
                });
            return result;
        }
    }
}
