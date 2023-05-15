using System;
using System.Collections.Generic;


namespace R5T.F0124.Extensions
{
    public static partial class CharacterExtensions
    {
        public static string Get_String(this IEnumerable<char> characters)
        {
            return Instances.CharacterOperator.Get_String(characters);
        }
    }
}
