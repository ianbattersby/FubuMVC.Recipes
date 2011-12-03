namespace IUrlRegistryRecipe.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class ValuePairList<TKey, TValue>
    {
        private readonly IList<ValuePair<TKey, TValue>> values;

        public ValuePairList()
        {
            this.values = new List<ValuePair<TKey, TValue>>();
        }

        public void Add(TKey key, TValue value)
        {
            this.values.Add(new ValuePair<TKey, TValue>(key, value));
        }

        public int Count()
        {
            return this.values.Count;
        }

        public IEnumerable<ValuePair<TKey, TValue>> AsEnumerable()
        {
            return this.values;
        }
    }
}