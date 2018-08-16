namespace Option.Validator
{
    using System;

    public interface IRule<TError>
    {
        Option<TError> Apply();
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

        public Option<TError> Apply() => _predicate() 
            ? Option<TError>.None 
            : Option<TError>.Some(_error);
    }
}
