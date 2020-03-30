namespace MifuminLib
{
    /// <summary>ToStringで好きな文字列を返せるようにする</summary>
    /// <typeparam name="T">対象のオブジェクトの型</typeparam>
    class AliasObject<T>
    {
        readonly T obj;
        readonly string name;

        public AliasObject(T obj, string name)
        {
            this.obj = obj;
            this.name = name;
        }

        public override string ToString() { return name; }
        public T Get() { return obj; }
        public static implicit operator T(AliasObject<T> ao) { return ao.obj; }
        public override bool Equals(object obj) { return this.obj.Equals(obj); }
        public override int GetHashCode() { return obj.GetHashCode(); }
    }
}
