using System;


namespace R5T.F0124
{
    public class EnvironmentOperator : IEnvironmentOperator
    {
        #region Infrastructure

        public static IEnvironmentOperator Instance { get; } = new EnvironmentOperator();


        private EnvironmentOperator()
        {
        }

        #endregion
    }
}
