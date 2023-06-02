using ForgetfulJames.Domain.Enums;

namespace ForgetfulJames.Dto.Entities
{
    public class ToDoDto
    {
        public DateTime DueDate { get; set; }
        public byte[] Image { get; set; } = Array.Empty<byte>();
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public ToDoImportance Starred { get; set; } = ToDoImportance.Normal;
        public string UserId { get; set; } = string.Empty;
    }
}
