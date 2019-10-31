namespace Option
{
    using System;
    using System.Collections.Generic;

    public struct Option<T> : IOption<T>
    {
        private readonly T _some;
        public bool IsNone => !IsSome;
        public bool IsSome { get; }

        private Option(T some, bool hasValue)
        {
            _some = some;
            IsSome = hasValue;
        }

        public static Option<T> Some(T value)
        {
#pragma warning disable 8653
            var isValue = typeof(T).IsValueType;
            return isValue 
                ? new Option<T>(value, true) 
                : new Option<T>(value, !EqualityComparer<T>.Default.Equals(value, default(T)));
#pragma warning restore 8653
        }
            
        public static Option<T> None => new Option<T>();

        public T Value =>
            IsNone
                ? throw new InvalidOperationException("Cannot access Some of None")
                : _some;

        public static implicit operator Option<T>(T value)
        {
            var isValue = typeof(T).IsValueType;
            if (isValue)
                throw new ArgumentException("cannot use implicit operator for a value type.");
            return value == null 
                ? None 
                : Some(value);
        } 
        
        public static implicit operator T(Option<T> some) => some.Value;
    }
}