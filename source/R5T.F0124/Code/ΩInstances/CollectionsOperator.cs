using System;


namespace R5T.F0124
{
    public class CollectionsOperator : ICollectionsOperator
    {
        #region Infrastructure

        public static ICollectionsOperator Instance { get; } = new CollectionsOperator();


        private CollectionsOperator()
        {
        }

        #endregion
    }
}
