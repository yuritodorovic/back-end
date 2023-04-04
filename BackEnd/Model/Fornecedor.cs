namespace BackEnd.Model
{
    public class Fornecedor
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public ICollection<FornecedorEmpresa>? Empresas { get; set; }
    }
}
