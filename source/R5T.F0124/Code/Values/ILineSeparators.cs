using System;

using R5T.T0131;

using R5T.F0124.Extensions;


namespace R5T.F0124
{
    [ValuesMarker]
    public partial interface ILineSeparators : IValuesMarker
    {
        /// <summary>
        /// Chooses <see cref="Windows"/> as the default.
        /// <para><inheritdoc cref="Windows" path="/summary"/></para>
        /// </summary>
        public ILineSeparator Default => this.Windows;

        /// <inheritdoc cref="Z0000.IStrings.NewLine_Windows"/>
        public ILineSeparator Windows => Instances.Strings.NewLine_Windows.ToLineSeparator();
        
        /// <inheritdoc cref="Z0000.IStrings.NewLine_NonWindows"/>
        public ILineSeparator NonWindows => Instances.Strings.NewLine_NonWindows.ToLineSeparator();
    }
}
