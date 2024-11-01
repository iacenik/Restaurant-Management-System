using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) 
        {
        }
        public DbSet<Masalar>Masalars { get; set; }
        public DbSet<Personeller> Personellers { get; set;}
        public DbSet<Siparisler> Siparisers { get; set;}
        public DbSet<Servisler> Servisers { get; set;}
        public DbSet <Adisyon> Adisyons { get; set; }
        public DbSet<Kategoriler> Kategorilers { get; set;}
        public DbSet<Roller> Rollers { get; set; }
    }
}
