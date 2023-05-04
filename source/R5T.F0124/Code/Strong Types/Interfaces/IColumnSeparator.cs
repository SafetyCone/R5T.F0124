using System;

using R5T.T0178;
using R5T.T0179;


namespace R5T.F0124
{
    /// <summary>
    /// Represents a string-typed line separator.
    /// </summary>
    [StrongTypeMarker]
    public interface IColumnSeparator : IStrongTypeMarker,
        ITyped<string>
    {
    }
}
