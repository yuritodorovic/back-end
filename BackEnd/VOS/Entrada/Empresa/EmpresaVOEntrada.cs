using BackEnd.VOS.Entrada.Fornecedor;
using BackEnd.VOS.Entrada.FornecedorEmpresa;

namespace BackEnd.VOS.Entrada.Empresa
{
    public class EmpresaVOEntrada
    {
        public string CNPJ { get; set; }
        public string Nome { get; set; }
        public string CEP { get; set; }
        public ICollection<FornecedorEmpresaVOEntrada>? Fornecedores { get; set; }
        
    }
}
