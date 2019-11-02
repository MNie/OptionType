namespace Option.Tests
{
    using Shouldly;
    using Xunit;

    public class ExtensionTests
    {
        [Fact]
        public void Some_PredicateIsTrue_ReturnSome()
        {
            var result = "dd".Some(x => !string.IsNullOrWhiteSpace(x));
            
            result.IsSome.ShouldBeTrue();
        }
        
        [Fact]
        public void Some_PredicateIsFalse_ReturnNone()
        {
            var result = "dd".Some(string.IsNullOrWhiteSpace);
            
            result.IsNone.ShouldBeTrue();
        }

        [Fact]
        public void Some_ForValue_ReturnSome()
        {
            var result = "dd".Some();
            
            result.IsSome.ShouldBeTrue();
        }
        
        [Fact]
        public void None_PredicateIsTrue_ReturnNone()
        {
            var result = "dd".None(x => !string.IsNullOrWhiteSpace(x));
            
            result.IsNone.ShouldBeTrue();
        }
        
        [Fact]
        public void None_PredicateIsFalse_ReturnSome()
        {
            var result = "dd".None(string.IsNullOrWhiteSpace);
            
            result.IsSome.ShouldBeTrue();
        }
    }
}