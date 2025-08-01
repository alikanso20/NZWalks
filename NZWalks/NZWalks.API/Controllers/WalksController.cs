using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private IMapper mapper { get; }
        private IWalkRepository walkRepository { get; }

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalks([FromQuery] string? filterOn, [FromQuery] string? filterQuery, 
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var walksDomainModel = await walkRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);
            return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));
        } 

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateWalk([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            var walkdDomainModel = mapper.Map<Walk>(addWalkRequestDto);
            await walkRepository.CreateWalkAsync(walkdDomainModel);

            return Ok(mapper.Map<WalkDto>(walkdDomainModel));
        }

        [HttpGet]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> GetWalkById(Guid Id)
        {
            var walkDomainModel = await walkRepository.GetWalkByIdAsync(Id);
            if (walkDomainModel == null)
                return NotFound();

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        [HttpPut]
        [Route("{Id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid Id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);
            var updatedWalk = await walkRepository.UpdateWalkAsync(Id, walkDomainModel);
            if (updatedWalk == null)
                return NotFound();

            return Ok(mapper.Map<WalkDto>(updatedWalk));
        }

        [HttpDelete]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> DeleteWalk([FromRoute] Guid Id)
        {
            var deletedWalkDomainModel = await walkRepository.DeleteWalkAsync(Id);
            if (deletedWalkDomainModel == null)
                return NotFound();

            return Ok(mapper.Map<WalkDto>(deletedWalkDomainModel));
        }
    }
}
