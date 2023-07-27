using System;


namespace R5T.F0124.N000
{
    public class OperatingSystemOperator : IOperatingSystemOperator
    {
        #region Infrastructure

        public static IOperatingSystemOperator Instance { get; } = new OperatingSystemOperator();


        private OperatingSystemOperator()
        {
        }

        #endregion
    }
}
