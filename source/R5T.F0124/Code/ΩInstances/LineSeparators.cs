using System;


namespace R5T.F0124
{
    public class LineSeparators : ILineSeparators
    {
        #region Infrastructure

        public static ILineSeparators Instance { get; } = new LineSeparators();


        private LineSeparators()
        {
        }

        #endregion
    }
}
