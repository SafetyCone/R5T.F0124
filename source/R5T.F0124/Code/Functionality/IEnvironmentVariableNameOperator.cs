using System;
using System.Runtime.InteropServices;

using R5T.N0003;

using R5T.T0132;


namespace R5T.F0124
{
    [FunctionalityMarker]
    public partial interface IEnvironmentVariableNameOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Windows environment variable names are case-insensitive ("FOO" and "foo" are the same), while .
        /// See <see href="https://learn.microsoft.com/en-us/windows/wsl/case-sensitivity#differences-between-windows-and-linux-case-sensitivity"/>
        /// </summary>
        public bool Are_Equal(
            string environmentVariableNameA,
            string environmentVariableNameB,
            OSPlatform osPlatform)
        {
            var comparer = Instances.OperatingSystemOperator.SwitchOn_OSPlatform<Func<string, string, bool>>(
                osPlatform,
                Instances.StringOperator.Equals_CaseInsensitive,
                Instances.StringOperator.Equals_CaseSensitive);

            var output = comparer(environmentVariableNameA, environmentVariableNameB);
            return output;
        }

        /// <inheritdoc cref="Are_Equal(string, string, OSPlatform)"/>
        public bool Are_Equal(
            string environmentVariableNameA,
            string environmentVariableNameB)
        {
            var osPlatform = Instances.OperatingSystemOperator.Get_OSPlatform();

            return this.Are_Equal(
                environmentVariableNameA,
                environmentVariableNameB,
                osPlatform);
        }

        /// <inheritdoc cref="Are_Equal(string, string, OSPlatform)"/>
        public bool Are_Equal(
            IEnvironmentVariableName environmentVariableNameA,
            IEnvironmentVariableName environmentVariableNameB)
        {
            return this.Are_Equal(
                environmentVariableNameA.Value,
                environmentVariableNameB.Value);
        }

        /// <inheritdoc cref="Are_Equal(string, string, OSPlatform)"/>
        public bool Are_Equal(
            IEnvironmentVariableName environmentVariableNameA,
            IEnvironmentVariableName environmentVariableNameB,
            OSPlatform osPlatform)
        {
            return this.Are_Equal(
                environmentVariableNameA.Value,
                environmentVariableNameB.Value,
                osPlatform);
        }
    }
}
