using System;

namespace Application.Interfaces
{
    public interface ITypeWorker
    {
        object GetObject(Type type);
        bool IsClassWithInterface<T>(Type type);
    }
}