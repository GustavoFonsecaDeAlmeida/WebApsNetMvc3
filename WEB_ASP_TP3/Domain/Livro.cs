using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_ASP_TP3.Domain
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public int Ano { get; set; }
        public string Anotacao { get; set; }
    }
}