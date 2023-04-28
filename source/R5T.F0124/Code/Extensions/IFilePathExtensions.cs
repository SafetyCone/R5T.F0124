using System;

using R5T.T0180;


namespace R5T.F0124.Extensions
{
    public static class IFilePathExtensions
    {
        public static IDirectoryPath Get_DirectoryPath(this IFilePath filepath)
        {
            return Instances.FilePathOperator.Get_DirectoryPath(filepath);
        }
    }
}
