namespace KiwiFramework.Core
{
    public class KV<TK, TV>
    {
        public TK Key;
        public TV Value;

        public KV(TK key, TV value)
        {
            Key = key;
            Value = value;
        }
    }
}