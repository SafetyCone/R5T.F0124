using System;

using R5T.T0132;


namespace R5T.F0124.Implementations
{
    [FunctionalityMarker]
    public partial interface IObjectOperator : IFunctionalityMarker
    {
        /// <summary>
        /// This is how the static <see cref="Object.Equals(object, object)"/> method works.
        /// </summary>
        /// <remarks>
        /// See explanation here: <see href="https://stackoverflow.com/a/1451459"/>.
        /// See documentation here: <see href="https://learn.microsoft.com/en-us/dotnet/api/system.object.equals?view=net-6.0#system-object-equals(system-object-system-object)"/>.
        /// </remarks>
        public bool Static_Equals(object a, object b)
        {
            Func<object, object, bool> referenceEquality = Object.ReferenceEquals;

            var sameReference = referenceEquality(a, b);

            if (sameReference)
            {
                return true;
            }

            var aIsNull = referenceEquality(a, null);
            var bIsNull = referenceEquality(b, null);

            if (aIsNull || bIsNull)
            {
                return false;
            }

            // Finally, use the any type-specific (perhaps overloaded) equality operator.
            return a.Equals(b);
        }
    }
}
