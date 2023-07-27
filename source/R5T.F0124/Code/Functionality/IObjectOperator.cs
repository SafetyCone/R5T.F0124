using System;

using R5T.T0132;


namespace R5T.F0124
{
    [FunctionalityMarker]
    public partial interface IObjectOperator : IFunctionalityMarker
    {
        public bool Perform_EqualsAction<T>(
            T a,
            T b,
            Func<T, T, bool> valueEqualityAction)
            where T : class
        {
            var nullCheckDeterminesEquality = this.NullCheckDeterminesEquality(a, b, out var equalsByNullCheck);
            if(nullCheckDeterminesEquality)
            {
                return equalsByNullCheck;
            }

            // Else, test values.
            var output = valueEqualityAction(a, b);
            return output;
        }

        public bool NullCheckDeterminesEquality<T>(
            T a,
            T b,
            out bool equals)
            where T : class
        {
            return Instances.NullOperator.NullCheckDeterminesEquality(a, b, out equals);
        }

        public bool Are_SameReference(object a, object b)
        {
            var output = Object.ReferenceEquals(a, b);
            return output;
        }
    }
}
