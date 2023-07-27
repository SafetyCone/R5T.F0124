using System;


namespace R5T.F0124
{
    public class EnvironmentVariableNameOperator : IEnvironmentVariableNameOperator
    {
        #region Infrastructure

        public static IEnvironmentVariableNameOperator Instance { get; } = new EnvironmentVariableNameOperator();


        private EnvironmentVariableNameOperator()
        {
        }

        #endregion
    }
}
