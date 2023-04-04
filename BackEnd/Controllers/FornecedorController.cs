using AutoMapper;
using BackEnd.Context;
using BackEnd.Model;
using BackEnd.VOS.Entrada.Fornecedor;
using BackEnd.VOS.Saida.Empresa;
using BackEnd.VOS.Saida.Fornecedor;
using BackEnd.VOS.Saida.FornecedorEmpresa;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public FornecedorController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<FornecedorVOSaida>> Post (FornecedorVOEntrada entity)
        {
            var convert = _mapper.Map<FornecedorVOEntrada, Fornecedor>(entity);
            await _context.Fornecedores.AddAsync(convert);
            await _context.SaveChangesAsync();
            var retorno = _mapper.Map<Fornecedor, FornecedorVOSaida>(convert);
            return Ok(retorno);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FornecedorVOSaida>>> Get()
        {
            var getEntities = await _context.Fornecedores.ToListAsync();
            
            var retorno = _mapper.Map<List<Fornecedor>, List<FornecedorVOSaida>>(getEntities);
            return Ok(retorno);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<EmpresaVOSaida>>> GetAll(string id)
        {
            var get = await _context.FornededorEmpresas.Include(e => e.Empresa).Where(e => e.FornecedorId == Guid.Parse(id)).ToListAsync();
            var convert = _mapper.Map<List<FornecedorEmpresa>, List<EmpresaVOSaida>>(get);
            return (convert);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            var getEntities = await _context.Fornecedores.Include(e => e.Empresas).FirstOrDefaultAsync(e => e.Id == Guid.Parse(id));
            if (getEntities == null) return NotFound();
            _context.Fornecedores.Entry(getEntities).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return Ok(true);
        }
    }
}
