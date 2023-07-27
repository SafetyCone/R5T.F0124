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

        /// <summary>
        /// Determines if the directory name contains any invalid characters.
        /// <inheritdoc cref="IFileNameOperator.Has_InvalidCharacters(string)" path="/summary/characters-source"/>
        /// </summary>
        public bool Is_Valid(string directoryName)
        {
            // Re-use the filename code, since directory names are really just file names.
            return Instances.FileNameOperator.Is_Valid(directoryName);
        }

        public TDirectoryName Verify_IsValid<TDirectoryName>(
            string directoryName,
            Func<string, TDirectoryName> directoryNameConstructor)
            where TDirectoryName : IDirectoryName
        {
            var isValid = this.Is_Valid(directoryName);
            if(!isValid)
            {
                throw new Exception($"Directory name '{directoryName}' was not valid.");
            }

            var output = directoryNameConstructor(directoryName);
            return output;
        }
    }
}
