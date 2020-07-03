namespace Option.Validation
{
    using System;
    using static OptionExtension;

    public interface IRule<TError>
    {
        IOption<TError> Apply();
    }

    public class Rule<TError> : IRule<TError>
    {
        private readonly Func<bool> _predicate;
        private readonly TError _error;

        public Rule(Func<bool> predicate, TError error)
        {
            _predicate = predicate;
            _error = error;
        }

        public IOption<TError> Apply() => _predicate()
            ? None<TError>()
            : Some<TError>(_error);
    }
}
