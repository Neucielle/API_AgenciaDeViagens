using AgenciaDeViagens.Models;
using AgenciaDeViagens.Repositorios;
using AgenciaDeViagens.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgenciaDeViagens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController : ControllerBase
    {
        private readonly ITravelRepositorio _travelRepositorio;

        public TravelController(ITravelRepositorio travelRepositorio)
        {
            _travelRepositorio = travelRepositorio;
        }


        [HttpGet]
        public async Task<ActionResult<List<TravelModel>>> ListarDestinos()
        {
            List<TravelModel> travels = await _travelRepositorio.BuscarDestinos();
            return Ok(travels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TravelModel>> BuscarPorId(int id)
        {
            TravelModel travel = await _travelRepositorio.BuscarPorId(id);
            return Ok(travel);
        }

        [HttpPost]
        public async Task<ActionResult<TravelModel>> Cadastrar([FromBody] TravelModel travelModel)
        {
            TravelModel travel = await _travelRepositorio.AdicionarDestino(travelModel);

            return Ok(travel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TravelModel>> Atualizar([FromBody] TravelModel travelModel, int id)
        {
            travelModel.Id = id;
            TravelModel travel = await _travelRepositorio.Atualizar(travelModel, id);

            return Ok(travel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TravelModel>> Deletar(int id)
        {

            bool deletado = await _travelRepositorio.Deletar(id);

            return Ok(deletado);
        }

    }
}