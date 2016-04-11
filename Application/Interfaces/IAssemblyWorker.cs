using System;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IAssemblyWorker
    {
        bool AssemblyHasAlreadyLoaded(string path);
        Type GetType(string path, string fullName);
        IEnumerable<Type> GetReflectionOnlyTypes(string assemblyPath, Func<Type, bool> conditionType);
        IEnumerable<Type> GetTypesFromDll(string path);
        IEnumerable<Type> GetTypesFromDlls(IEnumerable<string> dllPaths);
    }
}