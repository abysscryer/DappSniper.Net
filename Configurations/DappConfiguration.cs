using DappSniper.Net.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DappSniper.Net.Configurations
{
    public class DappConfiguration : IEntityTypeConfiguration<Dapp>
    {
        public void Configure(EntityTypeBuilder<Dapp> builder)
        {
            builder
                .Property(dapp => dapp.Id)
                .HasColumnType("char(36)");

            builder
                .Property(dapp => dapp.Name)
                .HasColumnType("varchar(32)");

            builder
                .Property(dapp => dapp.LogoPath)
                .HasColumnType("varchar(64)");

            builder
                .Property(dapp => dapp.Description)
                .HasColumnType("nvarchar(512)");

            builder
                .Property(dapp => dapp.Category)
                .HasConversion(category => category.Value, category => Category.FromValue(category));

            builder
                .Property(dapp => dapp.Protocol)
                .HasConversion(protocol => protocol.Value, protocol => Protocol.FromValue(protocol));
        }
    }
}
