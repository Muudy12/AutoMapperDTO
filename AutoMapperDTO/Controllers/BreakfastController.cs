using AutoMapper;
using AutoMapperDTO.Models;
using AutoMapperDTO.Records.Breakfast;
using AutoMapperDTO.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperDTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreakfastController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBreakfastService _breakfastService;

        public BreakfastController(IMapper mapper, IBreakfastService breakfastService)
        {
            _mapper = mapper;
            _breakfastService = breakfastService;
        }

        [HttpPost]
        public IActionResult CreateBreakfast(CreateBreakfastRequest request)
        {
            // mapping the data that we get in the request to the language our application speaks
            // map the request to Breakfast model/object
            var breakfast = new Breakfast(
                Guid.NewGuid(),
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                DateTime.UtcNow,
                request.Savory,
                request.Sweet);

            // after injecting the IBreakfastService
            _breakfastService.CreateBreakfast(breakfast);

            // taking the data from our system and converting it back to the API definition and returning the appropriate response
            var response = new BreakfastResponse()
            {
                Id = breakfast.Id,
                Name = breakfast.Name,
                Description = breakfast.Description,
                StartDateTime = breakfast.StartDateTime,
                EndDateTime = breakfast.EndDateTime,
                LastModifiedDateTime = breakfast.LastModifiedDateTime,
                Savory = breakfast.Savory,
                Sweet = breakfast.Sweet
            };

            //return Ok(response);
            // returning the appropriate response
            return CreatedAtAction(
                actionName: nameof(GetBreakfastByGuid),
                routeValues: new { id = breakfast.Id },
                value: response);
        }

        [HttpGet("{id:guid}")] //the "{id:guid}" or "/[action]" are endpoints
        public IActionResult GetBreakfastByGuid(Guid id)
        {
            Breakfast breakfast = _breakfastService.GetBreakfast(id);
            var response = new BreakfastResponse()
            {
                Id = breakfast.Id,
                Name = breakfast.Name,
                Description = breakfast.Description,
                StartDateTime = breakfast.StartDateTime,
                EndDateTime = breakfast.EndDateTime,
                LastModifiedDateTime = breakfast.LastModifiedDateTime,
                Savory = breakfast.Savory,
                Sweet = breakfast.Sweet
            };

            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
        {
            var breakfast = new Breakfast(
                Guid.NewGuid(),
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                DateTime.UtcNow,
                request.Savory,
                request.Sweet);

            _breakfastService.UpsertBreakfast(breakfast);

            // TODO: return 201 if a new breakfast was created
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteBreakfast(Guid id)
        {
            _breakfastService.DeleteBreakfast(id);
            return NoContent();
        }
    }
}
