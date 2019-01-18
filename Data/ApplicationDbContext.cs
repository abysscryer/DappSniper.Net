using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DappSniper.Net.Models;
using DappSniper.Net.Configurations;

namespace DappSniper.Net.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Record> Records { get; set; }

        public DbSet<Rank> Ranks { get; set; }

        public DbSet<Dapp> Dapps { get; set; }

        public DbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RecordConfiguration());
            builder.ApplyConfiguration(new RankConfiguration());
            builder.ApplyConfiguration(new DappConfiguration());
            builder.ApplyConfiguration(new ContractConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<DappSniper.Net.Models.RecordViewModel> RecordViewModel { get; set; }

        public DbSet<DappSniper.Net.Models.RecordCreateModel> RecordCreateModel { get; set; }

        public DbSet<DappSniper.Net.Models.RankViewModel> RankViewModel { get; set; }
    }
}
