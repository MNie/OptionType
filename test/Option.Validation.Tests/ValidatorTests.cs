namespace Option.Validator.Tests
{
    using System.Collections.Generic;
    using Shouldly;
    using Validation;
    using Validator;
    using Xunit;

    public class DogValidator : Validator<string>
    {
        private readonly string _name;
        private readonly string _breed;

        public DogValidator(string name, string breed)
        {
            _name = name;
            _breed = breed;
        }
        protected override IEnumerable<IRule<string>> GetRules()
        {
            return new[]
            {
                new Rule<string>(() => !string.IsNullOrEmpty(_name), "dogs name cannot be null not empty"),
                new Rule<string>(() => !string.IsNullOrEmpty(_breed), "dogs breed cannot be null not empty")
            };
        }
    }

    public class ValidatorTests
    {
        [Fact]
        public void Validate_WhenAllPredicatesAreOk_ErrorListIsEmpty()
        {
            const string dogsName = "bob";
            const string dogsBreed = "random";

            var validator = new DogValidator(dogsName, dogsBreed);
            validator.Validate().ShouldBeEmpty();
        }

        [Fact]
        public void Validate_WhenAllPredicatesAreNotOk_ErrorListContainsAllErrors()
        {
            const string dogsName = "";
            const string dogsBreed = "";

            var validator = new DogValidator(dogsName, dogsBreed);
            validator.Validate().ShouldBe(new []{ "dogs name cannot be null not empty", "dogs breed cannot be null not empty" });
        }

        [Fact]
        public void Validate_WhenOnlyOnePredicateIsNotOk_ErrorListContainsASingleErrorRelatedToThesePredicate()
        {
            const string dogsName = "";
            const string dogsBreed = "husky";

            var validator = new DogValidator(dogsName, dogsBreed);
            validator.Validate().ShouldBe(new[] {"dogs name cannot be null not empty"});
        }
    }
}
