using AutoMapper;
using Ds.App.ViewModels;
using Ds.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ds.Api.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Pessoa, PessoaViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<NotaViewModel, Nota>().ReverseMap();
            CreateMap<Aluno, AlunoViewModel>().ReverseMap();
            CreateMap<Disciplina, DisciplinaViewModel>().ReverseMap();
            CreateMap<Periodo, PeriodoViewModel>().ReverseMap();
            CreateMap<Nota, NotaViewModel>()
              .ForMember(dest => dest.NomeAluno, opt => opt.MapFrom(src => src.Aluno.NomeCompleto))
              .ForMember(dest => dest.NomeDisciplina, opt => opt.MapFrom(src => src.Disciplina.NomeDisciplina))
              .ForMember(dest => dest.NomePeriodo, opt => opt.MapFrom(src => src.Periodo.NomePeriodo));

        }
    }
}
