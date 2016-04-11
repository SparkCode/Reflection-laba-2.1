using System;
using System.Linq;
using Application.Interfaces;

namespace Application.Implementations
{
    public class TypeWorker : ITypeWorker
    {
        public bool IsClassWithInterface<T>(Type type)
           => type.IsClass && type.GetInterfaces().Any(y => typeof(T).IsAssignableFrom(y));

        public object GetObject(Type type) 
            => Activator.CreateInstance(type);
    }
}