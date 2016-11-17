using LsMapasNet.Entidade;
using LsMapasNet.EntidadeConfig;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace LsMapasNet.Contexto
{
    public class LsMapaContext : DbContext
    {
        public LsMapaContext() : base("LsMapaContextconnectionString")
        {
            Database.SetInitializer(new MySqlInitializer());
            //DbConfiguration.SetConfiguration(new MySqlEFConfiguration());


            Database.SetInitializer<LsMapaContext>(new CreateDatabaseIfNotExists<LsMapaContext>());
        }

        public DbSet<Mapas> Mapas { get; set; }
        public DbSet<MapaSurdo> MapaSurdo { get; set; }
        public DbSet<Surdo> Surdo { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());


            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(50));

            try
            {
                modelBuilder.Configurations.Add(new MapasConfig());
                modelBuilder.Configurations.Add(new MapaSurdoConfig());
                modelBuilder.Configurations.Add(new SurdoConfig());
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}