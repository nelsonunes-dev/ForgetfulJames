using ForgetfulJames.Domain.Abstractions;

namespace ForgetfulJames.Domain.Common
{
    public class EntityBase<T> : IEntityBase<T> where T : struct
    {
        public T Id { get; set; }

        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
