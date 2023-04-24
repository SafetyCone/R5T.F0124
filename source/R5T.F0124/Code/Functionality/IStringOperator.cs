using System;
using System.Collections.Generic;

using R5T.T0132;


namespace R5T.F0124
{
    [FunctionalityMarker]
    public partial interface IStringOperator : IFunctionalityMarker
    {
        public string Join(string separator, IEnumerable<string> strings)
        {
            var output = String.Join(separator, strings);
            return output;
        }
    }
}
