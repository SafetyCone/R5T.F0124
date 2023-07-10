using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;
using R5T.T0185;
using R5T.T0185.Extensions;


namespace R5T.F0124
{
    [FunctionalityMarker]
    public partial interface IVersionOperator : IFunctionalityMarker
    {
        private static F0000.IVersionOperator VersionOperator_F0000 => F0000.VersionOperator.Instance;


        public Version Choose_HighestSubVersionOf(
            IEnumerable<Version> versions,
            int majorVersion)
        {
            var output = versions
                .Where(Instances.VersionOperations.Is_MajorVersion(majorVersion))
                .Max();

            return output;
        }

        public Version Choose_HighestSubVersionOf(
            IEnumerable<Version> versions,
            IMajorVersionNumber majorVersionNumber)
        {
            return this.Choose_HighestSubVersionOf(
                versions,
                majorVersionNumber.Value);
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Get_Version(IMajorMinorPatchVersionName)"/>.
        /// </summary>
        public Version From(IMajorMinorPatchVersionName majorMinorPatchVersionName)
        {
            return this.Get_Version(majorMinorPatchVersionName);
        }

        public Version Get_Version(IMajorMinorPatchVersionName majorMinorPatchVersionName)
        {
            var output = VersionOperator_F0000.From_Major_Minor_Build(majorMinorPatchVersionName.Value);
            return output;
        }

        public bool Is_MajorVersion(Version version, int majorVersion)
        {
            var output = version.Major == majorVersion;
            return output;
        }

        public IVersionName ToVersionName(Version version)
        {
            var output = VersionOperator_F0000.ToString_Major_Minor_Build(version)
                .ToVersionName();

            return output;
        }
    }
}
