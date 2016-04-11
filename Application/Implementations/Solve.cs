using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Application.Interfaces;
using Framework;

namespace Application.Implementations
{
    public class Solve
    {
        private static string GetSolutionPath()
            => Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));

        public List<object> GetSolve<TInterface>(IAssemblyWorker reflectionWorker, ITypeWorker typeWorker, ISearcher seacher) 
        {
            var solutionPath = GetSolutionPath();
            var dllPaths = seacher.GetFilePathsByRoot(solutionPath).FilesWithExtension(".dll");
            var types = reflectionWorker.GetTypesFromDlls(dllPaths, typeWorker.IsClassWithInterface<TInterface>);
            var objects = types.Select(typeWorker.GetObject);
            return objects.ToList();
        }
    }
}