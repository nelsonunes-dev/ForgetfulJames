using ForgetfulJames.Domain.Common;
using ForgetfulJames.Domain.Enums;

namespace ForgetfulJames.Domain.Entities
{
    public class ToDo : EntityBase<Guid>
    {
        public DateTime DueDate { get; set; }
        public byte[] Image { get; set; } = Array.Empty<byte>();
        public string Name { get; set; } = string.Empty;
        public ToDoImportance Starred { get; set; } = ToDoImportance.Normal;
        public string UserId { get; set; } = string.Empty;
    }
}
