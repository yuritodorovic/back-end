using AutoMapper;
using BackEnd.Model;
using BackEnd.VOS.Entrada.Fornecedor;
using BackEnd.VOS.Saida.Fornecedor;

namespace BackEnd.Profiles
{
    public class FonecedorProfile : Profile
    {
        public FonecedorProfile() {
            CreateMap<Fornecedor, FornecedorVOSaida>()
                .ForPath(dest => dest.Id, opts => opts.MapFrom(x => x.Id))
                    .ForPath(dest => dest.CNPJ, opts => opts.MapFrom(x => x.CNPJ))
                        .ForPath(dest => dest.Nome, opts => opts.MapFrom(x => x.Nome))
                            .ForPath(dest => dest.Email, opts => opts.MapFrom(x => x.Email))
                                .ForPath(dest => dest.CEP, opts => opts.MapFrom(x => x.CEP));
            CreateMap<FornecedorVOEntrada, Fornecedor>()
                    .ForPath(dest => dest.CNPJ, opts => opts.MapFrom(x => x.CNPJ))
                        .ForPath(dest => dest.Nome, opts => opts.MapFrom(x => x.Nome))
                            .ForPath(dest => dest.Email, opts => opts.MapFrom(x => x.Email))
                                .ForPath(dest => dest.CEP, opts => opts.MapFrom(x => x.CEP));
        }
    }
}
