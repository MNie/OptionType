namespace Option
{
    using System;

    public static class OptionExtension
    {
        public static IOption<TType> Some<TType>(TType value) => new Some<TType>(value);
        public static IOption<TType> AsSome<TType>(this TType value) => new Some<TType>(value);
        public static IOption<TType> None<TType>() => new None<TType>();

        public static IOption<TType> SomeWhen<TType>(this TType t, Predicate<TType> when) =>
            when(t) ? Some(t) : None<TType>();

        public static IOption<TType> None<TType>(this TType t, Predicate<TType> when) => t.SomeWhen(x => !when(x));

        public static bool IsSome<TType>(this IOption<TType> opt) =>
            opt switch
            {
                Some<TType> _ => true,
                None<TType> _ => false,
                _ => throw new ArgumentException("IOption could be only Some or None")
            };

        public static bool IsNone<TType>(this IOption<TType> opt) =>
            opt switch
            {
                Some<TType> _ => false,
                None<TType> _ => true,
                _ => throw new ArgumentException("IOption could be only Some or None")
            };

        public static TReturn Map<TInput, TReturn>(this IOption<TInput> opt, Func<TInput, TReturn> onSome, Func<TReturn> onNone) =>
            opt switch
            {
                Some<TInput> s => onSome(s),
                None<TInput> _ => onNone(),
                _ => throw new ArgumentException("IOption could be only Some or None")
            };
    }
}