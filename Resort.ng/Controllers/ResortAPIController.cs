using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resort.ng.Data;
using Resort.ng.Model;
using Resort.ng.Model.DTO;
using Resort.ng.Repository.IRepository;

namespace Resort.ng.Controllers
{
    [Route("api/ResortAPI")]
    [ApiController]
    public class ResortAPIController : ControllerBase
    {
        //private readonly ILogger _logger;
        private readonly IResortRepository _dbResort;
        private readonly IMapper _mapper;

        public ResortAPIController( IResortRepository dbResort, IMapper mapper)
        {
             _dbResort = dbResort;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ResortsDto>>> GetResorts()
        {
           // _logger.LogInformation("Getting all resorts");
           IEnumerable<Resorts> resortList = await _dbResort.GetAllAsync();
            return Ok(_mapper.Map<List<ResortsDto>>(resortList));
        }

        [HttpGet("{id:int}", Name = "GetResort")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200, Type =typeof(ResortDto))]
        public async Task<ActionResult<ResortsDto>> GetResort(int id)
        {
            if (id == 0)
            {
              // _logger.LogError("Get Resort Error with Id" + id);
                return BadRequest();
            }

            var resort = await _dbResort.GetAsync(x => x.Id == id);
            if (resort == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ResortsDto>(resort));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResortsDto>> CreateResort([FromBody] ResortsCreateDto createDto)
        {
            /* if (!ModelState.IsValid)
             { 
                 return BadRequest(ModelState); 
             }*/
            if (await _dbResort.GetAsync(u => u.Name.ToLower() == createDto.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomerError", "Resort already Exists!");
                return BadRequest(ModelState);
            }

            if (createDto == null)
            {
                return BadRequest(createDto);
            }

            /*if (resortDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }*/

            Resorts model = _mapper.Map<Resorts>(createDto);
         
            
             await _dbResort.CreateAsync(model);
             return CreatedAtRoute("GetResort", new { id = model.Id }, model);

        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteResort")]
        public async Task<IActionResult> DeleteResort(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var resort =await _dbResort.GetAsync(r => r.Id == id);

            if (resort == null)
            {
                return NotFound();
            }

            await _dbResort.RemoveAsync(resort);
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateResort")]
        public async Task<IActionResult> UpdateResort(int id, [FromBody]ResortsUpdateDto updateDto)
        {
            if (updateDto == null || id != updateDto.Id)
            {
                return BadRequest();
            }
            /*var resort = _db.Resorts_Db.FirstOrDefault(u => u.Id == id);
            resort.Name = resortDto.Name;
            resort.Sqft = resortDto.Sqft;   
            resort.Occupancy = resortDto.Occupancy;
*/

            Resorts model = _mapper.Map<Resorts>(updateDto);
            
            await _dbResort.UpdateAsync(model);
          
            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialResort")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public async Task<IActionResult> UpdatePartialResort(int id, JsonPatchDocument<ResortsUpdateDto> patchDTO)
        {
            if (patchDTO == null || id == 0)
                {
                     return BadRequest();
                }
            var resort =await _dbResort.GetAsync(u => u.Id == id,tracked:false);

            ResortsUpdateDto resortsDto = _mapper.Map<ResortsUpdateDto>(resort);

           

           
            if (resort == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(resortsDto, ModelState);
            Resorts model = _mapper.Map<Resorts>(resortsDto);

            
            await _dbResort.UpdateAsync(model);
           

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();

        }
    }
}

