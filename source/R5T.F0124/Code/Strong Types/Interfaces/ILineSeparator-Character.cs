using System;

using R5T.T0178;
using R5T.T0179;


namespace R5T.F0124.N000
{
    /// <summary>
    /// Represents a character-typed line separator.
    /// </summary>
    [StrongTypeMarker]
    public interface ILineSeparator : IStrongTypeMarker,
        ITyped<char>
    {
    }
}
