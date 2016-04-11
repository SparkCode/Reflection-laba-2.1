using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Framework;

namespace Application
{
    public class ReflectionWorker
    {
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

        public dynamic GetObject(Type type) => Activator.CreateInstance(type);
    }
}