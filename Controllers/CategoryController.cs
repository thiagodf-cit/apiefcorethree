using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EfCoreThree.Models;
using EfCoreThree.Data;
using Microsoft.EntityFrameworkCore;

namespace EfCoreThree.Controllers
{
    [ApiController]
    [Route("api/v1/categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext context)
        {
            var categories = await context.Categories.ToListAsync();
            return categories;
        }
        
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Category>> Post(
            [FromServices] DataContext context,
            [FromBody] Category model)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> Put(
            int id,
            [FromServices] DataContext context,
            [FromBody] Category model)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Update(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // [HttpDelete]
        // [Route("{id:int}")]
        // public async Task<ActionResult<Category>> Delete(int id)
        // {
        // }
    }
}