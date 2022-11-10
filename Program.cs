using Microsoft.EntityFrameworkCore;
using PIM_VIII.Datas;
using PIM_VIII.Repositories;
using PIM_VIII.Repositories.Interfaces;

namespace PIM_VIII {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Realizando a configuração da string de conexão com o banco de dados
            builder.Services.AddDbContext<BancoDadosContext>(opt => {
                string connectionDbStr = builder.Configuration.GetConnectionString("Database");
                opt.UseMySql(
                    connectionDbStr,
                    ServerVersion.AutoDetect(connectionDbStr)
                );
            });

            // Injeção de dependência do repositorio de pessoa
            builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();

            // Injeção de dependência do repositorio de endereco
            builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();

            // Injeção de dependência do repositorio de telefone
            builder.Services.AddScoped<ITelefoneRepository, TelefoneRepository>();

            // Injeção de dependência do repositorio de tipo telefone
            builder.Services.AddScoped<ITipoTelefoneRepository, TipoTelefoneRepository>();

            // Injeção de dependência do repositorio de tipo via cep
            builder.Services.AddScoped<IViaCepRepository, ViaCepRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}