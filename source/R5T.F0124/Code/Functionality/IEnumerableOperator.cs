using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.F0124
{
    [FunctionalityMarker]
    public partial interface IEnumerableOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Gets all two-pair combinations.
        /// </summary>
        public (T, T)[] Get_Combinations<T>(IEnumerable<T> values)
        {
            var array = values.ToArray();

            IEnumerable<(T, T)> Internal()
            {
                var elementCount = array.Length;

                for (int i = 0; i < elementCount; i++)
                {
                    for (int j = i + 1; j < elementCount; j++)
                    {
                        var firstElement = array[i];
                        var secondElement = array[j];

                        yield return (firstElement, secondElement);
                    }
                }
            }

            var output = Internal().Now();
            return output;
        }
    }
}
