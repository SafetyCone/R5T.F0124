using System;

using R5T.T0132;


namespace R5T.F0124.Extensions
{
    [FunctionalityMarker]
    public partial interface IStringOperator : IFunctionalityMarker
    {
        public ILineSeparator ToLineSeparator(string value)
        {
            var output = new LineSeparator(value);
            return output;
        }
    }
}
