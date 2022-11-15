using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
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
            builder.Services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PIM-VIII", Version = "v1", });
            });

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
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PIM-VIII"));
                app.UseHttpsRedirection();
                app.UseRouting();
                app.UseAuthorization();
                app.UseEndpoints(endpoints => endpoints.MapControllers());
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}