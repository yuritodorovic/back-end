using AutoMapper;
using BackEnd.Context;
using BackEnd.Model;
using BackEnd.VOS.Entrada.Empresa;
using BackEnd.VOS.Saida.Empresa;
using BackEnd.VOS.Saida.Fornecedor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EmpresaController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<EmpresaVOSaida>> Post(EmpresaVOEntrada entity)
        {
            var convert = _mapper.Map<EmpresaVOEntrada, Empresa>(entity);
            await _context.Empresas.AddAsync(convert);
            await _context.SaveChangesAsync();

            var retorno = _mapper.Map<Empresa, EmpresaVOSaida>(convert);
            return Ok(retorno);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaVOSaida>>> Get()
        {
            var getEntities = await _context.Empresas.ToListAsync();

            var retorno = _mapper.Map<List<Empresa>, List<EmpresaVOSaida>>(getEntities);
            return Ok(retorno);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            var getEntities = await _context.Empresas.Include(e => e.Fornecedores).FirstOrDefaultAsync(e => e.Id == Guid.Parse(id));
            if (getEntities == null) return NotFound();
            _context.Empresas.Entry(getEntities).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            
            return Ok(true);
        }
    }
}
