using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Framework;

namespace Application
{
    class Program
    {
        private static bool IsClassWithInterface<T>(Type type) 
            => type.IsClass && type.GetInterfaces().Any(y => y.GUID == typeof(T).GUID);

        private static string GetSolutionPath() 
            => Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));

        private static IEnumerable<string> GetDllPathsFromSolution()
        {
            var solutionPath = GetSolutionPath();
            return new Searcher().GetFilePathsByRoot(solutionPath).Where(s => s.EndsWith(".dll"));
        } 

        static void Main(string[] args)
        {
            var reflectionWorker = new ReflectionWorker();
            var dllPaths = GetDllPathsFromSolution();
            foreach (var dll in dllPaths)
            {
                try
                {
                    var reflectionOnlyTypes = reflectionWorker.GetReflectionOnlyTypes(dll, IsClassWithInterface<IPlugin>);
                    var types = reflectionOnlyTypes.Select(x => reflectionWorker.GetType(dll, x.FullName));
                    var objects = types.Select(reflectionWorker.GetObject);
                    objects.ToList().ForEach(x => Console.WriteLine(x.ToString()));
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
        }
    }
}
