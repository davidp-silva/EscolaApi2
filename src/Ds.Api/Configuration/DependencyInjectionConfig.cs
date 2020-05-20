using Ds.Business.Interfaces;
using Ds.Business.Notificacoes;
using Ds.Business.Services;
using Ds.Data.Context;
using Ds.Data.Repository;
using Microsoft.Extensions.DependencyInjection;


namespace Ds.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<EscolaContext>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<INotaRepository, NotaRepository>();
            services.AddScoped<IPeriodoRepository,PeriodoRepository>();
            services.AddScoped<IPessoaRepository,PessoaRepository>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<IDisciplinaService, DisciplinaService>();
            services.AddScoped<IPeriodoService, PeriodoService>();
            services.AddScoped<INotaService, NotaService>();

            return services;
        }
    }
}