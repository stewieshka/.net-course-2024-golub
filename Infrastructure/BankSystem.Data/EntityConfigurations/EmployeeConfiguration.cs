using BankSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankSystem.Data.EntityConfigurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("employees");
        
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("id");

        builder.Property(e => e.FirstName)
            .HasColumnName("first_name");

        builder.Property(e => e.LastName)
            .HasColumnName("last_name");
        
        builder.Property(e => e.PassportId)
            .HasColumnName("passport_id");
        
        builder.Property(e => e.Contract)
            .HasColumnName("contract");

        builder.Property(e => e.BirthDay)
            .HasColumnName("birth_day");
        
        builder.Property(e => e.PhoneNumber)
            .HasColumnName("phone_number");
        
        builder.Property(e => e.Salary)
            .HasColumnName("salary");
        
        builder.Property(e => e.MiddleName)
            .HasColumnName("middle_name");
    }
}