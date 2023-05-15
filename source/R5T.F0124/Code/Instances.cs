using System;


namespace R5T.F0124
{
    public static class Instances
    {
        public static ICharacterOperator CharacterOperator => F0124.CharacterOperator.Instance;
        public static Extensions.ICharacterOperator CharacterOperator_Extensions => Extensions.CharacterOperator.Instance;
        public static Z0000.ICharacters Characters => Z0000.Characters.Instance;
        public static IFileNameOperator FileNameOperator => F0124.FileNameOperator.Instance;
        public static IFilePathOperator FilePathOperator => F0124.FilePathOperator.Instance;
        public static F0000.IFileSystemOperator FileSystemOperator => F0000.FileSystemOperator.Instance;
        public static F0002.IPathOperator PathOperator => F0002.PathOperator.Instance;
        public static IStringOperator StringOperator => F0124.StringOperator.Instance;
        public static F0000.IStringOperator StringOperator_Base => F0000.StringOperator.Instance;
        public static Extensions.IStringOperator StringOperator_Extensions => Extensions.StringOperator.Instance;
        public static Z0000.IStrings Strings => Z0000.Strings.Instance;
    }
}