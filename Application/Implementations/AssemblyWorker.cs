using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Application.Interfaces;
using Framework;

namespace Application.Implementations
{
    public class AssemblyWorker : IAssemblyWorker
    {
        public bool AssemblyHasAlreadyLoaded(string path)
        {
            var assemblyName = AssemblyName.GetAssemblyName(path).FullName;
            return AppDomain.CurrentDomain.GetAssemblies().Any(x => x.FullName == assemblyName);
        }

        public IEnumerable<Type> GetTypes(string path, Func<Type, bool> conditionType)
        {
            var assembly = Assembly.LoadFrom(path);
            return assembly.GetTypes().Where(conditionType);
        }

        public IEnumerable<Type> GetTypesFromDlls(IEnumerable<string> dllPaths, Func<Type, bool> conditionType)
            => dllPaths
                .Where(p => !AssemblyHasAlreadyLoaded(p))
               .SelectMany(path => GetTypes(path, conditionType));
    }
}