using System;
using System.Linq;

using R5T.T0141;


namespace R5T.F0124.Q000
{
    [DemonstrationsMarker]
    public partial interface IFileNameDemonstrations : IDemonstrationsMarker
    {
        /// <summary>
        /// Outputs invalid file name characters to a file.
        /// </summary>
        /// <remarks>
        /// See the output in:
        ///     * R5T.Q0000\Reference\Path-Invalid Characters\Invalid File Name Characters.txt
        ///     * Or as values in R5T.F0124.Values.InvalidFileNameCharacters()
        /// </remarks>
        public void Output_InvalidFilenameCharacters_ToFile()
        {
            /// Inputs.
            var outputFilePath = Instances.FilePaths.OutputTextFilePath;


            /// Run.
            var invalidFilenameCharacters = Instances.FileNameOperator.Get_InvalidCharacters();

            Instances.CharacterOperator_Base.DescribeToFile_Synchronous(
                outputFilePath,
                // Show in 
                invalidFilenameCharacters.OrderAlphabetically());

            Instances.NotepadPlusPlusOperator.Open(outputFilePath);
        }
    }
}
