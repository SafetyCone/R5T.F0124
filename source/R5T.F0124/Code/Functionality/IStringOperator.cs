using System;
using System.Collections.Generic;

using R5T.T0132;


namespace R5T.F0124
{
    [FunctionalityMarker]
    public partial interface IStringOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Trims new-lines (both Windows and Non-Windows) from the start and end of a string.
        /// Does not trim tabs.
        /// </summary>
        /// <remarks>
        /// Useful for creating string-literal code fragments on their own lines (meaning the new-lines between the start-line and end-line must be removed.
        /// </remarks>
        public string Trim_NewLines(string value)
        {
            var output = value.Trim(
                Instances.Characters.NewLine,
                Instances.Characters.CarriageReturn);

            return output;
        }

        public string Join(string separator, IEnumerable<string> strings)
        {
            var output = String.Join(separator, strings);
            return output;
        }
    }
}
