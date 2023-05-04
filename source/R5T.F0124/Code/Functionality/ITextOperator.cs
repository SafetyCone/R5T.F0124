using System;
using System.Collections.Generic;
using System.Linq;
using R5T.F0000;
using R5T.T0132;


namespace R5T.F0124
{
    [FunctionalityMarker]
    public partial interface ITextOperator : IFunctionalityMarker
    {
        public string[] Format_IntoColumns(
            IEnumerable<string> lines,
            IColumnSeparator columnSeparator)
        {
            var tokenSets = lines
                .Select(line => Instances.StringOperator_Base.Split(
                    columnSeparator.Value,
                    line))
                .Now();

            var numberOfColumns = tokenSets.First().Length;

            var maxLengths = new int[numberOfColumns];

            for (int iColumn = 0; iColumn < numberOfColumns; iColumn++)
            {
                var maxLength = 0;

                foreach (var token in tokenSets.Select(x => x[iColumn]))
                {
                    var tokenLength = token.Length;

                    if(tokenLength > maxLength)
                    {
                        maxLength = tokenLength;
                    }
                }

                maxLengths[iColumn] = maxLength;
            }

            var output = tokenSets
                .Select(tokenSet =>
                {
                    var line = Instances.StringOperator.Join(
                        columnSeparator.Value,
                        tokenSet.Select(
                            (token, columnNumber) =>
                            {
                                var requiredLength = maxLengths[columnNumber];

                                var lengthendToken = token.PadRight(
                                    requiredLength,
                                    Instances.Characters.Space);

                                return lengthendToken;
                            }
                        )
                    );

                    return line;
                })
                .Now();

            return output;
        }

        public string Get_TextRepresentation(string text)
        {
            var output = text switch
            {
                Z0000.IStrings.Empty_Constant => Instances.Strings.Empty_TextRepresentation,
                Z0000.IStrings.NewLine_NonWindows_Constant => Instances.Strings.NewLine_TextRepresentation,
                Z0000.IStrings.NewLine_Windows_Constant => Instances.Strings.NewLine_Windows,
                Z0000.IStrings.Null_Constant => Instances.Strings.Null_TextRepresentation,
                Z0000.IStrings.Tab_Constant => Instances.Strings.Tab_TextRepresentation,
                _ => text
            };

            return output;
        }

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
