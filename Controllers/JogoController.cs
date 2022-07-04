using JogoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace JogoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JogoController : ControllerBase
    {
        private List<Jogo> _jogos = new List<Jogo>()
        {
            new Jogo(){Codigo = 1, Nome = "Fifa", Descricao = "legalPakas", Console = "PlayStation5", Genero = "futebol"},
            new Jogo(){Codigo = 2, Nome = "Fifa", Descricao = "legalPakas", Console = "Xbox", Genero = "futebol"},
            new Jogo(){Codigo = 3, Nome = "Fifa", Descricao = "legalPakas", Console = "Nintendo", Genero = "futebol"},
            new Jogo(){Codigo = 4, Nome = "MortalKombat", Descricao = "legalPakas", Console = "PlayStation5", Genero = "Luta"},
            new Jogo(){Codigo = 5, Nome = "Ufc", Descricao = "legalPakas", Console = "Nintendo", Genero = "Luta"}
        };

        [HttpPost]
        public void Cadastrar(Jogo jogo)
        {
            _jogos.Add(jogo);
        }

        [HttpDelete("{codigo}")]
        public void Excluir(int codigo)
        {
            var jogoPorCodigo = _jogos.FirstOrDefault(_ => _.Codigo == codigo);
            _jogos.Remove(jogoPorCodigo);
        }

        [HttpPut]
        public void Alterar(Jogo jogo)
        {
            var jogoPorCodigo = _jogos.FirstOrDefault(_ => _.Codigo == jogo.Codigo);
            jogoPorCodigo.Nome = jogo.Nome;
            jogoPorCodigo.Descricao = jogo.Descricao;
            jogoPorCodigo.Console = jogo.Console;
            jogoPorCodigo.Genero = jogo.Genero;
        }

        [HttpGet]
        public List<Jogo> ListarTodos()
        {
            return _jogos;
        }

        [HttpGet("ListarPorNome/{nome}")]
        public List<Jogo> ListarPorNome(string nome)
        {
            return _jogos.Where(_ => _.Nome == nome).ToList();
        }

        [HttpGet("ListarPorGenero/{genero}")]
        public List<Jogo> ListarPorGenero(string genero)
        {
            return _jogos.Where(_ => _.Genero == genero).ToList();
        }

        [HttpGet("ListarPorConsole/{console}")]
        public List<Jogo> ListarPorConsole(string console)
        {
            return _jogos.Where(_ => _.Console == console).ToList();
        }
    }
}