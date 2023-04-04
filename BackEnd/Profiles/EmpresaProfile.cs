using AutoMapper;
using BackEnd.Model;
using BackEnd.VOS.Entrada.Empresa;
using BackEnd.VOS.Saida.Empresa;
using BackEnd.VOS.Saida.Fornecedor;

namespace BackEnd.Profiles
{
    public class EmpresaProfile : Profile
    {
        public EmpresaProfile() {
            CreateMap<EmpresaVOEntrada, Empresa>()
               .ForPath(dest => dest.CNPJ, opts => opts.MapFrom(x => x.CNPJ))
                   .ForPath(dest => dest.Nome, opts => opts.MapFrom(x => x.Nome))
                       .ForPath(dest => dest.CEP, opts => opts.MapFrom(x => x.CEP))
                            .ForMember(dest => dest.Fornecedores, opts => opts.MapFrom(x => x.Fornecedores));
            CreateMap<Empresa, EmpresaVOSaida>()
                .ForPath(dest => dest.Id, opts => opts.MapFrom(x => x.Id))
                   .ForPath(dest => dest.CNPJ, opts => opts.MapFrom(x => x.CNPJ))
                       .ForPath(dest => dest.Nome, opts => opts.MapFrom(x => x.Nome))
                           .ForPath(dest => dest.CEP, opts => opts.MapFrom(x => x.CEP));
                            
        }
    }
}
