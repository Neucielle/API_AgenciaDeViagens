using AgenciaDeViagens.Models;

namespace AgenciaDeViagens.Repositorios.Interfaces
{
    public interface IUserRepositorio
    {
        Task<List<UserModel>> BuscarTodosUsuario();
        Task<UserModel> BuscarPorId(int id);
        Task<UserModel> Adicionar(UserModel user);
        Task<UserModel> Atualizar(UserModel user, int id);
        Task<bool> Deletar(int id);
    }
}
