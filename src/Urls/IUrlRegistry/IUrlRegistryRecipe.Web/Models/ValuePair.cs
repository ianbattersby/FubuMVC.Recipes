namespace IUrlRegistryRecipe.Web.Models
{
    using System;

    public class ValuePair<TKey, TValue>
    {
        public ValuePair(
            TKey key,
            TValue Value)
        {
            this.Key = key;
            this.Value = Value;
        }

        public TKey Key { get; private set; }
        public TValue Value { get; private set; }
    }
}