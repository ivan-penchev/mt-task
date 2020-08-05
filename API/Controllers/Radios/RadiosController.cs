using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers.Radios.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Services;
using API.Extensions;
namespace API.Controllers.Radios
{
    [Route("[controller]")]
    [ApiController]
    public class RadiosController : ControllerBase
    {
        private readonly IRadioService radioService;

        public RadiosController(IRadioService radioService)
        {
            this.radioService = radioService;
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<ActionResult> CreateRadio(int id, RadioInputModel input)
        {
            if (await radioService.FindById(id) != null)
                return BadRequest(); // assumptions here... not in the specs.

            var entity = input.ToRadioEntity(id);
            ActionResult result = null;
            try
            {
                await radioService.Save(entity);
                result = Ok();
            } catch
            {
                result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            return result;
        }

        [HttpGet]
        [Route("{id}/location")]
        public async Task<ActionResult<LocationOutputModel>> GetRadioLocation(int id)
        {
            var radio = await radioService.FindById(id);
            ActionResult result = null;
            if(radio == null)
            {
                result = BadRequest();
            }
            else
            {
                if (radio.HasLocation())
                    result = Ok(radio.ToLocationOutput());
                else
                    result = NotFound();
            }
            return result;
        }

        [HttpPost]
        [Route("{id}/location")]
        public async Task<ActionResult> CreateRadioLocation(int id, LocationInputModel input)
        {

            var radio = await radioService.FindById(id);
            ActionResult result = null;
            if (radio.CanBePlaced(input.Location))
            {
                radio.PlaceAtLocation(input.Location);
                await radioService.Save(radio);
                result = Ok();
            }
            else
            {
                result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            }
            return result;
        }

        
    }
}
