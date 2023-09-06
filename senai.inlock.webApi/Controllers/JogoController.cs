using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repository;

namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private IJogoRepository _jogoRepository { get; set; }

        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Cria uma lista para receber os gêneros.
                List<JogoDomain> listaJogos = _jogoRepository.ListarTodos();

                // Retorna o Status Code 200 - Ok e a lista de gêneros no formato JSON.
                return Ok(listaJogos);
                // Ok = StatusCode(200).
            }
            catch (Exception erro)
            {
                // Retorna um Status Code 400 - BadRequest e a mensagem de erro. 
                return BadRequest(erro.Message);
            }

        }


        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {
            try
            {
                _jogoRepository.Cadastrar(novoJogo);

                // 201 - Created.
                return Created("Objeto criado!", novoJogo);
            }
            catch (Exception erro)
            {
                // Retorna um Status Code 400 - BadRequest e a mensagem de erro.
                return BadRequest(erro.Message);
            }

        }
    }

}

