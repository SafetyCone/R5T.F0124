using System;

using R5T.T0132;


namespace R5T.F0124.Extensions
{
    [FunctionalityMarker]
    public partial interface ICharacterOperator : IFunctionalityMarker
    {
        public N000.ILineSeparator ToLineSeparator(char value)
        {
            var output = new N000.LineSeparator(value);
            return output;
        }
    }
}
