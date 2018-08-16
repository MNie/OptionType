namespace Option.Tests
{
    using System;
    using Shouldly;
    using Xunit;

    public class OptionTests
    {
        public class WhenOptionHasValue
        {
            private Option<string> _option = Option<string>.Some("walesa");

            [Fact]
            public void IsSome_ReturnTrue() =>
                _option.IsSome.ShouldBeTrue();

            [Fact]
            public void IsNone_ReturnFalse() =>
                _option.IsNone.ShouldBeFalse();

            [Fact]
            public void Value_ReturnWalesa() =>
                _option.Value.ShouldBe("walesa");
        }

        public class WhenOptionHasNotValue
        {
            private Option<string> _option = Option<string>.None;

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
    }
}
