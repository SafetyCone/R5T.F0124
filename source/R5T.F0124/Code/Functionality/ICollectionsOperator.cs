using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.F0124
{
    [FunctionalityMarker]
    public partial interface ICollectionsOperator : IFunctionalityMarker
    {
        public IEnumerable<TKey> Convert_Keys<TKey>(IDictionary dictionary)
        {
            var output = dictionary.Keys.Cast<TKey>();
            return output;
        }

        public IEnumerable<TValue> Convert_Values<TValue>(IDictionary dictionary)
        {
            var output = dictionary.Values.Cast<TValue>();
            return output;
        }

        public Dictionary<TKey, TValue> Convert_NonGenericToGeneric<TKey, TValue>(IDictionary dictionary)
        {
            var keys = this.Convert_Keys<TKey>(dictionary);
            var values = this.Convert_Values<TValue>(dictionary);

            var pairs = keys.Zip(
                values,
                (key, value) => new KeyValuePair<TKey, TValue>(key, value));

            var output = new Dictionary<TKey, TValue>(pairs);
            return output;
        }

        public IEnumerable<TKey> Get_Keys<TKey>(IDictionary dictionary)
        {
            return this.Convert_Keys<TKey>(dictionary);
        }

        public IEnumerable<TValue> Get_Values<TValue>(IDictionary dictionary)
        {
            return this.Get_Values<TValue>(dictionary);
        }
    }
}
