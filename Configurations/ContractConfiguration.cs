using DappSniper.Net.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DappSniper.Net.Configurations
{
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.Property(contract => contract.Address)
                .HasColumnType("varchar(42)");

            builder.HasKey(contract => contract.Address);

            builder.HasOne(contract => contract.Dapp)
                .WithMany(dapp => dapp.Contracts)
                .HasForeignKey(dapp => dapp.DappId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
