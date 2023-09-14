using Microsoft.EntityFrameworkCore;
using Stroigaz_info_clients.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stroigaz_info_clients.DB
{
    class Offline_DataBase : DbContext
    {
        public  DbSet<Information> Information_DB { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Info.db");
        }
    }
}
