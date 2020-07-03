// ReSharper disable VirtualMemberCallInConstructor
namespace Option.Validation
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Validator<TError>
    {
        private readonly IEnumerable<IRule<TError>> _rules;

        protected abstract IEnumerable<IRule<TError>> GetRules();

        public IEnumerable<TError> Validate() => _rules
            .Apply()
            .Select(x => (x is Some<TError> some ? some : default).Value);

        protected Validator() =>
            _rules = GetRules();
    }
}