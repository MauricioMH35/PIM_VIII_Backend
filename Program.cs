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