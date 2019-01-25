using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livros.Models
{
    public static class ProdutoExtensions
    {

        public static Produto ToProduto(this ProdutoNew model)
        {
            return new Produto
            {
                Id = model.Id,
                Nome = model.Nome,
                Preco = model.Preco,
                Descricao = model.Descricao
            };
        }
    }
}
