using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinaWeb.Musicas.AcessoDados.Entity.TypeConfiguration;
using TreinaWeb.Musicas.Dominio;

namespace TreinaWeb.Musicas.AcessoDados.Entity.Context
{
    public class MusicasDbContext : DbContext
    {
       // public DbSet<Album> Albuns { get; set; }

        public MusicasDbContext()
        {
            //O objetivo do Lazy Load fazer com que sua aplicação utilize menos memória e seja mais 
            //eficiente pela redução da quantidade de dados transferidos de/para o banco de dados.
            //Porém deixa a aplicação extremamente lenta, então deve ser desabilitado
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlgumTypeConfiguration());
            modelBuilder.Configurations.Add(new MusicaTypeConfiguration());
        }

        public System.Data.Entity.DbSet<TreinaWeb.Musicas.Dominio.Album> Albuns { get; set; }              
        public System.Data.Entity.DbSet<TreinaWeb.Musicas.Dominio.Musica> Musicas { get; set; }

    }
}
