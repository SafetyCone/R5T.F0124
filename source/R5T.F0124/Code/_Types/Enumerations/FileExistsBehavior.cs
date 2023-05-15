using System;

using R5T.T0142;


namespace R5T.F0124
{
    /// <summary>
    /// Specifies what should be done when writing to a file if it already exists.
    /// </summary>
    [UtilityTypeMarker]
    public enum FileExistsBehavior
    {
        /// <summary>
        /// Throw an exception.
        /// This is the default behavior, and was chosen as the default to preserve existing file contents.
        /// </summary>
        Error = 0,

        /// <summary>
        /// Overwrite the contents of the file (default).
        /// </summary>
        Overwrite = 1,

        /// <summary>
        /// Skip writing the file.
        /// </summary>
        Skip = 2,
    }
}
