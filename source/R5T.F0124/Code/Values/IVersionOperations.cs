using System;

using R5T.T0131;


namespace R5T.F0124
{
    [ValuesMarker]
    public partial interface IVersionOperations : IValuesMarker
    {
        public Func<Version, bool> Is_MajorVersion(int majorVersion)
        {
            return version => Instances.VersionOperator.Is_MajorVersion(
                version,
                majorVersion);
        }
    }
}
