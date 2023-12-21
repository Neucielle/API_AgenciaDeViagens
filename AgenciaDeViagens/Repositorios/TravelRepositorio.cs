using AgenciaDeViagens.Data;
using AgenciaDeViagens.Models;
using AgenciaDeViagens.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgenciaDeViagens.Repositorios
{
    public class TravelRepositorio : ITravelRepositorio
    {
        private readonly AgenciaViagensDBContext _dbContext;

        public TravelRepositorio(AgenciaViagensDBContext agenciaViagensDBContext)
        {
            _dbContext = agenciaViagensDBContext;
        }


        public async Task<TravelModel> BuscarPorId(int id)
        {
            return await _dbContext.Travels
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<TravelModel>> BuscarDestinos()
        {
            return await _dbContext.Travels
                .Include (x => x.User)
                .ToListAsync();
        }
        public async Task<TravelModel> AdicionarDestino(TravelModel travel)
        {
            await _dbContext.Travels.AddAsync(travel);
            await _dbContext.SaveChangesAsync();
            return travel;
        }

        public async Task<TravelModel> Atualizar(TravelModel travel, int id)
        {
            TravelModel destinoPorId = await BuscarPorId(id);

            if (destinoPorId == null)
            {
                throw new Exception($" Destino de ID: {id} não foi encontrado no banco de dados!");
            }
            destinoPorId.Destino = travel.Destino;
            destinoPorId.Status = travel.Status;
            destinoPorId.UserId = travel.UserId;

            _dbContext.Travels.Update(destinoPorId);
            await _dbContext.SaveChangesAsync();

            return destinoPorId;


        }

        public async Task<bool> Deletar(int id)
        {
            TravelModel destinoPorId = await BuscarPorId(id);

            if (destinoPorId == null)
            {
                throw new Exception($" Destino de ID: {id} não foi encontrado no banco de dados!");
            }

            _dbContext.Travels.Remove(destinoPorId);
            await _dbContext.SaveChangesAsync();
            return true;



        }

       
    }
}
