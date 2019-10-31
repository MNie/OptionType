namespace Option
{
    public interface IOption
    {
        bool IsSome { get; }
        bool IsNone { get; }
    }
    
    public interface IOption<T> : IOption
    {
        T Value { get; }
    }
}