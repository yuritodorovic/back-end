namespace BackEnd.Model
{
    public class FornecedorEmpresa
    {
        public Guid Id { get; set; }
        public Guid FornecedorId { get; set; }
        public Guid EmpresaId { get; set; }
        public Fornecedor? Fornecedor { get; set; }
        public Empresa? Empresa { get; set; }
    }
}
