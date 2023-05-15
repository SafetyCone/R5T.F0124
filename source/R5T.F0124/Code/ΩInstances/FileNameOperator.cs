using System;


namespace R5T.F0124
{
    public class FileNameOperator : IFileNameOperator
    {
        #region Infrastructure

        public static IFileNameOperator Instance { get; } = new FileNameOperator();


        private FileNameOperator()
        {
        }

        #endregion
    }
}
