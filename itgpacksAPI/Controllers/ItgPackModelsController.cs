using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using itgpacksAPI;
using itgpacksAPI.Models;
using System.Web.Http.Cors;

namespace itgpacksAPI.Controllers
{
    /*[EnableCors(origins: "*", headers: "*", methods: "*")]*/
    [Route("api/[controller]")]
    [ApiController]
    public class ItgPackModelsController(ItgPacksContext context) : ControllerBase
    {

        // GET: api/ItgPackModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItgPackModel>>> GetItgPackModel()
        {
            return await context.ItgPackModel.ToListAsync();
        }

        // GET: api/ItgPackModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItgPackModel>> GetItgPackModel(string id)
        {
            var itgPackModel = await context.ItgPackModel.FindAsync(id);

            if (itgPackModel == null)
            {
                return NotFound();
            }

            return itgPackModel;
        }

        // PUT: api/ItgPackModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItgPackModel(string id, ItgPackModel itgPackModel)
        {
            if (id != itgPackModel.Id)
            {
                return BadRequest();
            }

            context.Entry(itgPackModel).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItgPackModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ItgPackModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItgPackModel>> PostItgPackModel(ItgPackModel itgPackModel)
        {
            context.ItgPackModel.Add(itgPackModel);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ItgPackModelExists(itgPackModel.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetItgPackModel", new { id = itgPackModel.Id }, itgPackModel);
        }

        // DELETE: api/ItgPackModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItgPackModel(string id)
        {
            var itgPackModel = await context.ItgPackModel.FindAsync(id);
            if (itgPackModel == null)
            {
                return NotFound();
            }

            context.ItgPackModel.Remove(itgPackModel);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItgPackModelExists(string id)
        {
            return context.ItgPackModel.Any(e => e.Id == id);
        }
    }
}
