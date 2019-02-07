using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinaWeb.Musicas.Dominio
{
    public class Musica
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public virtual Album Album { get; set; } //Para criar uma relação entre outras tabelas
        public int IdAlbum { get; set; }

    }
}
