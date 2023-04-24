using System;

using R5T.T0178;
using R5T.T0179;


namespace R5T.F0124.N000
{
    /// <inheritdoc cref="ILineSeparator"/>
    [StrongTypeImplementationMarker]
    public class LineSeparator : TypedBase<char>, IStrongTypeMarker,
        ILineSeparator
    {
        public LineSeparator(char value)
            : base(value)
        {
        }
    }
}
