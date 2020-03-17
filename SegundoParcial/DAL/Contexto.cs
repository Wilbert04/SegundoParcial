using Microsoft.EntityFrameworkCore;
using SegundoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SegundoParcial.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Llamada> llamadaTable1 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@" DataSource = SegundoParcialDB1.db");
        }
    }
}
