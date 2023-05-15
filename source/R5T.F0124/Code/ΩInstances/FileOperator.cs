using System;


namespace R5T.F0124
{
    public class FileOperator : IFileOperator
    {
        #region Infrastructure

        public static IFileOperator Instance { get; } = new FileOperator();


        private FileOperator()
        {
        }

        #endregion
    }
}
