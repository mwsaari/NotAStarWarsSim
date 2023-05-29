using System.Collections;

namespace NotAStarWarsSim.Shared
{
    public class ArrayByEnum<T, U> : IEnumerable<T> where U : Enum // requires C# 7.3 or later
    {
        private readonly T[] _array;
        private readonly int _lower;

        public ArrayByEnum()
        {
            _lower = Convert.ToInt32(Enum.GetValues(typeof(U)).Cast<U>().Min());
            int upper = Convert.ToInt32(Enum.GetValues(typeof(U)).Cast<U>().Max());
            _array = new T[1 + upper - _lower];
        }

        public T this[U key]
        {
            get => _array[Convert.ToInt32(key) - _lower];
            set => _array[Convert.ToInt32(key) - _lower] = value;
        }

        public IEnumerator GetEnumerator()
        {
            return _array.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return Enum.GetValues(typeof(U)).Cast<U>().Select(i => this[i]).GetEnumerator();
        }
    }
}
