using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Preco { get; set; }
        public string Descricao { get; set; }
    }

    public class ProdutoNew
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Preco { get; set; }
        public string Descricao { get; set; }
    }    
}
