using AutoMapper;
using BackEnd.Model;
using BackEnd.VOS.Entrada.Fornecedor;
using BackEnd.VOS.Entrada.FornecedorEmpresa;
using BackEnd.VOS.Saida.Empresa;
using BackEnd.VOS.Saida.Fornecedor;
using BackEnd.VOS.Saida.FornecedorEmpresa;

namespace BackEnd.Profiles
{
    public class FornecedorEmpresaProfile : Profile
    {
        public FornecedorEmpresaProfile()
        {
            CreateMap<FornecedorEmpresaVOEntrada, FornecedorEmpresa>()
                    .ForPath(dest => dest.FornecedorId, opts => opts.MapFrom(x => x.FornecedorId));
            CreateMap<FornecedorEmpresa, FornecedorEmpresaExit>()
                .ForPath(dest => dest.Id, opts => opts.MapFrom(x => x.FornecedorId))
                    .ForPath(dest => dest.Nome, opts => opts.MapFrom(x => x.Fornecedor.Nome));
            CreateMap<FornecedorEmpresa, EmpresaVOSaida>()
                .ForPath(dest => dest.Id, opts => opts.MapFrom(x => x.Empresa.Id))
                    .ForPath(dest => dest.Nome, opts => opts.MapFrom(x => x.Empresa.Nome))
                    .ForPath(dest => dest.CNPJ, opts => opts.MapFrom(x => x.Empresa.CNPJ))
                    .ForPath(dest => dest.CEP, opts => opts.MapFrom(x => x.Empresa.CEP));
        }
    }
}
