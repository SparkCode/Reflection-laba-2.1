using System;
using System.Collections.Generic;
using System.IO;

namespace Application
{
    public class Searcher
    {
        private List<string> _fileNames;

        private void DirSearch(string sDir)
        {
            try
            {
                foreach (var d in Directory.GetDirectories(sDir))
                {
                    foreach (var f in Directory.GetFiles(d))
                    {
                        _fileNames.Add(f);
                    }
                    DirSearch(d);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public IEnumerable<string> GetFilePathsByRoot(string root)
        {
            _fileNames = new List<string>();
            DirSearch(root);
            return _fileNames;
        }
    }
}