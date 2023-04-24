using System;

using R5T.T0178;
using R5T.T0179;


namespace R5T.F0124
{
    /// <summary>
    /// Represents a stringly-typed URL.
    /// </summary>
    [StrongTypeMarker]
    public interface IUrl : IStrongTypeMarker,
        ITyped<string>
    {
    }
}
