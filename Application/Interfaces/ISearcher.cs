using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface ISearcher
    {
        IEnumerable<string> GetFilePathsByRoot(string root);
    }
}