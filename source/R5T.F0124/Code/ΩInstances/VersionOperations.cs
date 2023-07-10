using System;


namespace R5T.F0124
{
    public class VersionOperations : IVersionOperations
    {
        #region Infrastructure

        public static IVersionOperations Instance { get; } = new VersionOperations();


        private VersionOperations()
        {
        }

        #endregion
    }
}
