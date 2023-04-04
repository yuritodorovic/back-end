using AutoMapper;
using BackEnd.Context;
using BackEnd.Model;
using BackEnd.Profiles;
using BackEnd.VOS.Saida.FornecedorEmpresa;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorEmpresaController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public FornecedorEmpresaController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<FornecedorEmpresaExit>>> GetAll(string id)
        {
            var get = await _context.FornededorEmpresas.Include(e => e.Fornecedor).Where(e => e.EmpresaId == Guid.Parse(id)).ToListAsync();
            var convert = _mapper.Map<List<FornecedorEmpresa>, List<FornecedorEmpresaExit>>(get);
            return(convert);
        }
    }
}
