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

            // Realizando a configura��o da string de conex�o com o banco de dados
            builder.Services.AddDbContext<BancoDadosContext>(opt => {
                string connectionDbStr = builder.Configuration.GetConnectionString("Database");
                opt.UseMySql(
                    connectionDbStr,
                    ServerVersion.AutoDetect(connectionDbStr)
                );
            });

            // Inje��o de depend�ncia do repositorio de pessoa
            builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();

            // Inje��o de depend�ncia do repositorio de endereco
            builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();

            // Inje��o de depend�ncia do repositorio de telefone
            builder.Services.AddScoped<ITelefoneRepository, TelefoneRepository>();

            // Inje��o de depend�ncia do repositorio de tipo telefone
            builder.Services.AddScoped<ITipoTelefoneRepository, TipoTelefoneRepository>();

            // Inje��o de depend�ncia do repositorio de tipo via cep
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