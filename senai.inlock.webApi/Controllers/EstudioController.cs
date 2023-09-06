using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repository;

namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }


        [HttpGet]       
        public IActionResult Get()
        {
            try
            {
                // Cria uma lista para receber os gêneros.
                List<EstudioDomain> listaEstudios = _estudioRepository.ListarTodos();

                // Retorna o Status Code 200 - Ok e a lista de gêneros no formato JSON.
                return Ok(listaEstudios);
                // Ok = StatusCode(200).
            }
            catch (Exception erro)
            {
                // Retorna um Status Code 400 - BadRequest e a mensagem de erro. 
                return BadRequest(erro.Message);
            }


        }


        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            try
            {
                _estudioRepository.Cadastrar(novoEstudio);

                // 201 - Created.
                return Created("Objeto criado!", novoEstudio);
            }
            catch (Exception erro)
            {
                // Retorna um Status Code 400 - BadRequest e a mensagem de erro.
                return BadRequest(erro.Message);
            }

        }
    }
}
