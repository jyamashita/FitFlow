using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace FitFlow.Models
{
    public class FitFlowContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Belong> Belongs { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public FitFlowContext() : base("FitFlowConnection") { }
    }
}
