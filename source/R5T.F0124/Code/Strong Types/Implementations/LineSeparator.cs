using System;

using R5T.T0178;
using R5T.T0179;


namespace R5T.F0124
{
    /// <inheritdoc cref="ILineSeparator"/>
    [StrongTypeImplementationMarker]
    public class LineSeparator : TypedBase<string>, IStrongTypeMarker,
        ILineSeparator
    {
        public LineSeparator(string value)
            : base(value)
        {
        }
    }
}
