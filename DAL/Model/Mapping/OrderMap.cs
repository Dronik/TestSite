using System.Data.Entity.ModelConfiguration;

namespace Test.Model.Model.Mapping
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Date).IsRequired();

            // Table & Column Mappings
            this.ToTable("Order");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Date).HasColumnName("Date");

            // Relationships
            this.HasMany(t => t.Products)
                .WithMany(t => t.Orders)
                .Map(m =>
                {
                    m.MapLeftKey("OrderId");
                    m.MapRightKey("ProductId");
                    m.ToTable("OrderProducts");
                });
        }
    }
}
