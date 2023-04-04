namespace BackEnd.Model
{
    public class Empresa
    {
        public Guid Id { get; set; }
        public string CNPJ { get; set; }
        public string Nome { get; set; }
        public string CEP { get; set; }
        public ICollection<FornecedorEmpresa>? Fornecedores { get; set;}
    }
}
