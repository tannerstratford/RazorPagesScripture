using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesScripture.Models;

    public class RazorPagesScriptureContext : DbContext
    {
        public RazorPagesScriptureContext (DbContextOptions<RazorPagesScriptureContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesScripture.Models.Scripture> Scripture { get; set; }
    }
