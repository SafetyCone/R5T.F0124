using System;

using R5T.T0178;
using R5T.T0179;


namespace R5T.F0124
{
    /// <inheritdoc cref="IColumnSeparator"/>
    [StrongTypeImplementationMarker]
    public class ColumnSeparator : TypedBase<string>, IStrongTypeMarker,
        IColumnSeparator
    {
        public ColumnSeparator(string value)
            : base(value)
        {
        }
    }
}
