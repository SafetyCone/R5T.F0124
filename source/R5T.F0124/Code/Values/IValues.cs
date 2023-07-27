using System;

using R5T.T0131;


namespace R5T.F0124
{
    [ValuesMarker]
    public partial interface IValues : IValuesMarker
    {
        /// <summary>
        /// Whenever there is an option to alphabetize, there is a question of whether the order of the elements matters.
        /// This value was chosen since alphabetized lines are generally easier to understand.
        /// </summary>
        public const bool Default_Alphabetization_Constant = true;
        
        /// <summary>
        /// When returning directory paths, there is an option to ensure that the directory path is directory indicated (ends with a path separator, either '/' or '\').
        /// </summary>
        public const bool Default_EnsureDirectoryPathIsDirectoryIndicated = true;

        /// <summary>
        /// Whenver environment varibles are requested, there is an option of what <see cref="EnvironmentVariableTarget"/> value to use.
        /// This value was chosen as the default because it works on both Windows and Non-Windows systems.
        /// </summary>
        public const EnvironmentVariableTarget Default_EnvironmentVariableTarget_Constant = EnvironmentVariableTarget.Process;

        /// <summary>
        /// When the result of <see cref="Environment.GetFolderPath(Environment.SpecialFolder)"/> does not exist (due to differing operating systems),
        /// then this value (the empty string, "") is returned.
        /// </summary>
        public string GetSpecialFolderPathResult_NotFound => Instances.Strings.Empty;
    }
}
