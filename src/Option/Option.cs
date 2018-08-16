namespace Option
{
    using System;

    public struct Option<T>
    {
        private readonly T _some;
        public bool IsNone => !IsSome;
        public readonly bool IsSome;

        private Option(T some)
        {
            IsSome = some != null;
            _some = some;
        }

        public static Option<T> Some(T value) => new Option<T>(value);
        public static Option<T> None => new Option<T>();

        public T Value =>
            IsNone
                ? throw new InvalidOperationException("Cannot access Some of None")
                : _some;
    }
}