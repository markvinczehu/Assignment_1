using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PeopleWebApi.Models;
using PeopleWebApi.Repository;

namespace PeopleWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultsController : ControllerBase
    {
        private IAdultRepository dataService;

        public AdultsController(IAdultRepository dataService) {
            this.dataService = dataService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdults() {
            try {
                IList<Adult> adults = await dataService.GetAdultsAsync();
                return Ok(adults);
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> GetAdult([FromRoute] int id)
        {
            try
            {
                Adult adult = await dataService.GetAdultByIdAsync(id);
                return Ok(adult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task DeleteAdult([FromRoute] int id) {
            try
            {
                await dataService.RemoveAdultAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        [HttpPost]
        public async Task AddAdult([FromBody] Adult adult) {
            if (!ModelState.IsValid)
            {
                Console.WriteLine(BadRequest(ModelState));
            }
            try {
                await dataService.AddAdultAsync(adult);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        [HttpPatch]
        public async Task UpdateAdult([FromBody] Adult adult) {
            try {
                await dataService.UpdateAdultAsync(adult);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                StatusCode(500, e.Message);
            }
        }
    }
}