namespace Option
{
    using System;

    public static class OptionExtension
    {
        public static Option<TType> Some<TType>(this TType t) => Option<TType>.Some(t);
        public static Option<TType> SomeWhen<TType>(this TType t, Predicate<TType> predicate) => predicate(t) ? Option<TType>.Some(t) : Option<TType>.None;
        public static Option<TType> NoneWhen<TType>(this TType t, Predicate<TType> predicate) => t.SomeWhen(x => !predicate(x));
    }
}