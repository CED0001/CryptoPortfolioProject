#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CryptoPortfolio.Models;

namespace CryptoPortfolio.Data
{
    public class CryptoPortfolioContext : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext
    {
        public CryptoPortfolioContext (DbContextOptions<CryptoPortfolioContext> options)
            : base(options)
        {

        }

        public DbSet<CryptoPortfolio.Models.Transaction> Transaction { get; set; }

        public DbSet<CryptoPortfolio.Models.CoinGeckoCoin> CoinGeckoCoin { get; set; }
    }
}
