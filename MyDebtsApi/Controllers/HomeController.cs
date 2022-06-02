using Microsoft.AspNetCore.Mvc;
using MyDebtsApi.Data;
using MyDebtsApi.Model;

namespace MyDebtsApi.Controllers
{   
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Get([FromServices] AppDbContext context)
            => Ok(context.Dividas.ToList());
        

        [HttpGet("/{id:int}")]
        public IActionResult GetPegarId([FromRoute] int id, [FromServices] AppDbContext context)
        {
            var divida = context.Dividas.FirstOrDefault(x => x.Id == id);
            if(divida == null)
                return NotFound();
            return Ok(divida);
        }

        [HttpPost("/")]
        public IActionResult Post([FromBody] DividaModel divida, [FromServices] AppDbContext context)
        {
            context.Dividas.Add(divida);
            context.SaveChanges();

            return Created($"/{divida.Id}", divida);
        }

        [HttpPut("/{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] DividaModel divida, [FromServices] AppDbContext context)
        {
            var model = context.Dividas.FirstOrDefault(x=> x.Id == id);
            if(model == null)
                return NotFound();
            model.Titulo = divida.Titulo;
            model.Descricao = divida.Descricao;
            context.Dividas.Update(model);
            context.SaveChanges();

            return Ok(model);
        }

        [HttpDelete("/{id:int}")]
        public IActionResult Delete([FromRoute] int id, [FromServices] AppDbContext context)
        {
            var model = context.Dividas.FirstOrDefault(x=> x.Id == id);
            
            if(model == null)
                return NotFound();
            context.Dividas.Remove(model);
            context.SaveChanges();

            return Ok(model);
        }
    }
}