using System.Data.Entity.ModelConfiguration;

namespace Test.Model.Model.Mapping
{
    public class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.FirstName).HasMaxLength(256);
            this.Property(t => t.LastName).HasMaxLength(128);
            this.Property(t => t.Age).IsRequired();

            // Table & Column Mappings
            this.ToTable("Person");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Age).HasColumnName("Age");

            // Relationships
            this.HasOptional(t => t.HomeAddress);
            this.HasOptional(t => t.BusinessAddress);

        }
    }
}
