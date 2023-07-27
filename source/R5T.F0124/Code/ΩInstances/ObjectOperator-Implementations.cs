using System;


namespace R5T.F0124.Implementations
{
    public class ObjectOperator : IObjectOperator
    {
        #region Infrastructure

        public static IObjectOperator Instance { get; } = new ObjectOperator();


        private ObjectOperator()
        {
        }

        #endregion
    }
}
