using System;

using R5T.T0132;
using R5T.T0180;
using R5T.T0181;
using R5T.T0185;


namespace R5T.F0124
{
    [FunctionalityMarker]
    public partial interface IFileOperator : IFunctionalityMarker,
        F0000.IFileOperator
    {
        public bool ShouldWrite_HandleFileExistsBehavior(
            FileExistsBehavior fileExistsBehavior,
            IFilePath filePath)
        {
            // Check if the file exists.
            var fileExists = Instances.FileSystemOperator.FileExists(
                filePath.Value);

            // If the file does exist, see if we should error, skip, or overwrite.
            if (fileExists)
            {
                if (fileExistsBehavior == FileExistsBehavior.Error)
                {
                    throw new Exception($"File path already exists:\n{filePath}");
                }

                var shouldWrite = fileExistsBehavior == FileExistsBehavior.Overwrite;
                return shouldWrite;
            }

            // Else, if the file does not exist:
            return true;
        }

        /// <returns>
        /// Returns whether or not the file was actually written.
        /// </returns>
        public bool Write_Synchronous(
            ITextFilePath textFilePath,
            IText text,
            FileExistsBehavior fileExistsBehavior = IFileExistsBehaviors.Default)
        {
            var shouldWrite = this.ShouldWrite_HandleFileExistsBehavior(
                fileExistsBehavior,
                textFilePath);

            if (shouldWrite)
            {
                this.WriteText_Synchronous(
                    textFilePath.Value,
                    text.Value);
            }

            var written = shouldWrite;
            return written;
        }
    }
}
