using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEB_ASP_TP3.Models
{
    public class LivroViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Coloque o Titulo")]
        [StringLength(50, ErrorMessage = "Você só pode adicionar até 50 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Coloque o Autor")]
        [StringLength(50, ErrorMessage = "Você só pode adicionar até 50 caracteres")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "Coloque a Editora")]
        [StringLength(50, ErrorMessage = "Você só pode adicionar até 50 caracteres")]
        public string Editora { get; set; }

        [Required(ErrorMessage = "Coloque o Ano")]
        [RegularExpression("[0-9]{4}", ErrorMessage ="O ano só pode conter 4 caracteres")]
        public int Ano { get; set; }

        //[Required(ErrorMessage = "Coloque a Anotação")]
        [StringLength(100, ErrorMessage = "Você só pode adicionar até 100 caracteres")]
        public string Anotacao { get; set; }
    }
}