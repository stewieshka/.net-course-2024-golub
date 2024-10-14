using BankSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankSystem.Data.EntityConfigurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("clients");
        
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("id");

        builder.Property(c => c.FirstName)
            .HasColumnName("first_name");

        builder.Property(c => c.LastName)
            .HasColumnName("last_name");
        
        builder.Property(c => c.PassportId)
            .HasColumnName("passport_id");
        
        builder.Property(c => c.BirthDay)
            .HasColumnName("birth_day");
        
        builder.Property(c => c.PhoneNumber)
            .HasColumnName("phone_number");
        
        builder.Property(c => c.MiddleName)
            .HasColumnName("middle_name");
        
        builder.HasMany(x => x.Accounts)
            .WithOne(x => x.Client)
            .HasForeignKey(x => x.ClientId);
    }
}