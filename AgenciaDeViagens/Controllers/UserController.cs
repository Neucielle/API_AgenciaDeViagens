using AgenciaDeViagens.Models;
using AgenciaDeViagens.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgenciaDeViagens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepositorio _userRepositorio;

        public UserController(IUserRepositorio userRepositorio)
        {
            _userRepositorio = userRepositorio;
        }


        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> BuscarTodosUsuario()
        {
            List<UserModel> users = await _userRepositorio.BuscarTodosUsuario();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> BuscarPorId(int id)
        {
            UserModel user = await _userRepositorio.BuscarPorId(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Cadastrar([FromBody] UserModel userModel)
        {
            UserModel user = await _userRepositorio.Adicionar(userModel);

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Atualizar([FromBody] UserModel userModel, int id)
        {
            userModel.Id = id;
            UserModel user = await _userRepositorio.Atualizar(userModel, id);

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> Deletar(int id)
        {
         
            bool deletado = await _userRepositorio.Deletar(id);

            return Ok(deletado);
        }

    }
}
