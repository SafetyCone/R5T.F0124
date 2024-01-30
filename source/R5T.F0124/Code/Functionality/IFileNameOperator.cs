using System;

using R5T.L0089.T000;
using R5T.T0132;
using R5T.T0176;
using R5T.T0176.Extensions;


namespace R5T.F0124
{
    [FunctionalityMarker]
    public partial interface IFileNameOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        private static F0000.IPathOperator _Base => F0000.PathOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public string Ensure_IsValid(string fileName)
        {
            var output = this.Replace_InvalidCharacters(fileName);
            return output;
        }

        /// <inheritdoc cref="L0066.IPathOperator.Get_InvalidFileNameCharacters"/>
        public IDistinctArray<char> Get_InvalidCharacters()
        {
            var output = _Base.Get_InvalidFileNameCharacters().AsDistinctArray();
            return output;
        }

        /// <summary>
        /// Determines if the filename contains any of the characters that are not allowed in file names on the current system.
        /// <characters-source>
        /// <para>
        /// See <see cref="Get_InvalidCharacters"/>.
        /// </para>
        /// </characters-source>
        /// </summary>
        public WasFound<IDistinctArray<char>> Has_InvalidCharacters(string fileName)
        {
            var invalidCharacters = this.Get_InvalidCharacters();

            var invalidCharactersFound = Instances.StringOperator.Has_AnyOf(
                fileName,
                invalidCharacters);

            return invalidCharactersFound;
        }

        /// <summary>
        /// Determines if the file name contains any invalid characters.
        /// <inheritdoc cref="Has_InvalidCharacters(string)" path="/summary/characters-source"/>
        /// </summary>
        public bool Is_Valid(string fileName)
        {
            var hasInvalidCharacters = this.Has_InvalidCharacters(fileName);

            return !hasInvalidCharacters;
        }

        public string Replace_InvalidCharacters(string fileName)
        {
            var invalidCharacters = this.Get_InvalidCharacters();

            var modified = Instances.StringOperator_Base.Replace(
                fileName,
                Instances.Characters.Underscore,
                invalidCharacters);

            return modified;
        }
    }
}
