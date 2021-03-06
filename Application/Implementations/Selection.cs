﻿using System.Collections.Generic;
using System.Linq;

namespace Application.Implementations
{
    public static class Selection
    {
        public static IEnumerable<string> FilesWithExtension(this IEnumerable<string> paths, string extention)
            => paths.Where(s => s.EndsWith(extention));
    }
}