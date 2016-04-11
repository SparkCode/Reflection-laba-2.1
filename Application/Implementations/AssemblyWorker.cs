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

        public IEnumerable<Type> GetReflectionOnlyTypes(string assemblyPath, Func<Type, bool> conditionType)
        {
            var assembly = Assembly.ReflectionOnlyLoadFrom(assemblyPath);
            return assembly.GetExportedTypes().Where(conditionType);
        }
        
        public Type GetType(string path, string fullName)
        {
            var assembly = Assembly.LoadFrom(path);
            return  assembly.GetType(fullName);
        }

        public IEnumerable<Type> GetTypesFromDll(string path)
        {
            var reflectionOnlyTypes = GetReflectionOnlyTypes(path, TypeWorker.IsClassWithInterface<IPlugin>);
            var types = reflectionOnlyTypes.Select(x => GetType(path, x.FullName));
            return types;
        }

        public IEnumerable<Type> GetTypesFromDlls(IEnumerable<string> dllPaths)
            => dllPaths
               .Where(p => !AssemblyHasAlreadyLoaded(p))
               .SelectMany(GetTypesFromDll);
    }
}