using System;

using R5T.T0131;


namespace R5T.F0124
{
    [ValuesMarker]
    public partial interface IFileExistsBehaviors : IValuesMarker
    {
        public const FileExistsBehavior Default = FileExistsBehavior.Error;
    }
}
