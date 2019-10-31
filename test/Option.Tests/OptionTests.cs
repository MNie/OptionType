namespace Option.Tests
{
    using System;
    using Shouldly;
    using Xunit;

    public class OptionTypeTests
    {
        public class WhenOptionHasValue
        {
            private readonly Option<string> _option = Option<string>.Some("walesa");

            [Fact]
            public void IsSome_ReturnTrue() =>
                _option.IsSome.ShouldBeTrue();

            [Fact]
            public void IsNone_ReturnFalse() =>
                _option.IsNone.ShouldBeFalse();

            [Fact]
            public void Value_ReturnWalesa() =>
                _option.Value.ShouldBe("walesa");

            [Fact]
            public void ImplicitOperator_ReturnWalesa()
            {
                string result = _option;
                result.ShouldBe("walesa");
            }

            [Fact]
            public void ImplicitOperatorToOption_ReturnWalesa()
            {
                Option<string> result = "walesa";
                result.Value.ShouldBe("walesa");
            }
        }

        public class WhenOptionHasNotValue
        {
            private readonly Option<string> _option = Option<string>.None;

            [Fact]
            public void IsSome_ReturnFalse() =>
                _option.IsSome.ShouldBeFalse();

            [Fact]
            public void IsNone_ReturnTrue() =>
                _option.IsNone.ShouldBeTrue();

            [Fact]
            public void Value_ThrowsException() =>
                Assert.Throws<InvalidOperationException>(() => _option.Value);

            [Fact]
            public void ImplicitOperator_ThrowsException()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    string result = _option;
                });
            }

            [Fact]
            public void ImplicitOperatorToOption_ReturnIsNone()
            {
                Option<string> result = null;
                result.IsNone.ShouldBeTrue();
            }
        }

        public class WhenOptionHasNotValueAndIsValueType
        {
            private readonly Option<int> _option = Option<int>.None;

            [Fact]
            public void IsSome_ReturnFalse() =>
                _option.IsSome.ShouldBeFalse();

            [Fact]
            public void IsNone_ReturnTrue() =>
                _option.IsNone.ShouldBeTrue();

            [Fact]
            public void Value_ThrowsException() =>
                Assert.Throws<InvalidOperationException>(() => _option.Value);
        }

        public class WhenOptionHasValueAndItIsADefaultValueButTheOptionIsCorrectAndItIsAValueType
        {
            private readonly Option<bool> _option = Option<bool>.Some(false);

            [Fact]
            public void IsSome_ReturnTrue() =>
                _option.IsSome.ShouldBeTrue();

            [Fact]
            public void IsNone_ReturnFalse() =>
                _option.IsNone.ShouldBeFalse();

            [Fact]
            public void Value_ReturnsFalse() =>
                _option.Value.ShouldBeFalse();
        }

        public class WhenWeAreUsingImplicitOperatorForValueType
        {
            [Fact]
            public void ItThrowsAnArgumentException() =>
                Assert.Throws<ArgumentException>(() =>
                {
#pragma warning disable 219
                    Option<bool> option = false;
#pragma warning restore 219
                });
        }

        public class WhenWeAreUsingImplicitOperatorForRefType
        {
            [Fact]
            public void EverythingShouldBeCool()
            {
                Option<string> option = "gg";
                option.Value.ShouldBe("gg");
            }
        }
    }
}
