using ForgetfulJames.Domain.Entities;
using ForgetfulJames.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForgetfulJames.Infrastructure.Configurations
{
    public class ToDoConfiguration : ConfigurationBase<ToDo, Guid>
    {
        public override void Configure(EntityTypeBuilder<ToDo> builder)
        {
            base.Configure(builder);

            builder.ToTable("ToDo");

            builder.Property(x => x.DueDate)
                .HasDefaultValue(DateTime.MinValue)
                .IsRequired(true);

            builder.Property(x => x.Image)
                .HasColumnType("image")
                .IsRequired(false);

            builder.Property(x => x.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Starred)
                .HasColumnType("tinyint")
                .IsRequired(true);
        }
    }
}
