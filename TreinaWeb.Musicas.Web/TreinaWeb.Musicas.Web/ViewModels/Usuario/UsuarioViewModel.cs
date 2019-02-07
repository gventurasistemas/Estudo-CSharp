using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreinaWeb.Musicas.Web.ViewModels.Usuario
{
    public class UsuarioViewModel
    {
       
        [Required(ErrorMessage = "O email é obrigatório")]
        [MaxLength(30, ErrorMessage = "O email não pode ter mais que 30 caracteres")]
        public string Email { get; set; }



        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

    }
}