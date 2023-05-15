using System;

using R5T.F0000;
using R5T.T0132;
using R5T.T0176;
using R5T.T0176.Extensions;
using R5T.T0180;


namespace R5T.F0124
{
    [FunctionalityMarker]
    public partial interface IFileNameOperator : IFunctionalityMarker
    {
        private static F0000.IPathOperator PathOperator_Base => F0000.PathOperator.Instance;


        //public (IFileName fileName, bool wasModified) Get_FileName(string filename)
        //{

        //}

        public string Ensure_IsValid(string fileName)
        {
            var output = this.Replace_InvalidCharacters(fileName);
            return output;
        }

        /// <inheritdoc cref="F0000.IPathOperator.GetInvalidFileNameCharacters"/>
        public IDistinctArray<char> Get_InvalidCharacters()
        {
            var output = PathOperator_Base.GetInvalidFileNameCharacters().AsDistinctArray();
            return output;
        }

        public WasFound<IDistinctArray<char>> Has_InvalidCharacters(string fileName)
        {
            var invalidCharacters = this.Get_InvalidCharacters();

            var invalidCharactersFound = Instances.StringOperator.Has_AnyOf(
                fileName,
                invalidCharacters);

            return invalidCharactersFound;
        }

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
