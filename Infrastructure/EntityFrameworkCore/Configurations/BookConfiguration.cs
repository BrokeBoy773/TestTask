using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFrameworkCore.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);

            builder.ComplexProperty(b => b.Title, t =>
            {
                t.IsRequired();

                t.Property(title => title.Title)
                    .IsRequired()
                    .HasColumnName("Title")
                    .HasMaxLength(128);
            });
        }
    }
}
