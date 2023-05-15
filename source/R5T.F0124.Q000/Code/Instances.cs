using System;


namespace R5T.F0124.Q000
{
    public static class Instances
    {
        public static F0000.ICharacterOperator CharacterOperator_Base => F0000.CharacterOperator.Instance;
        public static IFileNameOperator FileNameOperator => F0124.FileNameOperator.Instance;
        public static Z0015.IFilePaths FilePaths => Z0015.FilePaths.Instance;
        public static F0000.IFileOperator FileOperator => F0000.FileOperator.Instance;
        public static F0033.INotepadPlusPlusOperator NotepadPlusPlusOperator => F0033.NotepadPlusPlusOperator.Instance;
    }
}