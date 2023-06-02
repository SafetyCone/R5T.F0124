using System;
using System.Collections.Generic;
using System.Linq;

using R5T.F0000;
using R5T.T0132;
using R5T.T0176;
using R5T.T0176.Extensions;


namespace R5T.F0124
{
    [FunctionalityMarker]
    public partial interface IStringOperator : IFunctionalityMarker
    {
        public WasFound<IDistinctArray<char>> Has_AnyOf(string @string, IEnumerable<char> characters)
        {
            var distinctEnumerable = characters.ToDistinctEnumerable();

            return this.Has_AnyOf(@string, distinctEnumerable);
        }

        public WasFound<IDistinctArray<char>> Has_AnyOf(string @string, IDistinctEnumerable<char> characters)
        {
            var charactersFound = new List<char>();
            foreach (var character in characters)
            {
                var wasFoundInString = Instances.StringOperator_Base.Contains(
                    @string,
                    character);

                if(wasFoundInString)
                {
                    charactersFound.Add(character);
                }
            }

            var exists = charactersFound.Any();

            var result = charactersFound.ToArray().AsDistinctArray();

            var output = WasFound.From(exists, result);
            return output;
        }

        public string Join(string separator, IEnumerable<string> strings)
        {
            var output = System.String.Join(separator, strings);
            return output;
        }

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

        /// <summary>
        /// Trims the ending (if it exists) from the end of the provided value.
        /// </summary>
        public string Trim_End(
            string value,
            string ending)
        {
            var output = value;

            while (true)
            {
                bool valueEndsWithEnding = Instances.StringOperator_Base.EndsWith(
                    value,
                    ending);

                if(valueEndsWithEnding)
                {
                    output = Instances.StringOperator_Base.ExceptEnding(
                        output,
                        ending);
                }
                else
                {
                    break;
                }
            }

            return output;
        }

        /// <summary>
        /// Trims the beginning (if it exists) from the start of the provided value.
        /// </summary>
        public string Trim_Start(
            string value,
            string beginning)
        {
            var output = value;

            while (true)
            {
                bool valueStartsWithBeginning = Instances.StringOperator_Base.StartsWith(
                    value,
                    beginning);

                if (valueStartsWithBeginning)
                {
                    output = Instances.StringOperator_Base.ExceptBeginning(
                        output,
                        beginning);
                }
                else
                {
                    break;
                }
            }

            return output;
        }
    }
}
