using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.F0124
{
    [FunctionalityMarker]
    public partial interface ICharacterOperator : IFunctionalityMarker
    {
        public string Get_String(params char[] characters)
        {
            var output = new string(characters);
            return output;
        }

        public string Get_String(IEnumerable<char> characters)
        {
            var charactersArray = characters.ToArray();

            var output = this.Get_String(charactersArray);
            return output;
        }
    }
}
