using Microsoft.AspNetCore.Mvc;
using MyDebtsApi.Data;
using MyDebtsApi.Model;

namespace MyDebtsApi.Controllers
{   
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        //POSSO USAR A ROTA JUNTO COM O HttpGet também ********
        //[Route("/")]
        public List<DividaModel> Get([FromServices] AppDbContext context)
        {
            return context.Dividas.ToList();
        }

        [HttpGet("/{id:int}")]
        public DividaModel GetPegarId([FromRoute] int id, [FromServices] AppDbContext context)
        {
            return context.Dividas.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost("/")]
        public DividaModel Post([FromBody] DividaModel divida, [FromServices] AppDbContext context)
        {
            context.Dividas.Add(divida);
            context.SaveChanges();

            return divida;
        }

        [HttpPut("/{id:int}")]
        public DividaModel Put([FromRoute] int id, [FromBody] DividaModel divida, [FromServices] AppDbContext context)
        {
            var model = context.Dividas.FirstOrDefault(x=> x.Id == id);
            if(model == null)
                return divida;
            model.Titulo = divida.Titulo;
            model.Descricao = divida.Descricao;
            context.Dividas.Update(model);
            context.SaveChanges();

            return model;
        }

        [HttpDelete("/{id:int}")]
        public DividaModel Delete([FromRoute] int id, [FromServices] AppDbContext context)
        {
            var model = context.Dividas.FirstOrDefault(x=> x.Id == id);
            
            context.Dividas.Remove(model);
            context.SaveChanges();

            return model;
        }
    }
}