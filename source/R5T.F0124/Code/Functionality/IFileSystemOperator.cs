using System;
using System.Linq;

using R5T.T0132;
using R5T.T0180;
using R5T.T0180.Extensions;


namespace R5T.F0124
{
    [FunctionalityMarker]
    public partial interface IFileSystemOperator : IFunctionalityMarker
    {
        private static F0000.IFileSystemOperator Base => F0000.FileSystemOperator.Instance;


        /// <summary>
        /// Enumeration child file paths with specified extension.
        /// </summary>
        public IFilePath[] Get_ChildFilePaths(
            IDirectoryPath directoryPath,
            IFileExtension fileExtension)
        {
            var output = Base.FindChildFilesInDirectoryByFileExtension(
                directoryPath.Value,
                fileExtension.Value)
                .Select(x => x.ToFilePath())
                .ToArray();

            return output;
        }
    }
}
