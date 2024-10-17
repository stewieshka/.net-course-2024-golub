using BankSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankSystem.Data.EntityConfigurations;

public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.ToTable("currencies");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.Code)
            .HasColumnName("code")
            .HasColumnType("varchar(3)");

        builder.Property(x => x.Name)
            .HasColumnName("name");

        builder.HasMany(x => x.Accounts)
            .WithOne(x => x.Currency);
    }
}