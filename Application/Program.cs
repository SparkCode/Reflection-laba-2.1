using System;
using System.Collections.Generic;
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
        private static List<string> FileNames = new List<string>();

        private static void DirSearch(string sDir)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        FileNames.Add(f);
                    }
                    DirSearch(d);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }


        static void Main(string[] args)
        {

            var solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            DirSearch(solutionPath);
            var b = FileNames
                .Where(s => s.EndsWith(".dll"))
                .SelectMany(x => Assembly.LoadFrom(x).GetTypes())
                .Where(x => x.IsClass)
                .Where(x => x.GetInterfaces().Count(y => y.IsAssignableFrom(typeof (IPlugin))) > 1)
                .ToList();
        }
    }
}
