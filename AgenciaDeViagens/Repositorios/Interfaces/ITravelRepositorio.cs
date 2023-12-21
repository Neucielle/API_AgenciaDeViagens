using AgenciaDeViagens.Models;

namespace AgenciaDeViagens.Repositorios.Interfaces
{
    public interface ITravelRepositorio
    {
        Task<List<TravelModel>> BuscarDestinos();
        Task<TravelModel> BuscarPorId(int  id);
        Task<TravelModel> AdicionarDestino(TravelModel travel);
        Task<TravelModel> Atualizar(TravelModel travel, int id);
        Task<bool> Deletar(int id);

    }
}
