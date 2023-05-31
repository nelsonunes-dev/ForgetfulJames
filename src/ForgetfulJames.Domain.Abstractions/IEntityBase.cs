namespace ForgetfulJames.Domain.Abstractions
{
    /// <summary>
    /// Defines a generic base for domain entities.
    /// </summary>
    /// <typeparam name="T">Defines the type.</typeparam>
    public interface IEntityBase<T> where T : struct
    {
        T Id { get; set; }
    }
}
