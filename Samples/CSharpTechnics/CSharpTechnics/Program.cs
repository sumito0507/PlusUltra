﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpTechnics
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
#if false
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
#else
            int[] src = { 0, 1, 2, 3, 4, 5 };

            var query = src.Select(x => x % 3);
            Console.WriteLine("[{0}]", string.Join(", ", query));

            Console.ReadKey();
#endif
        }
    }
}
