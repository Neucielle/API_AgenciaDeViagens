using AgenciaDeViagens.Data;
using AgenciaDeViagens.Repositorios;
using AgenciaDeViagens.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgenciaDeViagens
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkSqlServer()
            .AddDbContext<AgenciaViagensDBContext>(
               Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
               
             );

            builder.Services.AddScoped<IUserRepositorio, UserRepositorio>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private static void AddDbContext<T>(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}
