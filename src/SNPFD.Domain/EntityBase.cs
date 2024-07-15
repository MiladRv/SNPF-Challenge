namespace SNPFD.Domain;

public abstract class EntityBase<T> where T : struct
{
    public T Id { get; protected set; }
}
