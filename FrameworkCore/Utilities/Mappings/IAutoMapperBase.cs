using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkCore.Utilities.Mappings
{
    public interface IAutoMapperBase
    {
        List<TDest> MapToSameList<TSource, TDest>(List<TSource> list)
            where TSource : new();
        TDest MapToSameType<TSource, TDest>(TSource obj)
            where TSource : new();

    }
}
