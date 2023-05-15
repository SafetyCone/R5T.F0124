using System;


namespace R5T.F0124
{
    public class FileExistsBehaviors : IFileExistsBehaviors
    {
        #region Infrastructure

        public static IFileExistsBehaviors Instance { get; } = new FileExistsBehaviors();


        private FileExistsBehaviors()
        {
        }

        #endregion
    }
}
