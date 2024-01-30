using System;

using R5T.T0132;
using R5T.T0180;
using R5T.T0180.Extensions;


namespace R5T.F0124
{
    [FunctionalityMarker]
    public partial interface IFilePathOperator : IFunctionalityMarker
    {
        public IDirectoryPath Get_DirectoryPath(IFilePath filePath)
        {
            var output = Instances.PathOperator.Get_ParentDirectoryPath_ForFile(
                filePath.Value)
                .ToDirectoryPath();

            return output;
        }
    }
}
