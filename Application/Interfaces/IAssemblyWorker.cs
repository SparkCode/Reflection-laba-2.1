using System;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IAssemblyWorker
    {
        IEnumerable<Type> GetTypes(string path, Func<Type, bool> conditionType);
        IEnumerable<Type> GetTypesFromDlls(IEnumerable<string> dllPaths, Func<Type, bool> conditionType);
        bool AssemblyHasAlreadyLoaded(string path);
    }
}