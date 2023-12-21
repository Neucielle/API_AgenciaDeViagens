using AgenciaDeViagens.Data;
using AgenciaDeViagens.Models;
using AgenciaDeViagens.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgenciaDeViagens.Repositorios
{
    public class UserRepositorio : IUserRepositorio
    {
        private readonly AgenciaViagensDBContext _dbContext;

        public UserRepositorio(AgenciaViagensDBContext agenciaViagensDBContext) 
        {
            _dbContext = agenciaViagensDBContext;
        }


        public async Task<UserModel> BuscarPorId(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<UserModel>> BuscarTodosUsuario()
        {
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<UserModel> Adicionar(UserModel user)
        {
           await _dbContext.Users.AddAsync(user);
           await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> Atualizar(UserModel user, int id)
        {
            UserModel userPorId = await BuscarPorId(id);

            if(userPorId == null)
            {
                throw new Exception($" Usuário de ID: {id} não foi encontrado no banco de dados!");
            }
            userPorId.Name = user.Name;
            userPorId.Email = user.Email;

            _dbContext.Users.Update(userPorId);
           await _dbContext.SaveChangesAsync();

            return userPorId;


        }

        public async Task<bool> Deletar(int id)
        {
            UserModel userPorId = await BuscarPorId(id);

            if (userPorId == null)
            {
                throw new Exception($" Usuário de ID: {id} não foi encontrado no banco de dados!");
            }

            _dbContext.Users.Remove(userPorId);
            await _dbContext.SaveChangesAsync();
            return true;



        }
    }
}
