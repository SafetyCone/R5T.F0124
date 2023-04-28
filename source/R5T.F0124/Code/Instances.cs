using System;


namespace R5T.F0124
{
    public static class Instances
    {
        public static Extensions.ICharacterOperator CharacterOperator_Extensions => Extensions.CharacterOperator.Instance;
        public static Z0000.ICharacters Characters => Z0000.Characters.Instance;
        public static IFilePathOperator FilePathOperator => F0124.FilePathOperator.Instance;
        public static F0002.IPathOperator PathOperator => F0002.PathOperator.Instance;
        public static IStringOperator StringOperator => F0124.StringOperator.Instance;
        public static Extensions.IStringOperator StringOperator_Extensions => Extensions.StringOperator.Instance;
        public static Z0000.IStrings Strings => Z0000.Strings.Instance;
    }
}