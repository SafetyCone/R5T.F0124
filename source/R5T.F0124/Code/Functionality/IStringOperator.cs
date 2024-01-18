using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using R5T.T0132;
using R5T.T0176;
using R5T.T0176.Extensions;
using R5T.T0221;

using String = System.String;


namespace R5T.F0124
{
    [FunctionalityMarker]
    public partial interface IStringOperator : IFunctionalityMarker
    {
        private static F0000.IStringOperator Base => F0000.StringOperator.Instance;


        public bool Equals_CaseSensitive(string a, string b)
        {
            var output = String.Equals(a, b, StringComparison.InvariantCulture);
            return output;
        }

        public bool Equals_CaseInsensitive(string a, string b)
        {
            var output = String.Equals(a, b, StringComparison.InvariantCultureIgnoreCase);
            return output;
        }

        public string Get_LeadingWhitespace(string @string)
        {
            var isNullOrEmpty = Instances.StringOperator_Base.Is_NullOrEmpty(@string);
            if(isNullOrEmpty)
            {
                return Instances.Strings.Empty;
            }

            int count = 0;
            foreach (var character in @string)
            {
                if(Instances.CharacterOperator_Base.Is_Whitespace(character))
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            var output = Instances.StringOperator_Base.Get_FirstNCharacters(
                @string,
                count);

            return output;
        }

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

        public string In_WriterContext(
            Action<StringWriter> action)
        {
            var writer = new StringWriter();

            action(writer);

            var output = writer.ToString();
            return output;
        }

        public string Join(string separator, IEnumerable<string> strings)
        {
            var output = System.String.Join(separator, strings);
            return output;
        }

        /// <inheritdoc cref="L0053.IStringOperator.Trim_End(String, String)"/>
        public string Trim_End(
            string value,
            string ending)
        {
            return Base.Trim_End(
                value,
                ending);
        }
    }
}
