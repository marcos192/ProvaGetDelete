using PosGe.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PosGe.Context
    {
    public class EFContext : DbContext
        {

        public EFContext() : base("PROJETO") { }

        public DbSet<Fornecedor> forenecedor { get; set; }
        public DbSet<Produto> produtos { get; set; }
        }
    }