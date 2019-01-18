using DappSniper.Net.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DappSniper.Net.Configurations
{
    public class RankConfiguration : IEntityTypeConfiguration<Rank>
    {
        public void Configure(EntityTypeBuilder<Rank> builder)
        {
            builder.Property(rank => rank.Id)
                .HasColumnType("char(36)");

            builder
                .HasOne(rank => rank.Record)
                .WithMany(record => record.Ranks)
                .HasForeignKey(rank => rank.RecordId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(rank => rank.Dapp)
                .WithMany(dapp => dapp.Ranks)
                .HasForeignKey(rank => rank.DappId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
