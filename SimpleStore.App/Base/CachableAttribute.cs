namespace SimpleStore.App.Base;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true)]
public class CachableAttribute : Attribute
{
    public int DurationInMinutes { get; }
    public CachableAttribute(int durationInMinutes)
    {
        DurationInMinutes = durationInMinutes;
    }
}
