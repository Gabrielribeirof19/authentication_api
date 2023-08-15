using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Authentication.models;

namespace Authentication.data.mapping
{
    public class linkMapping : IEntityTypeConfiguration<Links>
    {
        public void Configure(EntityTypeBuilder<Links> builder)
        {
            builder.ToTable("Links");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.url)
                .IsRequired()
                .HasColumnName("url")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.urlShorted)
                .IsRequired()
                .HasColumnName("urlShorted")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.createdAt)
                .HasColumnName("createdAt")
                .HasColumnType("DATETIME");

            builder.Property(x => x.experationDate)
                .HasColumnName("experationDate")
                .HasColumnType("DATETIME");


        }
    }
}