﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TreinaWeb.Musicas.Web.Annotations;

namespace TreinaWeb.Musicas.Web.ViewModels.Album
{
    public class AlbumViewModel
    {
        [Required (ErrorMessage = "O ID do álbum é obrigatório")]
        public int Id { get; set; }

        
        [Display(Name = "Nome do album")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "O nome do album poderá ter no máximo 100 caracteres")]
        public string Nome { get; set; }


        [Display(Name = "Ano do album")]
        [Required(ErrorMessage = "O ano do album é obrigatório")]
        public int Ano { get; set; }


        [Display(Name = "Observações")]
        [MaxLength(1000, ErrorMessage = "Você excedeu a quantidade de caracteres para a observação, que é no máximo 1000")]
        public string Observacoes { get; set; }



        [Display(Name = "Email de contato")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "O email é obrigatório")]
        [MaxLength(50, ErrorMessage = "O email do album poderá ter no máximo 50 caracteres")]
        [EmailTreinaWeb(ErrorMessage = "O email tem que ser da TreinaWeb")]
        public string Email { get; set; }
    }
}