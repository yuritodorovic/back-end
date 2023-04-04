using BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<FornecedorEmpresa> FornededorEmpresas { get; set; }
    }
}
