using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application.Implementations;
using Framework;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var reflectionWorker = new AssemblyWorker();
            var typeWorker = new TypeWorker();
            var seacher = new Searcher();
            var solve = new Solve();

            var answer = solve.GetSolve(reflectionWorker, typeWorker, seacher);
            answer.ForEach(Console.WriteLine);
        }
    }
}
