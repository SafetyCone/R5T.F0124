using System;

using R5T.T0132;


namespace R5T.F0124.N000
{
    [FunctionalityMarker]
    public partial interface IPathOperator : IFunctionalityMarker
    {
        private static F0002.IPathOperator F0002 => R5T.F0002.PathOperator.Instance;


        public string Ensure_DirectoryPath_IsDirectoryIndicated_If(
            string directoryPath,
            bool ensureDirectoryPathIsDirectoryIndicated)
        {
            var output = ensureDirectoryPathIsDirectoryIndicated
                ? F0002.Ensure_IsDirectoryIndicated(directoryPath)
                : directoryPath
                ;

            return output;
        }
    }
}
