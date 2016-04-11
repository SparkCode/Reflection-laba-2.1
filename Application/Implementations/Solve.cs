using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Application.Interfaces;

namespace Application.Implementations
{
    public class Solve
    {
        private static string GetSolutionPath()
            => Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));

        public List<string> GetSolve(IAssemblyWorker reflectionWorker, ITypeWorker typeWorker, ISearcher seacher)
        {
            var solutionPath = GetSolutionPath();
            var dllPaths = seacher.GetFilePathsByRoot(solutionPath).FilePathsWithExtension(".dll");
            var types = reflectionWorker.GetTypesFromDlls(dllPaths);
            var objects = types.Select(typeWorker.GetObject);

            return objects.Select(x => x.ToString()).ToList();
        }
    }
}