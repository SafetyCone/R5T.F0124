using System;


namespace R5T.F0124.Q000
{
    public class FileNameDemonstrations : IFileNameDemonstrations
    {
        #region Infrastructure

        public static IFileNameDemonstrations Instance { get; } = new FileNameDemonstrations();


        private FileNameDemonstrations()
        {
        }

        #endregion
    }
}
