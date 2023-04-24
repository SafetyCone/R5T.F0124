using System;
using System.Collections.Generic;

using R5T.T0132;


namespace R5T.F0124
{
    [FunctionalityMarker]
    public partial interface ITextOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Joins lines using the specified line separator into a single string of text.
        /// </summary>
        public string Join_Lines(
            IEnumerable<string> lines,
            ILineSeparator lineSeparator)
        {
            var output = StringOperator.Instance.Join(
                lineSeparator.Value,
                lines);

            return output;
        }
    }
}
