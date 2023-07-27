using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using R5T.T0132;


namespace R5T.F0124.N000
{
    /// <summary>
    /// An C# intrinsics-level operator.
    /// </summary>
    [FunctionalityMarker]
    public partial interface IOperatingSystemOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Quality-of-life overload for <see cref="IEnvironmentOperator.Get_EnvironmentVariableNames(EnvironmentVariableTarget)"/>.
        /// </summary>
        public string[] Get_EnvironmentVariableNames(
            EnvironmentVariableTarget environmentVariableTarget = IValues.Default_EnvironmentVariableTarget_Constant)
        {
            return Instances.EnvironmentOperator_N000.Get_EnvironmentVariableNames(environmentVariableTarget);
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="IEnvironmentOperator.Get_EnvironmentVariables_Raw(EnvironmentVariableTarget)"/>.
        /// </summary>
        public IDictionary Get_EnvironmentVariables_Raw(
            EnvironmentVariableTarget environmentVariableTarget = IValues.Default_EnvironmentVariableTarget_Constant)
        {
            return Instances.EnvironmentOperator_N000.Get_EnvironmentVariables_Raw(environmentVariableTarget);
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="IEnvironmentOperator.Get_EnvironmentVariables(EnvironmentVariableTarget)"/>.
        /// </summary>
        public Dictionary<string, string> Get_EnvironmentVariables(
            EnvironmentVariableTarget environmentVariableTarget = IValues.Default_EnvironmentVariableTarget_Constant)
        {
            return Instances.EnvironmentOperator_N000.Get_EnvironmentVariables(environmentVariableTarget);
        }

        /// <summary>
        /// Unchecked in the sense that if the special folder does not exist on the current operating system,
        /// then no exception will be thrown.
        /// Instead the <see cref="IValues.GetSpecialFolderPathResult_NotFound"/> value will be returned.
        /// </summary>
        public string Get_SpecialDirectoryPath_Unchecked(
            Environment.SpecialFolder specialFolder)
        {
            var output = Environment.GetFolderPath(specialFolder,
                // Return empty string if the directory does not exist.
                Environment.SpecialFolderOption.None);

            return output;
        }

        /// <summary>
        /// Checked in the sense that if the special folder does not exist on the current operating system, an exception will be thrown.
        /// </summary>
        public string Get_SpecialDirectoryPath_Checked(
            Environment.SpecialFolder specialFolder,
            bool ensureIsDirectoryIndicated = IValues.Default_EnsureDirectoryPathIsDirectoryIndicated)
        {
            var specialDirectoryPath = this.Get_SpecialDirectoryPath_Unchecked(specialFolder);

            if(specialDirectoryPath == Instances.Values.GetSpecialFolderPathResult_NotFound)
            {
                throw new DirectoryNotFoundException($"Special directory '{specialFolder}' not found.");
            }

            var output = Instances.PathOperator_N000.Ensure_DirectoryPath_IsDirectoryIndicated_If(
                specialDirectoryPath,
                ensureIsDirectoryIndicated);

            return output;
        }

        /// <summary>
        /// Chooses <see cref="Get_SpecialDirectoryPath_Checked(Environment.SpecialFolder, bool)"/> as the default.
        /// </summary>
        public string Get_SpecialDirectoryPath(
            Environment.SpecialFolder specialFolder,
            bool ensureIsDirectoryIndicated = IValues.Default_EnsureDirectoryPathIsDirectoryIndicated)
        {
            return this.Get_SpecialDirectoryPath_Checked(specialFolder, ensureIsDirectoryIndicated);
        }
    }
}
