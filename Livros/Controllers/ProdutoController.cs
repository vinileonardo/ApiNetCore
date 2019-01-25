using System.Linq;
using Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Livros.Models;

namespace Controllers
{
    [Route("api/produtos")]
    public class ProdutoController : Controller
    {
        private readonly IRepository<Produto> _repo;

        public ProdutoController(IRepository<Produto> repository)
        {
            _repo = repository;
        }

        [HttpGet("{id}")]
        public IActionResult GetProduto(int id)
        {
            var model = _repo.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            return Json(model);
        }

        [HttpGet]
        public IActionResult GetProdutos()
        {
            var model = _repo.All;
            if (model == null)
            {
                return NotFound();
            }
            return Json(model);
        }

        [HttpPost]
        public IActionResult Incluir([FromBody] ProdutoNew model)
        {
            if (ModelState.IsValid)
            {
                var produto = model.ToProduto();
                _repo.Incluir(produto);
                var uri = Url.Action("GetProduto", new { id = produto.Id });
                return Created(uri, produto); //201
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Editar([FromBody] ProdutoNew model)
        {
            if (ModelState.IsValid)
            {
                var produto = model.ToProduto();
                _repo.Alterar(produto);
                return Ok(); //200
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            var model = _repo.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            _repo.Excluir(model);
            return NoContent(); //204
        }
    }
}