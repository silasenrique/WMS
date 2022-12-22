using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Domain.Common.ValueObjects;
using WMS.Domain.DistributionCenter;
using WMS.Domain.DistributionCenter.ValueObjects;

namespace WMS.Persistence.DistributionCenterPersistence;

public class DistributionCenterMapping : IEntityTypeConfiguration<DistributionCenter>
{
    public void Configure(EntityTypeBuilder<DistributionCenter> builder)
    {
        builder.HasKey(cd => cd.Id);

        builder.Property(cd => cd.Id)
            .HasConversion(
                c => c.Value,
                c => DistributionCenterId.ParseId(c));

        builder.Property(cd => cd.Document)
            .HasConversion(
                d => d.Value,
                d => LegalDocument.Create(d).Value).HasMaxLength(14);

        builder.Property(cd => cd.InternalCode).HasMaxLength(6).IsRequired();
        builder.Property(cd => cd.Name).HasMaxLength(100);
        builder.Property(cd => cd.DateCreated);
        builder.Property(cd => cd.DateUpdated);

        builder.HasIndex(cd => new { cd.InternalCode }).IsUnique();
        builder.HasIndex(cd => new { cd.Document }).IsUnique();
        builder.HasIndex(cd => new { cd.InternalCode, cd.Document }).IsUnique();
    }
}