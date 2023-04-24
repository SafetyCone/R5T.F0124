using System;


namespace R5T.F0124.Extensions
{
    public static class CharacterExtensions
    {
        public static N000.ILineSeparator ToLineSeparator(this char value)
        {
            return Instances.CharacterOperator_Extensions.ToLineSeparator(value);
        }
    }
}
