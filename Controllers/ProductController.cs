
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testeef.Data;
using testeef.Models;
using System.Linq;

namespace testeef.Controllers
{
    [ApiController]
    [Route("v1/products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context)
        {
            var products = await context.Products.Include(x => x.Category).ToListAsync();
            return products;
        }

        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetById([FromServices] DataContext context, int id)
        {
            var product = await context.Products.Include(x => x.Category)
            .AsNoTracking() //importante qdo se trata somente de visualizar na tela as info
            // pq qdo edita, exclui, atualiza o EF fica mantendo versões (proxies) dos objetos
            // a fim de gerenciar a persistencia no banco. Como é uma consulta, bota 
            // AsNoTracking pra melhor peformance e n precisa deixar o EF fazendo esse gernciamento
            .FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        [HttpGet]
        [Route("categories/{id:int}")]
        public async Task<ActionResult<List<Product>>> GetByCategory([FromServices] DataContext context, int categoryId)
        {
            var products = await context.Products
            .Include(x => x.Category)
            .AsNoTracking() //importante qdo se trata somente de visualizar na tela as info
            // pq qdo edita, exclui, atualiza o EF fica mantendo versões (proxies) dos objetos
            // a fim de gerenciar a persistencia no banco. Como é uma consulta, bota 
            // AsNoTracking pra melhor peformance e n precisa deixar o EF fazendo esse gernciamento
            .Where(x => x.CategoryId == categoryId)
            .ToListAsync();

            return products;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Product>> Post(
            [FromServices] DataContext context,
            [FromBody] Product model)
        {
            if(ModelState.IsValid) //valida cada campo dataannotation das models
            {
                context.Products.Add(model);
                await context.SaveChangesAsync();
                return model;
            }else
            {
                return BadRequest(ModelState);
            }
        }
        


    }
    
}