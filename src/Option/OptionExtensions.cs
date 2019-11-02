namespace Option
{
    using System;

    public static class OptionExtension
    {
        public static Option<TType> Some<TType>(this TType t) => Option<TType>.Some(t);

        public static Option<TType> Some<TType>(this TType t, Predicate<TType> when) =>
            when(t) ? Option<TType>.Some(t) : Option<TType>.None;

        public static Option<TType> None<TType>(this TType t, Predicate<TType> when) => t.Some(x => !when(x));
    }
}