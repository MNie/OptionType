namespace Option
{
    public struct None<T> : IOption<T>
    {
    }

    public readonly struct Some<T> : IOption<T>
    {
        public readonly T Value;

        public Some(T value) => Value = value;

        public static implicit operator T(Some<T> some) => some.Value;
    }
}