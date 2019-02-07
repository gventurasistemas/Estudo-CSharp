using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreinaWeb.Musicas.Web.ViewModels.Musicas
{
    public class MusicaViewModel
    {

        [Required(ErrorMessage = "O ID  é obrigatório")]
        public int Id { get; set; }


       
        [Required(ErrorMessage = "O nome da música é obrigatório")]
        [MaxLength(50, ErrorMessage = "O nome da música poderá ter no máximo 50 caracteres")]
        [Display(Name = "Nome da música")]
        public string Nome { get; set; }


      
        [Required(ErrorMessage = "Selecione um album válido")]
        [Display(Name = "Album")]
        public int IdAlbum { get; set; }


    }
}