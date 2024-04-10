using Microsoft.EntityFrameworkCore;
using SummaryBooks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryBooks.Persistence
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) 
        : base(options) 
        {
        }
       
        public DbSet<Summary> Summaries { get; set; }
    }
}
