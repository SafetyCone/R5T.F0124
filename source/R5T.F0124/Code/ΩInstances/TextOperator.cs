using System;


namespace R5T.F0124
{
    public class TextOperator : ITextOperator
    {
        #region Infrastructure

        public static ITextOperator Instance { get; } = new TextOperator();


        private TextOperator()
        {
        }

        #endregion
    }
}
