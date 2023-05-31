using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using ForgetfulJames.Domain.Common;

namespace ForgetfulJames.Infrastructure.Common
{
    public abstract class ConfigurationBase<TEntity, T> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase<T> where T : struct
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            switch (typeof(T))
            {
                case var value when value == typeof(Guid):
                    builder.Property(x => x.Id)
                        .HasDefaultValueSql("NEWID()")
                        .HasValueGenerator<GuidValueGenerator>()
                        .IsRequired()
                        .ValueGeneratedOnAdd();
                    break;
                case var value when value == typeof(int):
                    builder.Property(x => x.Id)
                        .HasDefaultValueSql("NEWID()")
                        .UseIdentityColumn(1, 1)
                        .IsRequired()
                        .ValueGeneratedOnAdd();
                    break;
                default:
                    throw new NotImplementedException($"The type '{typeof(T).Name}' isn't implemented. Only {typeof(Guid).Name} or {typeof(int).Name} is allowed.");
            }

            builder.Property(x => x.Created)
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            builder.Property(x => x.LastModified)
                .HasDefaultValue(DateTime.MinValue)
                .IsRequired(false);
        }
    }
}
