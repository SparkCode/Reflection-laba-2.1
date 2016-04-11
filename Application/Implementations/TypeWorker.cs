using System;
using System.Linq;
using Application.Interfaces;

namespace Application.Implementations
{
    public class TypeWorker : ITypeWorker
    {
        public static bool IsClassWithInterface<T>(Type type)
           => type.IsClass && type.GetInterfaces().Any(y => y.GUID == typeof(T).GUID);

        public object GetObject(Type type) 
            => Activator.CreateInstance(type);
    }
}