using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinaWeb.Musicas.AcessoDados.Entity.Context;
using TreinaWeb.Musicas.Dominio;
using TreinaWeb.Repositorios.Comum.Entity;
using System.Data.Entity;

namespace TreinaWeb.Musicas.Repositorios.Entity
{
    public class AlbumsRepositorio : RepositorioGenericoEntity<Album, int>
    {
        public AlbumsRepositorio(MusicasDbContext contexto)
            : base ( contexto)
        {

        }

        public override List<Album> Selecionar()
        {
            return _contexto.Set<Album>().Include(p => p.Musicas).ToList();
        }

        public override Album SelecionarPorId(int id)
        {
            return _contexto.Set<Album>().Include(p => p.Musicas).SingleOrDefault(m => m.Id == id);
        }


    }
}
