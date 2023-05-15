using System;

using R5T.T0132;
using R5T.T0180;
using R5T.T0180.Extensions;


namespace R5T.F0124
{
    [FunctionalityMarker]
    public partial interface IDirectoryNameOperator : IFunctionalityMarker
    {
        public string Ensure_IsValid(string directoryName)
        {
            // Re-use the filename code, since directory names are really just file names.
            var output = Instances.FileNameOperator.Replace_InvalidCharacters(directoryName);
            return output;
        }

        public IDirectoryName Ensure_IsValid(IDirectoryName directoryName)
        {
            var output = this.Ensure_IsValid(directoryName.Value)
                .ToDirectoryName();

            return output;
        }
    }
}
