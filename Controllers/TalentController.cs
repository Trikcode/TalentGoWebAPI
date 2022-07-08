using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TalentGoWebAPI.Data;
using TalentGoWebAPI.Models;

namespace TalentGoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalentController : ControllerBase
    {
        public static List<Talents> talents = new List<Talents>
            {
                //new Talents
                //{
                //    Id = 1,
                //    FirstName = "Nobert",
                //    LastName = "Ayesiga",
                //    Talent = "Developer",
                //    EmailAddress = "ayesiganobert@gmail.com"
                //}, 
                //new Talents { 
                //    Id = 2,
                //    FirstName = "Jonh", 
                //    LastName="Kim" ,
                //    EmailAddress="kim@gmail.com"
                //}, 
                // new Talents {
                //    Id = 3,
                //    FirstName = "Ronald",
                //    LastName="James" ,
                //    EmailAddress="kim@gmail.com"
                //}
            };
        private readonly DataContextDB context;

        public TalentController(DataContextDB context )
        {
            this.context = context;
        }

        [HttpGet]
       public async Task<ActionResult<List<Talents>>> Get()
        {
            
            return Ok(await context.Talents.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Talents>> Get(int id)
        {
            var talent = await context.Talents.FindAsync(id);
            if (talent == null)
            {
                return BadRequest("Talent not found");
            }
            return Ok(talent);
        }

        [HttpPost]
        public async Task<ActionResult<List<Talents>>> AddTalent(Talents talent)
        {
            context.Talents.Add(talent);
            await context.SaveChangesAsync();

            return Ok(await context.Talents.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Talents>>> UpdateTalent(Talents talentrqst)
        {
            var dbtalent = await context.Talents.FindAsync(talentrqst.Id);
            if (dbtalent == null)
            {
                return BadRequest("Talent not found");
            }
            dbtalent.FirstName = talentrqst.FirstName;
            dbtalent.LastName = talentrqst.LastName;
            dbtalent.Talent = talentrqst.Talent;
            dbtalent.EmailAddress = talentrqst.EmailAddress;
            await context.SaveChangesAsync();
            return Ok(await context.Talents.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Talents>> DeleteTalent(int id)
        {
            var dbtalent = await context.Talents.FindAsync(id);
            if (dbtalent == null)
            {
                return BadRequest("Talent Doesn't Exist");
            }
            context.Talents.Remove(dbtalent);
            await context.SaveChangesAsync();
            return Ok(await context.Talents.ToListAsync());
        }

    }
}
