using System;
using Shouldly;

namespace Option.Tests
{
    using Xunit;
    using static OptionExtension;

    public class ExtensionTests
    {
        [Fact]
        public void Some_PredicateIsTrue_ReturnSome()
        {
            var result = "dd".SomeWhen(x => !string.IsNullOrWhiteSpace(x));

            result.IsSome().ShouldBeTrue();
        }

        [Fact]
        public void Some_PredicateIsFalse_ReturnNone()
        {
            var result = "dd".SomeWhen(string.IsNullOrWhiteSpace);

            result.IsNone().ShouldBeTrue();
        }

        [Fact]
        public void Some_ForValue_ReturnSome()
        {
            var result = "dd".AsSome();

            result.IsSome().ShouldBeTrue();
        }

        [Fact]
        public void None_PredicateIsTrue_ReturnNone()
        {
            var result = "dd".None(x => !string.IsNullOrWhiteSpace(x));

            result.IsNone().ShouldBeTrue();
        }

        [Fact]
        public void None_PredicateIsFalse_ReturnSome()
        {
            var result = "dd".None(string.IsNullOrWhiteSpace);

            result.IsSome().ShouldBeTrue();
        }

        public class WhenOptionHasValue
        {
            private readonly IOption<string> _option = Some("walesa");

            [Fact]
            public void IsSome_ReturnTrue() =>
                _option.IsSome().ShouldBeTrue();

            [Fact]
            public void IsNone_ReturnFalse() =>
                _option.IsNone().ShouldBeFalse();

            [Fact]
            public void Value_ReturnWalesa() =>
                (_option is Some<string> some ? some : default).Value.ShouldBe("walesa");

            [Fact]
            public void ImplicitOperator_ReturnWalesa()
            {
                string result = _option is Some<string> some ? some : default;
                result.ShouldBe("walesa");
            }
        }

        public class WhenOptionHasNotValue
        {
            private readonly IOption<string> _option = None<string>();

            [Fact]
            public void IsSome_ReturnFalse() =>
                _option.IsSome().ShouldBeFalse();

            [Fact]
            public void IsNone_ReturnTrue() =>
                _option.IsNone().ShouldBeTrue();

            [Fact]
            public void Value_ThrowsException() =>
                Assert.Throws<ArgumentException>(() => (_option is Some<string> some ? some : throw new ArgumentException("")).Value);

            [Fact]
            public void ImplicitOperator_ThrowsException()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    string _ = _option is Some<string> some ? some : throw new ArgumentException("");
                });
            }
        }

        public class WhenOptionHasNotValueAndIsValueType
        {
            private readonly IOption<int> _option = None<int>();

            [Fact]
            public void IsSome_ReturnFalse() =>
                _option.IsSome().ShouldBeFalse();

            [Fact]
            public void IsNone_ReturnTrue() =>
                _option.IsNone().ShouldBeTrue();

            [Fact]
            public void Value_ThrowsException() =>
                Assert.Throws<ArgumentException>(() => (_option is Some<int> some ? some : throw new ArgumentException("")).Value);
        }

        public class WhenOptionHasValueAndItIsADefaultValueButTheOptionIsCorrectAndItIsAValueType
        {
            private readonly IOption<bool> _option = Some(false);

            [Fact]
            public void IsSome_ReturnTrue() =>
                _option.IsSome().ShouldBeTrue();

            [Fact]
            public void IsNone_ReturnFalse() =>
                _option.IsNone().ShouldBeFalse();

            [Fact]
            public void Value_ReturnsFalse()
            {
                var result = (Some<bool>) _option;
                result.Value.ShouldBeFalse();
            }
        }

        public class MapTests
        {
            [Fact]
            public void Map_OnSome()
            {
                var counter = 0;
                Some("dede").Map(_ => counter++, () => counter--);

                counter.ShouldBe(1);
            }

            [Fact]
            public void Map_OnNone()
            {
                var counter = 0;
                None<string>().Map(_ => counter++, () => counter--);

                counter.ShouldBe(-1);
            }
        }
    }
}