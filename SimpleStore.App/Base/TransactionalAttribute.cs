namespace SimpleStore.App.Base;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true)]
public class TransactionalAttribute : Attribute
{
}
